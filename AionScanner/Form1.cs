using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using WindowsInput;
using System.Threading;
using System.IO;

namespace AionScanner
{
    public partial class Form1 : Form
    {
        Process HandleP;

        //Foreground get and set are only imported because I am lazily using an active window to send events. Kill this when you re-wire

        #region imports
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        //testing
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern short MapVirtualKey(int wCode, int wMapType);

        // ByteSigScan convention.

        [DllImport("ByteSigScan.dll", EntryPoint = "InitializeSigScan", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSigScan(uint iPID, [MarshalAs(UnmanagedType.LPStr)] string szModule);

        [DllImport("ByteSigScan.dll", EntryPoint = "SigScan", CallingConvention = CallingConvention.Cdecl)]
        public static extern UInt32 SigScan([MarshalAs(UnmanagedType.LPStr)] string Pattern, int Offset);

        [DllImport("ByteSigScan.dll", EntryPoint = "FinalizeSigScan", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FinalizeSigScan();

        // Kernel dll convention.

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, ref uint lpBuffer, int dwSize, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, ref float lpBuffer, int dwSize, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, ref string lpBuffer, int dwSize, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, int lpNumberOfBytesRead);  
        #endregion


        Thread healBotThread = new Thread(new ThreadStart(healBotMReader));
        Thread walkThread = new Thread(new ThreadStart(walk));
        Thread castingThread = new Thread(new ThreadStart(casting));

        public static Dictionary<string, int> timers = new Dictionary<string, int>();

        public string lastTarget = "";


        #region dictionaries //
        enum ProcessAccessFlags : uint
        {
            PROCESS_ALL_ACCESS = 0x001F0FFF,
            PROCESS_CREATE_THREAD = 0x00000002,
            PROCESS_DUP_HANDLE = 0x00000040,
            PROCESS_QUERY_INFORMATION = 0x00000400,
            PROCESS_SET_INFORMATION = 0x00000200,
            PROCESS_TERMINATE = 0x00000001,
            PROCESS_VM_OPERATION = 0x00000008,
            PROCESS_VM_READ = 0x00000010,
            PROCESS_VM_WRITE = 0x00000020,
            SYNCHRONIZE = 0x00100000
        }

        public enum Message : int
        {
            /// <summary>Key down</summary>
            KEY_DOWN = (0x0100),
            /// <summary>Key up</summary>
            KEY_UP = (0x0101),
            /// <summary>The character being pressed</summary>
            VM_CHAR = (0x0102),
            /// <summary>An Alt/ctrl/shift + key down message</summary>
            SYSKEYDOWN = (0x0104),
            /// <summary>An Alt/Ctrl/Shift + Key up Message</summary>
            SYSKEYUP = (0x0105),
            /// <summary>An Alt/Ctrl/Shift + Key character Message</summary>
            SYSCHAR = (0x0106),
            /// <summary>Left mousebutton down</summary>
            LBUTTONDOWN = (0x201),
            /// <summary>Left mousebutton up</summary>
            LBUTTONUP = (0x202),
            /// <summary>Left mousebutton double left click</summary>
            LBUTTONDBLCLK = (0x203),
            /// <summary>Right mousebutton down</summary>
            RBUTTONDOWN = (0x204),
            /// <summary>Right mousebutton up</summary>
            RBUTTONUP = (0x205),
            /// <summary>Right mousebutton doubleclick</summary>
            RBUTTONDBLCLK = (0x206)
        }

        [Serializable]
        public enum VKeys : int
        {
            ///<summary>0 key </summary>
            KEY_0 = 0x30,
            ///<summary>1 key </summary>
            KEY_1 = 0x31,
            ///<summary>2 key </summary>
            KEY_2 = 0x32,
            ///<summary>3 key </summary>
            KEY_3 = 0x33,
            ///<summary>4 key </summary>
            KEY_4 = 0x34,
            ///<summary>5 key </summary>
            KEY_5 = 0x35,
            ///<summary>6 key </summary>
            KEY_6 = 0x36,
            ///<summary>7 key </summary>
            KEY_7 = 0x37,
            ///<summary>8 key </summary>
            KEY_8 = 0x38,
            ///<summary>9 key</summary>
            KEY_9 = 0x39,
            ///<summary> - key</summary>
            KEY_MINUS = 0xBD,
            ///<summary> + key</summary>
            KEY_PLUS = 0xBB,
            ///<summary>A key </summary>
            KEY_A = 0x41,
            ///<summary>B key </summary>
            KEY_B = 0x42,
            ///<summary>C key </summary>
            KEY_C = 0x43,
            ///<summary>D key </summary>
            KEY_D = 0x44,
            ///<summary>E key </summary>
            KEY_E = 0x45,
            ///<summary>F key </summary>
            KEY_F = 0x46,
            ///<summary>G key </summary>
            KEY_G = 0x47,
            ///<summary>H key </summary>
            KEY_H = 0x48,
            ///<summary>I key </summary>
            KEY_I = 0x49,
            ///<summary>J key </summary>
            KEY_J = 0x4A,
            ///<summary>K key </summary>
            KEY_K = 0x4B,
            ///<summary>L key </summary>
            KEY_L = 0x4C,
            ///<summary>M key </summary>
            KEY_M = 0x4D,
            ///<summary>N key </summary>
            KEY_N = 0x4E,
            ///<summary>O key </summary>
            KEY_O = 0x4F,
            ///<summary>P key </summary>
            KEY_P = 0x50,
            ///<summary>Q key </summary>
            KEY_Q = 0x51,
            ///<summary>R key </summary>
            KEY_R = 0x52,
            ///<summary>S key </summary>
            KEY_S = 0x53,
            ///<summary>T key </summary>
            KEY_T = 0x54,
            ///<summary>U key </summary>
            KEY_U = 0x55,
            ///<summary>V key </summary>
            KEY_V = 0x56,
            ///<summary>W key </summary>
            KEY_W = 0x57,
            ///<summary>X key </summary>
            KEY_X = 0x58,
            ///<summary>Y key </summary>
            KEY_Y = 0x59,
            ///<summary>Z key </summary>
            KEY_Z = 0x5A,
            ///<summary>Left mouse button </summary>
            KEY_LBUTTON = 0x01,
            ///<summary>Right mouse button </summary>
            KEY_RBUTTON = 0x02,
            ///<summary>Control-break processing </summary>
            KEY_CANCEL = 0x03,
            ///<summary>Middle mouse button (three-button mouse) </summary>
            KEY_MBUTTON = 0x04,
            ///<summary>BACKSPACE key </summary>
            KEY_BACK = 0x08,
            ///<summary>TAB key </summary>
            KEY_TAB = 0x09,
            ///<summary>CLEAR key </summary>
            KEY_CLEAR = 0x0C,
            ///<summary>ENTER key </summary>
            KEY_RETURN = 0x0D,
            ///<summary>SHIFT key </summary>
            KEY_SHIFT = 0x10,
            ///<summary>CTRL key </summary>
            KEY_CONTROL = 0x11,
            ///<summary>ALT key </summary>
            KEY_MENU = 0x12,
            ///<summary>PAUSE key </summary>
            KEY_PAUSE = 0x13,
            ///<summary>CAPS LOCK key </summary>
            KEY_CAPITAL = 0x14,
            ///<summary>ESC key </summary>
            KEY_ESCAPE = 0x1B,
            ///<summary>SPACEBAR </summary>
            KEY_SPACE = 0x20,
            ///<summary>PAGE UP key </summary>
            KEY_PRIOR = 0x21,
            ///<summary>PAGE DOWN key </summary>
            KEY_NEXT = 0x22,
            ///<summary>END key </summary>
            KEY_END = 0x23,
            ///<summary>HOME key </summary>
            KEY_HOME = 0x24,
            ///<summary>LEFT ARROW key </summary>
            KEY_LEFT = 0x25,
            ///<summary>UP ARROW key </summary>
            KEY_UP = 0x26,
            ///<summary>RIGHT ARROW key </summary>
            KEY_RIGHT = 0x27,
            ///<summary>DOWN ARROW key </summary>
            KEY_DOWN = 0x28,
            ///<summary>SELECT key </summary>
            KEY_SELECT = 0x29,
            ///<summary>PRINT key </summary>
            KEY_PRINT = 0x2A,
            ///<summary>EXECUTE key </summary>
            KEY_EXECUTE = 0x2B,
            ///<summary>PRINT SCREEN key </summary>
            KEY_SNAPSHOT = 0x2C,
            ///<summary>INS key </summary>
            KEY_INSERT = 0x2D,
            ///<summary>DEL key </summary>
            KEY_DELETE = 0x2E,
            ///<summary>HELP key </summary>
            KEY_HELP = 0x2F,
            ///<summary>Numeric keypad 0 key </summary>
            KEY_NUMPAD0 = 0x60,
            ///<summary>Numeric keypad 1 key </summary>
            KEY_NUMPAD1 = 0x61,
            ///<summary>Numeric keypad 2 key </summary>
            KEY_NUMPAD2 = 0x62,
            ///<summary>Numeric keypad 3 key </summary>
            KEY_NUMPAD3 = 0x63,
            ///<summary>Numeric keypad 4 key </summary>
            KEY_NUMPAD4 = 0x64,
            ///<summary>Numeric keypad 5 key </summary>
            KEY_NUMPAD5 = 0x65,
            ///<summary>Numeric keypad 6 key </summary>
            KEY_NUMPAD6 = 0x66,
            ///<summary>Numeric keypad 7 key </summary>
            KEY_NUMPAD7 = 0x67,
            ///<summary>Numeric keypad 8 key </summary>
            KEY_NUMPAD8 = 0x68,
            ///<summary>Numeric keypad 9 key </summary>
            KEY_NUMPAD9 = 0x69,
            ///<summary>Separator key </summary>
            KEY_SEPARATOR = 0x6C,
            ///<summary>Subtract key </summary>
            KEY_SUBTRACT = 0x6D,
            ///<summary>Decimal key </summary>
            KEY_DECIMAL = 0x6E,
            ///<summary>Divide key </summary>
            KEY_DIVIDE = 0x6F,
            ///<summary>F1 key </summary>
            KEY_F1 = 0x70,
            ///<summary>F2 key </summary>
            KEY_F2 = 0x71,
            ///<summary>F3 key </summary>
            KEY_F3 = 0x72,
            ///<summary>F4 key </summary>
            KEY_F4 = 0x73,
            ///<summary>F5 key </summary>
            KEY_F5 = 0x74,
            ///<summary>F6 key </summary>
            KEY_F6 = 0x75,
            ///<summary>F7 key </summary>
            KEY_F7 = 0x76,
            ///<summary>F8 key </summary>
            KEY_F8 = 0x77,
            ///<summary>F9 key </summary>
            KEY_F9 = 0x78,
            ///<summary>F10 key </summary>
            KEY_F10 = 0x79,
            ///<summary>F11 key </summary>
            KEY_F11 = 0x7A,
            ///<summary>F12 key </summary>
            KEY_F12 = 0x7B,
            ///<summary>SCROLL LOCK key </summary>
            KEY_SCROLL = 0x91,
            ///<summary>Left SHIFT key </summary>
            KEY_LSHIFT = 0xA0,
            ///<summary>Right SHIFT key </summary>
            KEY_RSHIFT = 0xA1,
            ///<summary>Left CONTROL key </summary>
            KEY_LCONTROL = 0xA2,
            ///<summary>Right CONTROL key </summary>
            KEY_RCONTROL = 0xA3,
            ///<summary>Left MENU key </summary>
            KEY_LMENU = 0xA4,
            ///<summary>Right MENU key </summary>
            KEY_RMENU = 0xA5,
            ///<summary>, key</summary>
            KEY_COMMA = 0xBC,
            ///<summary>. key</summary>
            KEY_PERIOD = 0xBE,
            ///<summary>Play key </summary>
            KEY_PLAY = 0xFA,
            ///<summary>Zoom key </summary>
            KEY_ZOOM = 0xFB,
            NULL = 0x0,
        } 
        #endregion


        //uint currentPID = 0;
        uint gamedll = 0;
        string PISigTest = "00??????8B????68XXXXXXXX8D??3A??8D"; // Good, 2 Static references




        public Form1()
        {
            InitializeComponent();


            Process[] ProcessList = Process.GetProcesses();
            String ProcessName;
            int count = 0;

            pidBox.Items.Clear();
            for (int i = 0; i < ProcessList.Length; i++)
            {
                ProcessName = ProcessList[i].ProcessName;

                if (ProcessName == "AION.bin")
                {
                    int temp = ProcessList[i].MainWindowTitle.IndexOf("AION Client");
                    if ((ProcessList[i].MainWindowTitle.IndexOf("AION Client") > -1))
                    {


                        pidBox.Items.Add("AION.bin" + " - " + ProcessList[i].Id);
                        pidBox.SelectedIndex = 0;
                        HandleP = System.Diagnostics.Process.GetProcessById(ProcessList[i].Id);

                        foreach (System.Diagnostics.ProcessModule Module in HandleP.Modules)
                        {
                            if ("Game.dll" == Module.ModuleName)
                            {
                                count++;

                                if (count == Convert.ToInt32(cmbDll.Text))
                                {
                                    gamedll = (uint)Module.BaseAddress.ToInt32();
                                }

                            }
                        }
                    }
                }
            }
            
            //one time inits

            //add dictionary timer
            timers.Add("VK_1", 0);
            timers.Add("VK_2", 0);
            timers.Add("VK_3", 0);
            timers.Add("VK_4", 0);
            timers.Add("VK_5", 0);
            timers.Add("VK_6", 0);
            timers.Add("VK_7", 0);
            timers.Add("VK_8", 0);
            timers.Add("VK_9", 0);
            timers.Add("VK_0", 0);
            timers.Add("OEM_MINUS", 0);
            timers.Add("OEM_PLUS", 0);


            //initialize memory worker thread
            healBotThread.Start();
            walkThread.Start();
            castingThread.Start();

            //read settings from file
            loadSettings();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //button2.Enabled = true;

            string AionID = pidBox.Text;
            int AionIDPosition = AionID.IndexOf(" - ");
            AionID = AionID.Remove(0, AionIDPosition + 3);
            memory.currentPID = (uint)Convert.ToUInt32(AionID);
            //add h and s proc refs
            memory.sProc = OpenProcess(ProcessAccessFlags.PROCESS_VM_READ, false, memory.currentPID);
            memory.hProc = OpenProcess(ProcessAccessFlags.PROCESS_VM_READ, false, memory.currentPID);

            //perform pointer scan
            pointerScan("");
        }

        private void switchDll()
        {

            //this is just for handling multiple instances of the game dll you seem to have this resolved already
            int count = 0;

            string AionID = pidBox.Text;
            int AionIDPosition = AionID.IndexOf(" - ");
            AionID = AionID.Remove(0, AionIDPosition + 3);
            memory.currentPID = (uint)Convert.ToUInt32(AionID);

            HandleP = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(memory.currentPID.ToString()));

            foreach (System.Diagnostics.ProcessModule Module in HandleP.Modules)
            {
                if ("Game.dll" == Module.ModuleName)
                {
                    count++;

                    if (count == Convert.ToInt32(cmbDll.Text))
                    {
                        gamedll = (uint)Module.BaseAddress.ToInt32();
                    }

                }
            }

            pointerScan("");

        }
        private void pidBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            //button2.Enabled = false;
        }

        private void pointerScan(string type)
        {
            if (type != "party")
            {
                uint PITest = 0;

                    InitializeSigScan(memory.currentPID, "Game.dll");
                    PITest = SigScan(PISigTest, 0);
                    memory.playerInfoAddress = PITest;
                FinalizeSigScan();
            }

            uint lp1Party1 = 0;
            uint lp2Party1 = 0;
            uint lp3Party1 = 0;
            uint lp4Party1 = 0;
            uint lfinalParty1 = 0;

            //Here I am initially identifying the final party1 offset. All party info offsets are based on this.
            ReadProcessMemory(memory.hProc, gamedll + 0xC8FA64, ref lp1Party1, 4, 0);
            ReadProcessMemory(memory.hProc, lp1Party1 + 0x10, ref lp2Party1, 4, 0);
            ReadProcessMemory(memory.hProc, lp2Party1 + 0x40, ref lp3Party1, 4, 0);
            ReadProcessMemory(memory.hProc, lp3Party1 + 0x10, ref lp4Party1, 4, 0);
            ReadProcessMemory(memory.hProc, lp4Party1 + 0x8, ref lfinalParty1, 4, 0);

            memory.finalParty1 = lfinalParty1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pointerScan("");

            //I was cleaning code and couldnt figure why I had these items here, they seem useless
            //txtLevel.Text = BitConverter.ToInt16(plvl, 1).ToString();
            //float pX = 0;
            //ReadProcessMemory(memory.hProc, lfinalParty1 + 0x2C, ref pX, 4, 0);

           

            //if (WriteLoc.Checked == true)
            //{
                //This is just for my testing new functions directly to mem... 
                //ignore it please

                /*
                uint memPosx1 = Convert.ToUInt32("4041247484");



                float xCord = float.Parse("563.803894");
                float yCord = float.Parse("2440.105713");
                float zCord = float.Parse("278.4933777");

                IntPtr nada = IntPtr.Zero;

                string test = "563.803894";
                 
                //IntPtr xaddr = 0xF0E08AFC;

                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                //Byte[] bytes = Encoding.GetBytes(test);
                 * */
                //WriteFloat(memory.hProc, "4041247484", 
                //static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, out IntPtr lpNumberOfBytesWritten);
                //WriteProcessMemory(memory.hProc, , Buffer, Buffer.Length, out nada );
                //WriteProcessMemory(hand, (IntPtr)Address, data, (UIntPtr)data.Length, out bytesout);
                //ReadProcessMemory(memory.hProc, ptrtarget + target_x_offset, ref tgtxcord, 4, 0);

                /*
                byte[] x1Cord = BitConverter.GetBytes(float.Parse("563.803894"));
                byte[] y1Cord = BitConverter.GetBytes(float.Parse("2440.105713"));
                byte[] z1Cord = BitConverter.GetBytes(float.Parse("278.4933777"));
                byte[] x2Cord = BitConverter.GetBytes(float.Parse("563.803894"));
                byte[] y2Cord = BitConverter.GetBytes(float.Parse("2440.105713"));
                byte[] z2Cord = BitConverter.GetBytes(float.Parse("278.4933777"));
                byte[] walk = BitConverter.GetBytes(Convert.ToUInt32("2"));
                byte[] walk1 = BitConverter.GetBytes(Convert.ToUInt32("1"));
                
                
                WriteMe(memory.hProc, 0xF0E08AFC, x1Cord);
                WriteMe(memory.hProc, 0xF0E08B00, y1Cord);
                WriteMe(memory.hProc, 0xF0E08B04, z1Cord);
                WriteMe(memory.hProc, 0xF0E095B4, x2Cord);
                WriteMe(memory.hProc, 0xF0E095B8, y2Cord);
                WriteMe(memory.hProc, 0xF0E095BC, z2Cord);
                WriteMe(memory.hProc, 0xF0E08DA4, walk);
                WriteMe(memory.hProc, 0xF0E08AF8, walk1);

                 * */

                //timer1.Enabled = true;
                chbHealBot.CheckState = CheckState.Checked; //chbHealBot.Checked = true;

            //}
        }

        public void WriteMe(IntPtr app, uint mAddress, byte[] Buffer)
        {
            //Ignore me.. personal testing
            IntPtr broken = IntPtr.Zero;
            try
            {

                WriteProcessMemory(app, mAddress, Buffer, Buffer.Length, out broken);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public static void WriteFloat(IntPtr app, long Address, float value)
        {
            //personal use ignore
            byte[] buffer = BitConverter.GetBytes(value);
            //WriteProcessMemory(app, (UIntPtr)Address, buffer, (UIntPtr)buffer.Length, IntPtr.Zero);
        }
        public static void WriteInt(IntPtr app, long Address, int value)
        {
            //personal use ignore
            byte[] buffer = BitConverter.GetBytes(value);
            //WriteProcessMemory(pHandle, (UIntPtr)Address, buffer, (UIntPtr)buffer.Length, IntPtr.Zero);
        }
        public static void WriteUInt(IntPtr app, long Address, uint value)
        {
            //personal use ignore
            byte[] buffer = BitConverter.GetBytes(value);
            //WriteProcessMemory(pHandle, (UIntPtr)Address, buffer, (UIntPtr)buffer.Length, IntPtr.Zero);
        }



        static void healBotMReader()
        {
            // this is a seperate thread that performs a read then pauses for 200ms
            // I created a globals section so we didnt need to worry about thread synch
            // its a bit dirty but we stay clean and light and since this is being read > 4 
            // times a second only minor variations will occur. 
            int a = 1;
            while (a == 1)
            {
                if (memory.threadState == "run")
                {

                    //local defines
                    float lpX = 0;
                    float lpY = 0;
                    float lpZ = 0;
                    float lXcord = 0;
                    float lYcord = 0;
                    float lZcord = 0;
                    uint lpMPCurr = 0;
                    uint lpHPCurr = 0;
                    uint lpHPTot = 0;
                    uint lpMPTot = 0;
                    uint lMyMPCurr = 0;
                    uint lMyHPCurr = 0;
                    uint lMyHPTot = 0;
                    uint lMyMPTot = 0;
                    uint lplvl = 0;
                    //uint lcamrotate = 0;
                    byte[] lpName = new byte[32];
                    byte[] lmyName = new byte[32];
                    float lcampitch = 0;
                    float lcamrotate = 0;


                    //read values from memory
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x30, ref lpX, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x2C, ref lpY, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x34, ref lpZ, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x14, ref lpMPCurr, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0xC, ref lpHPCurr, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress + memory.Player_HP_Offset, ref lMyHPCurr, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress + memory.Player_MaxHP_Offset, ref lMyHPTot, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress + memory.Player_MP_Offset, ref lMyMPCurr, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress + memory.Player_MaxMP_Offset, ref lMyMPTot, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x3a, ref lplvl, 1, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x8, ref lpHPTot, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x10, ref lpMPTot, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x3f, lpName, 32, 0);

                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Cam_Rotate_Offset, ref lcamrotate, 4, 0);

                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_X_Offset, ref lXcord, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Y_Offset, ref lYcord, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Z_Offset, ref lZcord, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Cam_Pitch_Offset, ref lcampitch, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Cam_Rotate_Offset, ref lcamrotate, 4, 0);


                    //Check to see if address is valid
                    //Should probably find a better test

                    //write local values to global memory for use in other threads
                    memory.pX = lpX;
                    memory.pY = lpY;
                    memory.pZ = lpZ;
                    memory.Xcord = lXcord;
                    memory.Ycord = lYcord;
                    memory.Zcord = lZcord;
                    memory.pMPCurr = lpMPCurr;
                    memory.pHPCurr = lpHPCurr;
                    memory.pHPTot = lpHPTot;
                    memory.pMPTot = lpMPTot;
                    memory.plvl = lplvl.ToString();
                    memory.MyHPTot = lMyHPTot;
                    memory.MyHPCurr = lMyHPCurr;
                    memory.MyMPTot = lMyMPTot;
                    memory.MyMPCurr = lMyMPCurr;
                    memory.normDirection = normalize((int)lcamrotate);
                    memory.pName = getName(lpName);

                    //Determine Percentages, yeah I dont want to do a round here but its needed
                    //as I am using % eval in heal calcs which do not want to wait for main form
                    //timer to complete
                    float inta = ((float)memory.pMPTot);
                    float intb = ((float)memory.pMPCurr);
                    float intc = ((float)memory.pHPTot);
                    float intd = ((float)memory.pHPCurr);
                    float inte = ((float)memory.MyHPTot);
                    float intf = ((float)memory.MyHPCurr);
                    float intg = ((float)memory.MyMPTot);
                    float inth = ((float)memory.MyMPCurr);


                    memory.myMPPer = (int)Math.Round((inth / intg * 100));
                    memory.myHPPer = (int)Math.Round((intf / inte * 100));
                    memory.partyHPPer = (int)Math.Round((intd / intc * 100));
                    memory.partyMPPer = (int)Math.Round((intb / inta * 100));



                    //give the read a break
                    Thread.Sleep(100);
                }
                //thread is disabled... patiently wait for it to enable again
                Thread.Sleep(1000);
            }
            
        }

