namespace AionScanner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pidBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chbHealBot = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgSkills = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Chain = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.castTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cooldown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chbAssist = new System.Windows.Forms.CheckBox();
            this.txtMaxDistance = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.txtMaxDist = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtMinDist = new System.Windows.Forms.TextBox();
            this.label112 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMyMPPer = new System.Windows.Forms.TextBox();
            this.txtMyHPPer = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.pbMyMP = new System.Windows.Forms.ProgressBar();
            this.pbMyHP = new System.Windows.Forms.ProgressBar();
            this.label118 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbMP = new System.Windows.Forms.ProgressBar();
            this.pbHP = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.txtMPPer = new System.Windows.Forms.TextBox();
            this.txtMPTot = new System.Windows.Forms.TextBox();
            this.txtMPCurrent = new System.Windows.Forms.TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.txtHPPer = new System.Windows.Forms.TextBox();
            this.txtHPTotal = new System.Windows.Forms.TextBox();
            this.txtHPCurrent = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.txtDistToPart = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.msgBox = new System.Windows.Forms.RichTextBox();
            this.cmbDll = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSkills)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(186, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Attach";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pidBox
            // 
            this.pidBox.FormattingEnabled = true;
            this.pidBox.Location = new System.Drawing.Point(12, 6);
            this.pidBox.Name = "pidBox";
            this.pidBox.Size = new System.Drawing.Size(115, 21);
            this.pidBox.TabIndex = 2;
            this.pidBox.Text = "Choose PID";
            this.pidBox.SelectedIndexChanged += new System.EventHandler(this.pidBox_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chbHealBot
            // 
            this.chbHealBot.AutoSize = true;
            this.chbHealBot.Location = new System.Drawing.Point(288, 8);
            this.chbHealBot.Name = "chbHealBot";
            this.chbHealBot.Size = new System.Drawing.Size(78, 17);
            this.chbHealBot.TabIndex = 168;
            this.chbHealBot.Text = "Enable Bot";
            this.chbHealBot.UseVisualStyleBackColor = true;
            this.chbHealBot.CheckedChanged += new System.EventHandler(this.chbHealBot_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.DimGray;
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(511, 338);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Healer";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgSkills);
            this.groupBox5.Location = new System.Drawing.Point(9, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(496, 247);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Self Logic (List in the order of importance. DEL key to delete)";
            // 
            // dgSkills
            // 
            this.dgSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSkills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Target,
            this.Condition,
            this.Value,
            this.Key,
            this.Chain,
            this.castTime,
            this.Cooldown});
            this.dgSkills.ContextMenuStrip = this.contextMenuStrip1;
            this.dgSkills.Location = new System.Drawing.Point(6, 17);
            this.dgSkills.Name = "dgSkills";
            this.dgSkills.Size = new System.Drawing.Size(484, 227);
            this.dgSkills.TabIndex = 145;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "Heal",
            "Buff",
            "Assist"});
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Type.Width = 56;
            // 
            // Target
            // 
            this.Target.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Target.HeaderText = "Target";
            this.Target.Items.AddRange(new object[] {
            "Party",
            "Self",
            "P1~"});
            this.Target.Name = "Target";
            this.Target.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Target.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Target.Width = 63;
            // 
            // Condition
            // 
            this.Condition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Condition.HeaderText = "Condition";
            this.Condition.Items.AddRange(new object[] {
            "HP",
            "MP",
            "Hit"});
            this.Condition.Name = "Condition";
            this.Condition.Width = 57;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Value.HeaderText = "< %";
            this.Value.MaxInputLength = 3;
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Value.Width = 30;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Items.AddRange(new object[] {
            "VK_1",
            "VK_2",
            "VK_3",
            "VK_4",
            "VK_5",
            "VK_6",
            "VK_7",
            "VK_8",
            "VK_9",
            "VK_0",
            "OEM_MINUS",
            "OEM_PLUS"});
            this.Key.Name = "Key";
            this.Key.Width = 52;
            // 
            // Chain
            // 
            this.Chain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Chain.HeaderText = "Chain";
            this.Chain.Name = "Chain";
            this.Chain.Width = 40;
            // 
            // castTime
            // 
            this.castTime.HeaderText = "Cast(ms)";
            this.castTime.Name = "castTime";
            this.castTime.Width = 65;
            // 
            // Cooldown
            // 
            this.Cooldown.HeaderText = "Cooldown(ms)";
            this.Cooldown.Name = "Cooldown";
            this.Cooldown.Width = 72;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chbAssist);
            this.groupBox4.Controls.Add(this.txtMaxDistance);
            this.groupBox4.Controls.Add(this.label138);
            this.groupBox4.Controls.Add(this.txtMaxDist);
            this.groupBox4.Controls.Add(this.label116);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.txtMinDist);
            this.groupBox4.Controls.Add(this.label112);
            this.groupBox4.Location = new System.Drawing.Point(8, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(452, 66);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Party Logic";
            // 
            // chbAssist
            // 
            this.chbAssist.AutoSize = true;
            this.chbAssist.Location = new System.Drawing.Point(151, 41);
            this.chbAssist.Name = "chbAssist";
            this.chbAssist.Size = new System.Drawing.Size(53, 17);
            this.chbAssist.TabIndex = 23;
            this.chbAssist.Text = "Assist";
            this.chbAssist.UseVisualStyleBackColor = true;
            // 
            // txtMaxDistance
            // 
            this.txtMaxDistance.Location = new System.Drawing.Point(415, 12);
            this.txtMaxDistance.Name = "txtMaxDistance";
            this.txtMaxDistance.Size = new System.Drawing.Size(31, 20);
            this.txtMaxDistance.TabIndex = 22;
            this.txtMaxDistance.Text = "50";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(347, 16);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(62, 13);
            this.label138.TabIndex = 21;
            this.label138.Text = "Max Range";
            // 
            // txtMaxDist
            // 
            this.txtMaxDist.Location = new System.Drawing.Point(310, 12);
            this.txtMaxDist.Name = "txtMaxDist";
            this.txtMaxDist.Size = new System.Drawing.Size(31, 20);
            this.txtMaxDist.TabIndex = 20;
            this.txtMaxDist.Text = "8";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(171, 15);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(133, 13);
            this.label116.TabIndex = 19;
            this.label116.Text = "Max distance before follow";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "auto defend if attacked";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtMinDist
            // 
            this.txtMinDist.Location = new System.Drawing.Point(137, 12);
            this.txtMinDist.Name = "txtMinDist";
            this.txtMinDist.Size = new System.Drawing.Size(31, 20);
            this.txtMinDist.TabIndex = 17;
            this.txtMinDist.Text = "6";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(6, 16);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(125, 13);
            this.label112.TabIndex = 9;
            this.label112.Text = "Distance between leader";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(12, 44);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(519, 364);
            this.tabControl2.TabIndex = 165;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(511, 338);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Party 1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtMyMPPer);
            this.groupBox6.Controls.Add(this.txtMyHPPer);
            this.groupBox6.Controls.Add(this.label120);
            this.groupBox6.Controls.Add(this.pbMyMP);
            this.groupBox6.Controls.Add(this.pbMyHP);
            this.groupBox6.Controls.Add(this.label118);
            this.groupBox6.Location = new System.Drawing.Point(6, 150);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(499, 60);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "My Info";
            // 
            // txtMyMPPer
            // 
            this.txtMyMPPer.Location = new System.Drawing.Point(308, 30);
            this.txtMyMPPer.Name = "txtMyMPPer";
            this.txtMyMPPer.Size = new System.Drawing.Size(71, 20);
            this.txtMyMPPer.TabIndex = 171;
            // 
            // txtMyHPPer
            // 
            this.txtMyHPPer.Location = new System.Drawing.Point(94, 30);
            this.txtMyHPPer.Name = "txtMyHPPer";
            this.txtMyHPPer.Size = new System.Drawing.Size(68, 20);
            this.txtMyHPPer.TabIndex = 170;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(226, 33);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(80, 13);
            this.label120.TabIndex = 170;
            this.label120.Text = "My MP Percent";
            // 
            // pbMyMP
            // 
            this.pbMyMP.ForeColor = System.Drawing.Color.RoyalBlue;
            this.pbMyMP.Location = new System.Drawing.Point(226, 19);
            this.pbMyMP.Name = "pbMyMP";
            this.pbMyMP.Size = new System.Drawing.Size(160, 11);
            this.pbMyMP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMyMP.TabIndex = 11;
            this.pbMyMP.Value = 50;
            // 
            // pbMyHP
            // 
            this.pbMyHP.ForeColor = System.Drawing.Color.Red;
            this.pbMyHP.Location = new System.Drawing.Point(9, 19);
            this.pbMyHP.Name = "pbMyHP";
            this.pbMyHP.Size = new System.Drawing.Size(160, 11);
            this.pbMyHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMyHP.TabIndex = 10;
            this.pbMyHP.Value = 50;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(10, 33);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(79, 13);
            this.label118.TabIndex = 169;
            this.label118.Text = "My HP Percent";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbMP);
            this.groupBox1.Controls.Add(this.pbHP);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label86);
            this.groupBox1.Controls.Add(this.txtDistToPart);
            this.groupBox1.Controls.Add(this.label77);
            this.groupBox1.Controls.Add(this.label76);
            this.groupBox1.Controls.Add(this.label74);
            this.groupBox1.Controls.Add(this.label72);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.txtLevel);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtZ);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 129);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leader Info";
            // 
            // pbMP
            // 
            this.pbMP.ForeColor = System.Drawing.Color.RoyalBlue;
            this.pbMP.Location = new System.Drawing.Point(226, 118);
            this.pbMP.Name = "pbMP";
            this.pbMP.Size = new System.Drawing.Size(160, 11);
            this.pbMP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMP.TabIndex = 33;
            this.pbMP.Value = 50;
            // 
            // pbHP
            // 
            this.pbHP.ForeColor = System.Drawing.Color.Red;
            this.pbHP.Location = new System.Drawing.Point(9, 118);
            this.pbHP.Name = "pbHP";
            this.pbHP.Size = new System.Drawing.Size(160, 11);
            this.pbHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbHP.TabIndex = 3;
            this.pbHP.Value = 50;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label100);
            this.groupBox3.Controls.Add(this.label101);
            this.groupBox3.Controls.Add(this.label102);
            this.groupBox3.Controls.Add(this.txtMPPer);
            this.groupBox3.Controls.Add(this.txtMPTot);
            this.groupBox3.Controls.Add(this.txtMPCurrent);
            this.groupBox3.Controls.Add(this.label106);
            this.groupBox3.Location = new System.Drawing.Point(226, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 56);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MP";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(6, 16);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(41, 13);
            this.label100.TabIndex = 18;
            this.label100.Text = "Current";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(53, 34);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(12, 13);
            this.label101.TabIndex = 11;
            this.label101.Text = "/";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(73, 16);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(31, 13);
            this.label102.TabIndex = 17;
            this.label102.Text = "Total";
            // 
            // txtMPPer
            // 
            this.txtMPPer.Enabled = false;
            this.txtMPPer.Location = new System.Drawing.Point(120, 31);
            this.txtMPPer.Name = "txtMPPer";
            this.txtMPPer.Size = new System.Drawing.Size(33, 20);
            this.txtMPPer.TabIndex = 20;
            // 
            // txtMPTot
            // 
            this.txtMPTot.Enabled = false;
            this.txtMPTot.Location = new System.Drawing.Point(70, 31);
            this.txtMPTot.Name = "txtMPTot";
            this.txtMPTot.Size = new System.Drawing.Size(44, 20);
            this.txtMPTot.TabIndex = 21;
            // 
            // txtMPCurrent
            // 
            this.txtMPCurrent.Enabled = false;
            this.txtMPCurrent.Location = new System.Drawing.Point(3, 31);
            this.txtMPCurrent.Name = "txtMPCurrent";
            this.txtMPCurrent.Size = new System.Drawing.Size(44, 20);
            this.txtMPCurrent.TabIndex = 22;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(131, 15);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(15, 13);
            this.label106.TabIndex = 25;
            this.label106.Text = "%";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label84);
            this.groupBox2.Controls.Add(this.label70);
            this.groupBox2.Controls.Add(this.label82);
            this.groupBox2.Controls.Add(this.txtHPPer);
            this.groupBox2.Controls.Add(this.txtHPTotal);
            this.groupBox2.Controls.Add(this.txtHPCurrent);
            this.groupBox2.Controls.Add(this.label92);
            this.groupBox2.Location = new System.Drawing.Point(9, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 56);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HP";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(6, 16);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(41, 13);
            this.label84.TabIndex = 18;
            this.label84.Text = "Current";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(53, 34);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(12, 13);
            this.label70.TabIndex = 11;
            this.label70.Text = "/";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(73, 16);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(31, 13);
            this.label82.TabIndex = 17;
            this.label82.Text = "Total";
            // 
            // txtHPPer
            // 
            this.txtHPPer.Enabled = false;
            this.txtHPPer.Location = new System.Drawing.Point(120, 31);
            this.txtHPPer.Name = "txtHPPer";
            this.txtHPPer.Size = new System.Drawing.Size(33, 20);
            this.txtHPPer.TabIndex = 20;
            // 
            // txtHPTotal
            // 
            this.txtHPTotal.Enabled = false;
            this.txtHPTotal.Location = new System.Drawing.Point(70, 31);
            this.txtHPTotal.Name = "txtHPTotal";
            this.txtHPTotal.Size = new System.Drawing.Size(44, 20);
            this.txtHPTotal.TabIndex = 21;
            // 
            // txtHPCurrent
            // 
            this.txtHPCurrent.Enabled = false;
            this.txtHPCurrent.Location = new System.Drawing.Point(3, 31);
            this.txtHPCurrent.Name = "txtHPCurrent";
            this.txtHPCurrent.Size = new System.Drawing.Size(44, 20);
            this.txtHPCurrent.TabIndex = 22;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(131, 15);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(15, 13);
            this.label92.TabIndex = 25;
            this.label92.Text = "%";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(429, 77);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(49, 13);
            this.label86.TabIndex = 19;
            this.label86.Text = "Distance";
            // 
            // txtDistToPart
            // 
            this.txtDistToPart.Enabled = false;
            this.txtDistToPart.Location = new System.Drawing.Point(432, 93);
            this.txtDistToPart.Name = "txtDistToPart";
            this.txtDistToPart.Size = new System.Drawing.Size(37, 20);
            this.txtDistToPart.TabIndex = 7;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(447, 19);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(14, 13);
            this.label77.TabIndex = 15;
            this.label77.Text = "Z";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(372, 19);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(14, 13);
            this.label76.TabIndex = 14;
            this.label76.Text = "Y";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(293, 19);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(14, 13);
            this.label74.TabIndex = 13;
            this.label74.Text = "X";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(356, 6);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(48, 13);
            this.label72.TabIndex = 12;
            this.label72.Text = "Location";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(115, 19);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(33, 13);
            this.label41.TabIndex = 10;
            this.label41.Text = "Level";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(9, 19);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(35, 13);
            this.label39.TabIndex = 9;
            this.label39.Text = "Name";
            // 
            // txtLevel
            // 
            this.txtLevel.Enabled = false;
            this.txtLevel.Location = new System.Drawing.Point(115, 35);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(44, 20);
            this.txtLevel.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(9, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtZ
            // 
            this.txtZ.Enabled = false;
            this.txtZ.Location = new System.Drawing.Point(420, 35);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(70, 20);
            this.txtZ.TabIndex = 2;
            // 
            // txtY
            // 
            this.txtY.Enabled = false;
            this.txtY.Location = new System.Drawing.Point(344, 35);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(70, 20);
            this.txtY.TabIndex = 1;
            // 
            // txtX
            // 
            this.txtX.Enabled = false;
            this.txtX.Location = new System.Drawing.Point(261, 35);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(77, 20);
            this.txtX.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.Controls.Add(this.msgBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(511, 338);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Log";
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(6, 6);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(499, 326);
            this.msgBox.TabIndex = 4;
            this.msgBox.Text = "Log";
            // 
            // cmbDll
            // 
            this.cmbDll.FormattingEnabled = true;
            this.cmbDll.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbDll.Location = new System.Drawing.Point(133, 6);
            this.cmbDll.Name = "cmbDll";
            this.cmbDll.Size = new System.Drawing.Size(47, 21);
            this.cmbDll.TabIndex = 171;
            this.cmbDll.Text = "1";
            this.cmbDll.SelectedIndexChanged += new System.EventHandler(this.cmbDll_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(386, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 172;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(540, 420);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbDll);
            this.Controls.Add(this.chbHealBot);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.pidBox);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Heal/Follow Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSkills)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox pidBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chbHealBot;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgSkills;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtMaxDistance;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.TextBox txtMaxDist;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtMinDist;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.ComboBox cmbDll;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtMyMPPer;
        private System.Windows.Forms.TextBox txtMyHPPer;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.ProgressBar pbMyMP;
        private System.Windows.Forms.ProgressBar pbMyHP;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pbMP;
        private System.Windows.Forms.ProgressBar pbHP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.TextBox txtMPPer;
        private System.Windows.Forms.TextBox txtMPTot;
        private System.Windows.Forms.TextBox txtMPCurrent;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TextBox txtHPPer;
        private System.Windows.Forms.TextBox txtHPTotal;
        private System.Windows.Forms.TextBox txtHPCurrent;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox txtDistToPart;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox msgBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewComboBoxColumn Target;
        private System.Windows.Forms.DataGridViewComboBoxColumn Condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewComboBoxColumn Key;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chain;
        private System.Windows.Forms.DataGridViewTextBoxColumn castTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cooldown;
        private System.Windows.Forms.CheckBox chbAssist;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

