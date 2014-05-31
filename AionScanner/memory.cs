using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AionScanner
{
    public static class memory
    {
        public static IntPtr sProc { get; set; }
        public static IntPtr hProc { get; set; }
        //public IntPtr Handle { get; set; }
        //Anmont code: define pointer buildup
        public static bool de_bug { get; set; }
        public static uint p1Party1 { get; set; }
        public static uint p2Party1 { get; set; }
        public static uint p3Party1 { get; set; }
        public static uint p4Party1 { get; set; }
        public static uint p5Party1 { get; set; }
        public static uint finalParty1 { get; set; }
        public static uint playerInfoAddress { get; set; }
        public static float Xcord { get; set; } // Player xcord
        public static float Ycord { get; set; } // Player ycord
        public static float Zcord { get; set; } // Player zcord
        public static float campitch { get; set; }
        public static float camrotate { get; set; }
        public const uint Player_Y_Offset = 0x959C; // -
        public const uint Player_X_Offset = 0x9598; // -
        public const uint Player_Z_Offset = 0x9594; // -
        //public const uint Player_Y_Offset = 0x6478; // -
        //public const uint Player_X_Offset = 0x6474; // -
        //public const uint Player_Z_Offset = 0x6470; // -
        public static string plvl { get; set; }
        public static uint pMPTot { get; set; }
        public static uint pHPTot { get; set; }
        public static float pX { get; set; }
        public static float pY { get; set; }
        public static float pZ { get; set; }
        public static uint pHPCurr { get; set; }
        public static uint pMPCurr { get; set; }
        public static int Distance { get; set; }
        public static int partyHPPer { get; set; } 
        public static int partyMPPer  { get; set; }
        public static int State { get; set; }
        public const uint Player_MaxHP_Offset = 0x3C; // +
        public const uint Player_HP_Offset = 0x40; // +
        public const uint Player_MaxMP_Offset = 0x44; // +
        public const uint Player_MP_Offset = 0x48; // +
        public static uint MyHPTot { get; set; }
        public static uint MyHPCurr { get; set; }
        public static uint MyMPTot { get; set; }
        public static uint MyMPCurr { get; set; }
        public static int myHPPer { get; set; }
        public static int myMPPer { get; set; }
        public static string threadState { get; set; }
        public static int normDirection { get; set; }
        public static uint currentPID { get; set; }
        public static string pName { get; set; }
        public static string myName { get; set; }
        public const uint Cam_Pitch_Offset = 0x99C4; // -
        public const uint Cam_Rotate_Offset = 0x99BC;
        public static float dest_X { get; set; } // Player xcord
        public static float dest_Y { get; set; } // Player ycord
        public static float dest_Z { get; set; } // Player zcord
        public static bool walkAct { get; set; }
        public static string castingWalkAct { get; set; }
        public static string castingTarget { get; set; }
        public static string castingKey { get; set; }
        public static bool castingChain { get; set; }
        public static int castingCasttime { get; set; }
        public static int castingCooldown { get; set; }
        public static int castingChainTiers { get; set; }
        public const uint target_nameptr_offset = 0x3A; // +
        public const uint target_z_offset = 0x3C; // +
        public const uint target_x_offset = 0x38; // +
        public const uint target_y_offset = 0x34; // +
        public const uint target_hp_offset = 0x1228;
        public const uint target_hpmax_offset = 0x122C;
        public const uint target_baseptr_offset = 0x47F3E0; // -
        public const uint target_infoptr_offset = 0x254;

        

    }

}