        public static string getName(byte[] playerName)
        {
            //string name = "";

            char[] chars = new char[playerName.Length / sizeof(char)];
            System.Buffer.BlockCopy(playerName, 0, chars, 0, playerName.Length);

            string name = new string(chars);

            return name;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Very simply this timer is the refresh rate of data displayed on the winform. I slowed this down a bit

            
            if (memory.finalParty1 == 0 || memory.partyHPPer < 0 || memory.pMPTot > 3000000)
            {
                //if this happens, the player isnt in a group... continue as normal and refresh the pointers
                pointerScan("party");
                //msgBox.Text = System.Environment.TickCount.ToString() + " (10) Cannot Find Party" + Environment.NewLine + msgBox.Text;
            }
            if (memory.myHPPer < 0)
            {
                //this means we arent getting player information and something is wrong... stop bot, notify user
                timer1.Enabled = false;
                memory.threadState = "";
                dgSkills.Enabled = true;
                msgBox.Text = System.Environment.TickCount.ToString() + " (12) Bot stopped: cant find your information" + Environment.NewLine + msgBox.Text;
                return;
            }

            try
            {
                txtLevel.Text = memory.plvl.ToString();
                txtMPCurrent.Text = memory.pMPCurr.ToString();
                txtHPCurrent.Text = memory.pHPCurr.ToString();
                txtX.Text = memory.pX.ToString();
                txtY.Text = memory.pY.ToString();
                txtZ.Text = memory.pZ.ToString();
                txtHPTotal.Text = memory.pHPTot.ToString();
                txtMPTot.Text = memory.pMPTot.ToString();
                txtHPPer.Text = memory.partyHPPer.ToString();
                txtName.Text = memory.pName;

                if (Convert.ToInt32(txtHPPer.Text) > 0)
                {
                    pbHP.Value = Convert.ToInt16(txtHPPer.Text);
                }
                txtMPPer.Text = memory.partyMPPer.ToString();
                if (Convert.ToInt32(txtMPPer.Text) > 0)
                {
                    pbMP.Value = Convert.ToInt32(txtMPPer.Text);

                }


                txtMyHPPer.Text = memory.myHPPer.ToString();
                if (Convert.ToInt32(txtMyHPPer.Text) > 0)
                {
                    pbMyHP.Value = Convert.ToInt16(txtMyHPPer.Text);
                }
                txtMyMPPer.Text = memory.myMPPer.ToString();
                if (Convert.ToInt32(txtMyMPPer.Text) > 0)
                {
                    pbMyMP.Value = Convert.ToInt32(txtMyMPPer.Text);

                }

                txtDistToPart.Text = distanceTo(memory.pX, memory.pY, memory.pZ, memory.Xcord, memory.Ycord, memory.Zcord).ToString();
            }
            catch
            {
                pointerScan("party");
                msgBox.Text = System.Environment.TickCount.ToString() + " (11) Cannot Find Party" + Environment.NewLine + msgBox.Text;
                return;
            }
                

            determineState();
            

        }

        private void chbHealBot_CheckedChanged(object sender, EventArgs e)
        {
            //enable/disable all functionality of the bot by startin/stopping the timer and thread
            if (chbHealBot.CheckState == CheckState.Checked)
            {
                timer1.Enabled = true;
                memory.threadState = "run";
                memory.walkAct = false;
                dgSkills.Enabled = false;
                
                //.Start()
            }
            else
            {
                timer1.Enabled = false;
                memory.threadState = "";
                memory.walkAct = false;
                dgSkills.Enabled = true;
                //healBotThread.Abort();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //button2.PerformClick();
            
        }

       
        static int distanceTo(float x1, float y1, float z1, float x2, float y2, float z2)
        {

            //Get Distance between point 1 and 2
            //I know this is much faster using multiplication
            //Fixme when you have time
            float xd = 0;
            float yd = 0;
            float zd = 0;
            float math = 0;
            
            xd = x1 - x2;
            yd = y1 - y2;
            zd = z1 - z2;


            try
            {
                math = (float)Math.Sqrt(xd * xd + yd * yd + zd * zd);
                memory.Distance = (int)Math.Round(math);

                if (memory.Distance > -1)
                {
                    return memory.Distance;
                }
            }

            catch
            {
            }

            return -1;
        }

        static int normalize(int facialDirection)
        {
            // convert the -180 to +180 rotation to true direction meaning 0 degrees is north for other calculations
            double normalfacialdirection = 0;
            /*try
            {
                normalfacialdirection = facialDirection + 180;

                return (int)normalfacialdirection;
            }
            catch
            {
                return -1;
            }
             */

            try
            {

                if (facialDirection > 0)
                {
                    normalfacialdirection = 270 - facialDirection;
                    return (int)normalfacialdirection;
                }
                else
                {
                    if (Math.Abs(facialDirection) < 90)
                    {
                        normalfacialdirection = Math.Abs(facialDirection) + 270;
                        return (int)normalfacialdirection;
                    }
                    else
                    {
                        normalfacialdirection = Math.Abs(facialDirection) - 90;
                        return (int)normalfacialdirection;
                    }
                }
            }
            catch
            {
                return -1;
            }

        }

        static int directionToTarget(float originX, float originY, float destinationX, float destinationY)
        {
            double radians = 0;

            if (originX > destinationX && originY > destinationY)
            {
                radians = (Math.Atan((originY - destinationY) / (originX - destinationX))) * (180 / Math.PI) + 270;
            }
            else if (originX < destinationX && originY < destinationY)
            {
                radians = (Math.Atan((originY - destinationY) / (originX - destinationX))) * (180 / Math.PI) + 90;
            }
            else if (originX > destinationX && originY < destinationY)
            {
                //
                radians = (Math.Atan((originX - destinationX) / (originY - destinationY) * -1)) * (180 / Math.PI) + 180;
            }
            else if (originX < destinationX && originY > destinationY)
            {
                radians = (Math.Atan((originX - destinationX) / (originY - destinationY) * -1)) * (180 / Math.PI);
            }

            /*
            if (originX > destinationX && originY > destinationY)
            {
                radians = (Math.Atan((originX - destinationX) / (originY - destinationY))) * (180 / Math.PI) + 180;
            }
            else if (originX < destinationX && originY < destinationY)
            {
                radians = (Math.Atan((originX - destinationX) / (originY - destinationY))) * (180 / Math.PI);
            }
            else if (originX > destinationX && originY < destinationY)
            {
                //
                radians = (Math.Atan((originY - destinationY) / (originX - destinationX) * -1)) * (180 / Math.PI) + 270;
            }
            else if (originX < destinationX && originY > destinationY)
            {
                radians = (Math.Atan((originY - destinationY) / (originX - destinationX) * -1)) * (180 / Math.PI) + 90;
            }
            */

            return (int)radians;
        }


        static void navigateTo(float x, float y, float z, int distBehind, float myZ)
        {
            double newX = 0;
            double newY = 0;
            double newZ = 0;


            int facialDirection = memory.normDirection;

            //This is the actual point in space -5 from wire your walk to functionality here (height cord is simply the difference between the current and actual)
            // the z cord is simply evenly the difference between player and party member as we are in a 3d plane at small dist, it should be close.
            if (facialDirection < 90)
            {
                newY = (double)y - (distBehind * (Math.Sin(((double)90 - (double)facialDirection) * Math.PI / 180)));
                newX = (double)x - (distBehind * (Math.Sin(((double)facialDirection) * Math.PI / 180)));
                newZ = (z + myZ) / 2; //hack
            }
            else if (facialDirection < 180)
            {
                newY = (double)y + (distBehind * (Math.Sin(((double)facialDirection - (double)90) * Math.PI / 180)));
                newX = (double)x - (distBehind * (Math.Sin(((double)180 - (double)facialDirection) * Math.PI / 180)));
                newZ = (z + myZ) / 2; //hack
            }
            else if (facialDirection < 270)
            {
                newY = (double)y + (distBehind * (Math.Sin(((double)270 - (double)facialDirection) * Math.PI / 180)));
                newX = (double)x + (distBehind * (Math.Sin(((double)facialDirection - (double)180) * Math.PI / 180)));
                newZ = (z + myZ) / 2; //hack
            }
            else if (facialDirection < 360)
            {
                newY = (double)y - (distBehind * (Math.Sin(((double)360 - (double)facialDirection) * Math.PI / 180)));
                newX = (double)x + (distBehind * (Math.Sin(((double)facialDirection - (double)270) * Math.PI / 180)));
                newZ = (z + myZ) / 2; //hack
            }

            //just for testing
            memory.dest_X = (float)newX;
            memory.dest_Y = (float)newY;
            memory.dest_Z = (float)newZ;
            MessageBox.Show("Congrats, your new x should be " + newX.ToString() + " and y: " + newY.ToString() + " and z: " + newZ.ToString());
        }

        private void changeTarget()
        {

        }

        private void determineState()//applyLogic()
        {
            //msgBox.Text = System.Environment.TickCount.ToString() + " (i) Enter Determine State" + Environment.NewLine + msgBox.Text;
            string stype = "";
            string target = "";
            string condition = "";
            int value = 0;
            string key = "";
            bool chain = false;
            int cast = 0;
            int cooldown = 0;



            if (memory.Distance > Convert.ToInt16(txtMaxDist.Text))
            {
                if (memory.Distance < Convert.ToInt32(txtMaxDistance.Text))
                {
                    //remove all this sendkey shit when you wire up walking
                    if (GetForegroundWindow() != System.Diagnostics.Process.GetProcessById((int)memory.currentPID).MainWindowHandle)
                    {
                        SetForegroundWindow(System.Diagnostics.Process.GetProcessById((int)memory.currentPID).MainWindowHandle);
                        System.Threading.Thread.Sleep(250);
                    }
                    //walk damnit
                    if (memory.de_bug == true)
                    {
                        //msgBox.Text = "Too Far: Current dist is " + memory.Distance.ToString() + " max distance is " + txtMaxDist.ToString() + Environment.NewLine + msgBox.Text;
                    }
                    msgBox.Text = System.Environment.TickCount.ToString() + " Start Walk" + Environment.NewLine + msgBox.Text;
                    memory.walkAct = true;
                    //walk(memory.pX,memory.pY,memory.pZ,5);
                    return;
                }
            }


            //Do every check to determine what is most important
            if (!memory.walkAct)
            {
                for (int rows = 0; rows < (dgSkills.Rows.Count - 1); rows++)
                {

                    for (int col = 0; col < dgSkills.Rows[rows].Cells.Count; col++)
                    {
                        //populate local var
                        try
                        {
                            stype = dgSkills.Rows[rows].Cells[0].Value.ToString();
                            target = dgSkills.Rows[rows].Cells[1].Value.ToString();
                            condition = dgSkills.Rows[rows].Cells[2].Value.ToString();
                            value = Convert.ToInt32(dgSkills.Rows[rows].Cells[3].Value.ToString());
                            key = dgSkills.Rows[rows].Cells[4].Value.ToString();
                            chain = Convert.ToBoolean(dgSkills.Rows[rows].Cells[5].FormattedValue.ToString());
                            cast = Convert.ToInt32(dgSkills.Rows[rows].Cells[6].Value.ToString());
                            cooldown = Convert.ToInt32(dgSkills.Rows[rows].Cells[7].Value.ToString());
                        }
                        catch
                        {

                            timer1.Enabled = false;
                            //healBotThread.Abort();
                            memory.threadState = "";
                            chbHealBot.Checked = false;
                            MessageBox.Show("You have added an invalid value in the Skill List");
                            dgSkills.Enabled = true;
                            return;
                        }

                        //apply logic here

                        //heal
                        if (chbHealBot.Checked)
                        {
                            try
                            {
                                switch (stype)
                                {
                                    case "Heal":
                                        if (target == "Self")
                                        {
                                            //self
                                            if (condition == "HP")
                                            {
                                                if (memory.myHPPer < value && timers[key] < System.Environment.TickCount)
                                                {
                                                    //HP < Value and Cooldown expired then press Key
                                                    //casting(target, key, chain, cast, cooldown, 0);
                                                    memory.castingCasttime = cast;
                                                    memory.castingChain = chain;
                                                    memory.castingChainTiers = 0;
                                                    memory.castingCooldown = cooldown;
                                                    memory.castingKey = key;
                                                    memory.castingTarget = target;
                                                    return;

                                                }
                                            }
                                            if (condition == "MP")
                                            {
                                                if (memory.myMPPer < value && timers[key] < System.Environment.TickCount)
                                                {
                                                    //MP < Value and Cooldown expired then press Key
                                                    //casting(target, key, chain, cast, cooldown, 0);
                                                    memory.castingCasttime = cast;
                                                    memory.castingChain = chain;
                                                    memory.castingChainTiers = 0;
                                                    memory.castingCooldown = cooldown;
                                                    memory.castingKey = key;
                                                    memory.castingTarget = target;
                                                    return;
                                                }
                                            }
                                            //return;
                                        }
                                        if (target == "Party")
                                        {
                                            //Party
                                            if (memory.Distance < Convert.ToInt32(txtMaxDistance.Text))
                                            {
                                                if (condition == "HP")
                                                {
                                                    if (memory.partyHPPer < value && timers[key] < System.Environment.TickCount)
                                                    {
                                                        //HP < Value and Cooldown expired then press Key
                                                        //casting(target, key, chain, cast, cooldown, 0);
                                                        memory.castingCasttime = cast;
                                                        memory.castingChain = chain;
                                                        memory.castingChainTiers = 0;
                                                        memory.castingCooldown = cooldown;
                                                        memory.castingKey = key;
                                                        memory.castingTarget = target;
                                                        return;

                                                    }
                                                }
                                                if (condition == "MP")
                                                {
                                                    if (memory.partyMPPer < value && timers[key] < System.Environment.TickCount)
                                                    {
                                                        //MP < Value and Cooldown expired then press Key
                                                        //casting(target, key, chain, cast, cooldown, 0);
                                                        memory.castingCasttime = cast;
                                                        memory.castingChain = chain;
                                                        memory.castingChainTiers = 0;
                                                        memory.castingCooldown = cooldown;
                                                        memory.castingKey = key;
                                                        memory.castingTarget = target;
                                                        return;
                                                    }
                                                }
                                            }
                                            //return;
                                        }
                                        break;
                                    case "Buff":
                                        if (stype == "Buff")
                                        {
                                            //buff
                                            if (target == "Self")
                                            {
                                                //self
                                                if (timers[key] < System.Environment.TickCount)
                                                {
                                                    //Cooldown expired then press Key
                                                    //casting(target, key, chain, cast, cooldown, 0);
                                                    memory.castingCasttime = cast;
                                                    memory.castingChain = chain;
                                                    memory.castingChainTiers = 0;
                                                    memory.castingCooldown = cooldown;
                                                    memory.castingKey = key;
                                                    memory.castingTarget = target;
                                                    return;
                                                }
                                            }
                                            if (target == "Party")
                                            {
                                                //Party
                                                if (timers[key] < System.Environment.TickCount)
                                                {
                                                    //Cooldown expired 
                                                    if (memory.Distance < Convert.ToInt32(txtMaxDistance.Text))
                                                    {
                                                        //if distance < 20
                                                        //casting(target, key, chain, cast, cooldown, 0);
                                                        memory.castingCasttime = cast;
                                                        memory.castingChain = chain;
                                                        memory.castingChainTiers = 0;
                                                        memory.castingCooldown = cooldown;
                                                        memory.castingKey = key;
                                                        memory.castingTarget = target;
                                                        return;
                                                    }
                                                }
                                            }
                                            //return;
                                        }
                                        break;
                                    case "Assist":
                                        if (stype == "Assist")
                                        {
                                            if (chbAssist.Checked)
                                            {
                                                if (timers[key] < System.Environment.TickCount)
                                                {
                                                    //Cooldown expired 
                                                    //if (memory.Distance < Convert.ToInt32(txtMaxDistance.Text))
                                                    //{
                                                    //if distance < 20
                                                    //casting(target, key, chain, cast, cooldown, 0);
                                                    memory.castingCasttime = cast;
                                                    memory.castingChain = chain;
                                                    memory.castingChainTiers = 0;
                                                    memory.castingCooldown = cooldown;
                                                    memory.castingKey = key;
                                                    memory.castingTarget = target;
                                                    //Thread.Sleep(1600 - cooldown);
                                                    //}
                                                    return;
                                                }
                                            }
                                        }
                                        break;

                                }
                            }


                            catch
                            {
                                //return;
                            }
                        }
                    }
                }
            }
        }

        static void fixRotation()//float destX, float destY, float destZ, int targetAngle, int rotation)
        {
            //float liveRot = 0;
            int holdTime = 0;
            float lXcord = 0;
            float lYcord = 0;
            int lnormDirection = 0;
            float lcamrotate = 0;
            int rotDeg = 0;
            int targetAngle = 0;
            float destX = 0;
            float destY = 0;


            //ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Cam_Rotate_Offset, ref liveRot, 4, 0);
            ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_X_Offset, ref lXcord, 4, 0);
            ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Y_Offset, ref lYcord, 4, 0);
            ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Cam_Rotate_Offset, ref lcamrotate, 4, 0);
            ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x30, ref destX, 4, 0);
            ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x2C, ref destY, 4, 0);
            targetAngle = directionToTarget(lXcord, lYcord, destX, destY);
            lnormDirection = normalize((int)lcamrotate);
            rotDeg = diffAngles(lnormDirection, targetAngle);
            //rotation = Math.Abs(lnormDirection - targetAngle);
            



            while (rotDeg > 4)
            {
                targetAngle = directionToTarget(lXcord, lYcord, destX, destY);

                if (rotDeg > 50)
                {
                    holdTime = 60;
                }
                else if (rotDeg > 20)
                {
                    holdTime = 30;
                }
                else if (rotDeg > 5)
                {
                    holdTime = 10;
                }
                else if (rotDeg > 2)
                {
                    holdTime = 5;
                }

                if (turnLeft(targetAngle, lnormDirection))
                {
                    //left 
                    holdkey(VirtualKeyCode.VK_A, holdTime);
                }
                else
                {
                    //right
                    holdkey(VirtualKeyCode.VK_D, holdTime);
                }

                Thread.Sleep(10);

                ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Cam_Rotate_Offset, ref lcamrotate, 4, 0);
                lnormDirection = normalize((int)lcamrotate);
                rotDeg = diffAngles(lnormDirection, targetAngle);
                
            }
        }

        static bool turnLeft(int targetAngle, int lnormDirection)
        {
            if ((targetAngle - lnormDirection) > 180)
            {
                return true;
                //left
            }
            else if ((targetAngle - lnormDirection) < 0 && (targetAngle - lnormDirection) > -180)
            {
                return true;
                //left

            }
            else
            {
                return false;
                //right
            }
        }

        static int diffAngles(int firstAngle, int secondAngle)
        {
            double difference = secondAngle - firstAngle;
            while (difference < -180) difference += 360;
            while (difference > 180) difference -= 360;
            return (int)Math.Abs(difference);
        }

        static void walk()
        {
            int dist = 5;
            int walkDist = 0;
            int rotation = 0;
            int targetAngle = 0;
            float lXcord = 0;
            float lYcord = 0;
            float lZcord = 0;
            int a = 1;
            float destX = 0;
            float destY = 0;
            float destZ = 0;

            while (a == 1)
            {
                if (memory.walkAct)
                {
                    if (GetForegroundWindow() != System.Diagnostics.Process.GetProcessById((int)memory.currentPID).MainWindowHandle)
                    {
                        SetForegroundWindow(System.Diagnostics.Process.GetProcessById((int)memory.currentPID).MainWindowHandle);
                        System.Threading.Thread.Sleep(250);
                    }

                    //get player xyz and where I should be

                    //find the distance
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_X_Offset, ref lXcord, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Y_Offset, ref lYcord, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Z_Offset, ref lZcord, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x30, ref destX, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x2C, ref destY, 4, 0);
                    ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x34, ref destZ, 4, 0);

                    walkDist = distanceTo(lXcord, lYcord, memory.Zcord, destX, destY, destZ);


                    //if where I should be is less than 2m away do nada

                    if (walkDist < 6)
                    {
                        memory.walkAct = false;
                    }
                    else
                    {

                        //Find difference between current angle and angle I need to walk
                        //lXcord = memory.Xcord;
                        //lXcord = memory.Xcord;
                        //lZcord = memory.Zcord;
                        targetAngle = directionToTarget(lXcord, lYcord, destX, destY);

                        //temp1 = Math.Abs(memory.normDirection);
                        //temp2 = Math.Abs(targetAngle);
                        rotation = Math.Abs(memory.normDirection - targetAngle); //(360 - memory.normDirection + targetAngle);

                        fixRotation();

                        //if rotation > 360)
                        keyDown(VirtualKeyCode.VK_W);

                        int rotCount = 0;

                        while ((distanceTo(lXcord, lYcord, memory.Zcord, destX, destY, destZ)) > dist && memory.walkAct)
                        {
                            ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_X_Offset, ref lXcord, 4, 0);
                            ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Y_Offset, ref lYcord, 4, 0);
                            ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Z_Offset, ref lZcord, 4, 0);
                            ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x30, ref destX, 4, 0);
                            ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x2C, ref destY, 4, 0);
                            ReadProcessMemory(memory.hProc, memory.finalParty1 + 0x34, ref destZ, 4, 0);
                            if (rotCount > 3)
                            {
                                //keyUp(VirtualKeyCode.VK_W);
                                fixRotation();
                                //walkAdjust();
                                rotCount = 0;
                                //keyDown(VirtualKeyCode.VK_W);
                                //ReadProcessMemory(memory.hProc, memory.playerInfoAddress - memory.Player_Z_Offset, ref lZcord, 4, 0);
                                //do nothing
                            }
                            Thread.Sleep(175);
                            rotCount++;
                        }
                        keyUp(VirtualKeyCode.VK_W);
                        memory.walkAct = false;

                        //while (Math.Abs(memory.normDirection - targetAngle) > 5)
                        //while (rotation > 5)



                        //Rotate until facing proper direction

                        //Walk 
                    }
                }
                Thread.Sleep(100);
            }
        }

        static void casting()//string target, string key, bool chain, int casttime, int cooldown, int chainTiers)
        {
            bool a = true;
            uint lptrtarget = 0;
            uint lptrtargetinfo = 0;
            uint ltgthp = 0;
            uint ltgthpmax = 0;
            int targetHealthPer;
            uint tmpptrtarget = 0;

            while (a)
            {
                if (memory.castingTarget != "" && memory.castingTarget != null)
                {

                    if (timers[memory.castingKey] < System.Environment.TickCount)
                    {


                        //ReadProcessMemory(memory.hProc, ptrtarget + target_x_offset, ref tgtxcord, 4, 0);
                        //ReadProcessMemory(memory.hProc, ptrtarget + target_y_offset, ref tgtycord, 4, 0);
                        //ReadProcessMemory(memory.hProc, ptrtarget + target_z_offset, ref tgtzcord, 4, 0);

                        //remove all this sendkey shit when you wire up walking

                            if (GetForegroundWindow() != System.Diagnostics.Process.GetProcessById((int)memory.currentPID).MainWindowHandle)
                            {
                                SetForegroundWindow(System.Diagnostics.Process.GetProcessById((int)memory.currentPID).MainWindowHandle);
                                System.Threading.Thread.Sleep(250); //tempkill
                            }

                            timers[memory.castingKey] = System.Environment.TickCount + memory.castingCooldown;
                            //lookup vkeycode to make it passable... yup i was lazy and not much time
                            VirtualKeyCode kkkey = (VirtualKeyCode)System.Enum.Parse(typeof(VirtualKeyCode), memory.castingKey);
                            VirtualKeyCode kktarget = VirtualKeyCode.F1;

                            if (memory.castingTarget == "Party")
                            {
                                kktarget = VirtualKeyCode.F2;
                            }
                            if (memory.castingTarget == "P1~")
                            {
                                // here I am going to select party one first, then set kktarget to ~
                                sendkey(VirtualKeyCode.F2);
                                //System.Threading.Thread.Sleep(500); //tempkill
                                Thread.Sleep(50);
                                kktarget = VirtualKeyCode.OEM_3;
                                //Thread.Sleep(50);

                            }

                            sendkey(kktarget);
                            //System.Threading.Thread.Sleep(500); //tempkill
                            //Thread.Sleep(400);

                            if (memory.castingTarget == "P1~")
                            {
                                Thread.Sleep(800);
                            }

                            //never changing
                            tmpptrtarget = (memory.playerInfoAddress - memory.target_baseptr_offset);

                            //changing
                            ReadProcessMemory(memory.hProc, tmpptrtarget, ref lptrtarget, 4, 0);
                            ReadProcessMemory(memory.hProc, lptrtarget + memory.target_infoptr_offset, ref lptrtargetinfo, 4, 0);
                            ReadProcessMemory(memory.hProc, lptrtargetinfo + memory.target_hp_offset, ref ltgthp, 4, 0);
                            ReadProcessMemory(memory.hProc, lptrtargetinfo + memory.target_hpmax_offset, ref ltgthpmax, 4, 0);

                            targetHealthPer = (int)Math.Round(((double)ltgthp / (double)ltgthpmax * 100));

                            if (targetHealthPer > 1 && targetHealthPer < 100)
                            {

                            sendkey(kkkey);
                            //Thread.Sleep(100);
                            //System.Threading.Thread.Sleep(500); //tempkill
                            sendkey(kkkey); //sending a second time for shits and giggles

                            if (memory.castingChain == true)
                            {
                                //heal chain
                                System.Threading.Thread.Sleep(3600);
                                sendkey(kkkey);
                                //msgBox.Text = System.Environment.TickCount.ToString() + " (4) Heal Chain 1" + Environment.NewLine + msgBox.Text;
                                System.Threading.Thread.Sleep(200);
                                sendkey(kkkey);
                                //msgBox.Text = System.Environment.TickCount.ToString() + " (5) Heal Chain 2" + Environment.NewLine + msgBox.Text;
                                System.Threading.Thread.Sleep(200);
                                sendkey(kkkey);
                                //msgBox.Text = System.Environment.TickCount.ToString() + " (6) Heal Chain 3" + Environment.NewLine + msgBox.Text;
                                System.Threading.Thread.Sleep(200);
                                sendkey(kkkey);
                                //msgBox.Text = System.Environment.TickCount.ToString() + " (7) Heal Chain 4" + Environment.NewLine + msgBox.Text;
                            }
                            //pause for casting
                            Thread.Sleep(memory.castingCasttime);

                            //start timer
                            //string temp = timers[key].ToString();

                            //string temp2 = timers[key].ToString();
                            //Cast time  - pause for casting + 100 should be the timer value


                            //im done healing... follow again
                            //walk(memory.pX, memory.pY, memory.pZ, 5);

                            //}
                            //lastTarget = memory.castingTarget;
                        }
                            memory.castingCasttime = 0;
                            memory.castingChain = false;
                            memory.castingChainTiers = 0;
                            memory.castingCooldown = 0;
                            memory.castingKey = "";
                            memory.castingTarget = "";
                        
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void skill(string skill)
        {

        }

        //private void assist(

        static void sendkey(VirtualKeyCode key)
        {
            //SetForegroundWindow(System.Diagnostics.Process.GetProcessById(6068).MainWindowHandle);
            InputSimulator.SimulateKeyPress(key);
            //msgBox.Text = System.Environment.TickCount.ToString() + " sent key " + key.ToString() + Environment.NewLine + msgBox.Text;
        }

        static void holdkey(VirtualKeyCode key, int msLength)
        {
            //remove all this sendkey shit when you wire up walking
            //SetForegroundWindow(System.Diagnostics.Process.GetProcessById(6068).MainWindowHandle);
            if (InputSimulator.IsKeyDown(key))
            {
                //then do nothing
                Thread.Sleep(msLength);
                InputSimulator.SimulateKeyUp(key);
                return;
            }
            InputSimulator.SimulateKeyDown(key);

            //msgBox.Text = System.Environment.TickCount.ToString() + " (k1) holdkey " + key.ToString() + Environment.NewLine + msgBox.Text;
            Thread.Sleep(msLength);
            InputSimulator.SimulateKeyUp(key);
            
        }
        static void keyDown(VirtualKeyCode key)
        {
            //remove all this sendkey shit when you wire up walking
            //SetForegroundWindow(System.Diagnostics.Process.GetProcessById(6068).MainWindowHandle);
            if (InputSimulator.IsKeyDown(key))
            {
                InputSimulator.SimulateKeyUp(key);
                Thread.Sleep(100);
            }
            InputSimulator.SimulateKeyDown(key);

            //msgBox.Text = System.Environment.TickCount.ToString() + " (k1) KeyDown" + Environment.NewLine + msgBox.Text;
            Thread.Sleep(50);
            //InputSimulator.SimulateKeyUp(key);

        }
        static void keyUp(VirtualKeyCode key)
        {
            //remove all this sendkey shit when you wire up walking
            //SetForegroundWindow(System.Diagnostics.Process.GetProcessById(6068).MainWindowHandle);
            if (InputSimulator.IsKeyDown(key))
            {
                InputSimulator.SimulateKeyUp(key);
            }
            //InputSimulator.SimulateKeyDown(key);

            //msgBox.Text = System.Environment.TickCount.ToString() + " (k1) KeyDown" + Environment.NewLine + msgBox.Text;
            Thread.Sleep(100);
            //InputSimulator.SimulateKeyUp(key);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this is just testing
            //navigateTo((float)5.196,(float)3,218,60,10,(float)222.14);
            //walk(memory.pX, memory.pY, memory.pZ, 5);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close thread or no clean exit
            healBotThread.Abort();
            walkThread.Abort();
            castingThread.Abort();
            

            //save settings
            saveSettings();
        }

        private void cmbDll_SelectedIndexChanged(object sender, EventArgs e)
        {
            //remove when you port
            switchDll();
        }

        private void saveSettings()
        {
            string file= AppDomain.CurrentDomain.BaseDirectory + "\\settings.bin";
            using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
            {
                bw.Write(dgSkills.Columns.Count);
                bw.Write(dgSkills.Rows.Count);
                foreach (DataGridViewRow dgvR in dgSkills.Rows)
                {
                    for (int j = 0; j < dgSkills.Columns.Count; ++j)
                    {
                        object val = dgvR.Cells[j].Value;
                        if (val == null)
                        {
                            bw.Write(false);
                            bw.Write(false);
                        }
                        else
                        {
                            bw.Write(true);
                            bw.Write(val.ToString());
                        }
                    }
                }
            }
        }

        private void loadSettings()
        {
            dgSkills.Rows.Clear();
            string file = AppDomain.CurrentDomain.BaseDirectory + "\\settings.bin";
            if (File.Exists(file))
            {
                using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
                {
                    int n = bw.ReadInt32();
                    int m = bw.ReadInt32();
                    for (int i = 0; i < m; ++i)
                    {
                        dgSkills.Rows.Add();
                        for (int j = 0; j < n; ++j)
                        {
                            if (bw.ReadBoolean())
                            {
                                dgSkills.Rows[i].Cells[j].Value = bw.ReadString();
                            }
                            else bw.ReadBoolean();
                        }
                    }
                }

                for (int w = 0; w < dgSkills.RowCount; ++w)
                {
                    if (dgSkills.Rows[w].Cells[0].Value == null)
                    {
                        dgSkills.Rows.RemoveAt(w);
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRows = dgSkills.Rows.Count;
                int idx = dgSkills.SelectedCells[0].OwningRow.Index;
                if (idx == 0)
                    return;
                int col = dgSkills.SelectedCells[0].OwningColumn.Index;
                DataGridViewRowCollection rows = dgSkills.Rows;
                DataGridViewRow row = rows[idx];
                rows.Remove(row);
                rows.Insert(idx - 1, row);
                dgSkills.ClearSelection();
                dgSkills.Rows[idx - 1].Cells[col].Selected = true;

            }
            catch { }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRows = dgSkills.Rows.Count;
                int idx = dgSkills.SelectedCells[0].OwningRow.Index;
                if (idx == totalRows - 2)
                    return;
                int col = dgSkills.SelectedCells[0].OwningColumn.Index;
                DataGridViewRowCollection rows = dgSkills.Rows;
                DataGridViewRow row = rows[idx];
                rows.Remove(row);
                rows.Insert(idx + 1, row);
                dgSkills.ClearSelection();
                dgSkills.Rows[idx + 1].Cells[col].Selected = true;
            }
            catch { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgSkills.Rows.RemoveAt(dgSkills.SelectedCells[0].OwningRow.Index);
            }
            catch { };
        }



    }
}
