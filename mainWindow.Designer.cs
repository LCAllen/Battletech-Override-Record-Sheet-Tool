namespace BORST
{
    partial class mainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGenerate = new Button();
            buttonBrowseMTF = new Button();
            textBoxMTF = new TextBox();
            buttonLoad = new Button();
            textBoxChassis = new TextBox();
            textBoxVariant = new TextBox();
            labelChassis = new Label();
            labelVariant = new Label();
            comboBoxMass = new ComboBox();
            labelMass = new Label();
            checkBoxOmni = new CheckBox();
            labelHeatSinks = new Label();
            textBoxHeatSinks = new TextBox();
            checkBoxDouble = new CheckBox();
            labelWalk = new Label();
            textBoxWalk = new TextBox();
            textBoxJump = new TextBox();
            labelJump = new Label();
            listBoxEquip = new ListBox();
            buttonAddEquip = new Button();
            listBoxWeapon = new ListBox();
            buttonAddWeapon = new Button();
            comboBoxArmor = new ComboBox();
            labelArmorType = new Label();
            comboBoxWeapons = new ComboBox();
            comboBoxEquipment = new ComboBox();
            comboBoxWeaponLoc = new ComboBox();
            comboBoxEquipLoc = new ComboBox();
            labelTechBase = new Label();
            textBoxTechBase = new TextBox();
            textBoxArmorHD = new TextBox();
            labelArmorHD = new Label();
            labelArmor = new Label();
            textBoxArmorLT = new TextBox();
            textBoxArmorLA = new TextBox();
            textBoxArmorRT = new TextBox();
            textBoxArmorLTR = new TextBox();
            textBoxArmorRTR = new TextBox();
            textBoxArmorRA = new TextBox();
            textBoxArmorCTR = new TextBox();
            textBoxArmorLL = new TextBox();
            textBoxArmorRL = new TextBox();
            labelArmorLT = new Label();
            labelArmorRT = new Label();
            labelArmorLTR = new Label();
            labelArmorRTR = new Label();
            textBoxArmorCT = new TextBox();
            labelArmorCT = new Label();
            labelArmorCTR = new Label();
            labelArmorLA = new Label();
            labelArmorRA = new Label();
            labelArmorRL = new Label();
            labelArmorLL = new Label();
            buttonRemoveEquipment = new Button();
            buttonRemoveWeapon = new Button();
            comboBoxEquipmentSubtype = new ComboBox();
            SuspendLayout();
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(973, 675);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(75, 23);
            buttonGenerate.TabIndex = 1;
            buttonGenerate.Text = "Generate";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // buttonBrowseMTF
            // 
            buttonBrowseMTF.Location = new Point(12, 12);
            buttonBrowseMTF.Name = "buttonBrowseMTF";
            buttonBrowseMTF.Size = new Size(75, 23);
            buttonBrowseMTF.TabIndex = 2;
            buttonBrowseMTF.Text = "Browse";
            buttonBrowseMTF.UseVisualStyleBackColor = true;
            buttonBrowseMTF.Click += buttonBrowseMTF_Click;
            // 
            // textBoxMTF
            // 
            textBoxMTF.Location = new Point(93, 12);
            textBoxMTF.Name = "textBoxMTF";
            textBoxMTF.ReadOnly = true;
            textBoxMTF.Size = new Size(211, 21);
            textBoxMTF.TabIndex = 3;
            textBoxMTF.Text = "Browse for MegaMek MTF";
            textBoxMTF.TextAlign = HorizontalAlignment.Center;
            textBoxMTF.TextChanged += textBoxMTF_TextChanged;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 41);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // textBoxChassis
            // 
            textBoxChassis.Location = new Point(418, 12);
            textBoxChassis.Name = "textBoxChassis";
            textBoxChassis.Size = new Size(211, 21);
            textBoxChassis.TabIndex = 5;
            // 
            // textBoxVariant
            // 
            textBoxVariant.Location = new Point(749, 12);
            textBoxVariant.Name = "textBoxVariant";
            textBoxVariant.Size = new Size(211, 21);
            textBoxVariant.TabIndex = 6;
            // 
            // labelChassis
            // 
            labelChassis.AutoSize = true;
            labelChassis.Location = new Point(352, 15);
            labelChassis.Name = "labelChassis";
            labelChassis.Size = new Size(56, 15);
            labelChassis.TabIndex = 7;
            labelChassis.Text = "Chassis";
            // 
            // labelVariant
            // 
            labelVariant.AutoSize = true;
            labelVariant.Location = new Point(687, 15);
            labelVariant.Name = "labelVariant";
            labelVariant.Size = new Size(56, 15);
            labelVariant.TabIndex = 8;
            labelVariant.Text = "Variant";
            // 
            // comboBoxMass
            // 
            comboBoxMass.FormattingEnabled = true;
            comboBoxMass.Items.AddRange(new object[] { "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100" });
            comboBoxMass.Location = new Point(418, 42);
            comboBoxMass.Name = "comboBoxMass";
            comboBoxMass.Size = new Size(149, 23);
            comboBoxMass.TabIndex = 9;
            // 
            // labelMass
            // 
            labelMass.AutoSize = true;
            labelMass.Location = new Point(377, 46);
            labelMass.Name = "labelMass";
            labelMass.Size = new Size(35, 15);
            labelMass.TabIndex = 10;
            labelMass.Text = "Mass";
            // 
            // checkBoxOmni
            // 
            checkBoxOmni.AutoSize = true;
            checkBoxOmni.Location = new Point(573, 45);
            checkBoxOmni.Name = "checkBoxOmni";
            checkBoxOmni.Size = new Size(54, 19);
            checkBoxOmni.TabIndex = 12;
            checkBoxOmni.Text = "Omni";
            checkBoxOmni.UseVisualStyleBackColor = true;
            // 
            // labelHeatSinks
            // 
            labelHeatSinks.AutoSize = true;
            labelHeatSinks.Location = new Point(666, 44);
            labelHeatSinks.Name = "labelHeatSinks";
            labelHeatSinks.Size = new Size(77, 15);
            labelHeatSinks.TabIndex = 13;
            labelHeatSinks.Text = "Heat Sinks";
            // 
            // textBoxHeatSinks
            // 
            textBoxHeatSinks.Location = new Point(749, 41);
            textBoxHeatSinks.Name = "textBoxHeatSinks";
            textBoxHeatSinks.Size = new Size(141, 21);
            textBoxHeatSinks.TabIndex = 14;
            // 
            // checkBoxDouble
            // 
            checkBoxDouble.AutoSize = true;
            checkBoxDouble.Location = new Point(896, 46);
            checkBoxDouble.Name = "checkBoxDouble";
            checkBoxDouble.Size = new Size(68, 19);
            checkBoxDouble.TabIndex = 15;
            checkBoxDouble.Text = "Double";
            checkBoxDouble.UseVisualStyleBackColor = true;
            checkBoxDouble.CheckedChanged += checkBoxDouble_CheckedChanged;
            // 
            // labelWalk
            // 
            labelWalk.AutoSize = true;
            labelWalk.Location = new Point(356, 74);
            labelWalk.Name = "labelWalk";
            labelWalk.Size = new Size(56, 15);
            labelWalk.TabIndex = 16;
            labelWalk.Text = "Walk MP";
            // 
            // textBoxWalk
            // 
            textBoxWalk.Location = new Point(418, 71);
            textBoxWalk.Name = "textBoxWalk";
            textBoxWalk.Size = new Size(211, 21);
            textBoxWalk.TabIndex = 17;
            // 
            // textBoxJump
            // 
            textBoxJump.Location = new Point(749, 74);
            textBoxJump.Name = "textBoxJump";
            textBoxJump.Size = new Size(211, 21);
            textBoxJump.TabIndex = 19;
            // 
            // labelJump
            // 
            labelJump.AutoSize = true;
            labelJump.Location = new Point(687, 77);
            labelJump.Name = "labelJump";
            labelJump.Size = new Size(56, 15);
            labelJump.TabIndex = 18;
            labelJump.Text = "Jump MP";
            // 
            // listBoxEquip
            // 
            listBoxEquip.FormattingEnabled = true;
            listBoxEquip.ItemHeight = 15;
            listBoxEquip.Location = new Point(12, 499);
            listBoxEquip.Name = "listBoxEquip";
            listBoxEquip.Size = new Size(400, 199);
            listBoxEquip.TabIndex = 20;
            // 
            // buttonAddEquip
            // 
            buttonAddEquip.Location = new Point(12, 441);
            buttonAddEquip.Name = "buttonAddEquip";
            buttonAddEquip.Size = new Size(104, 23);
            buttonAddEquip.TabIndex = 21;
            buttonAddEquip.Text = "Add";
            buttonAddEquip.UseVisualStyleBackColor = true;
            buttonAddEquip.Click += buttonAddEquip_Click;
            // 
            // listBoxWeapon
            // 
            listBoxWeapon.FormattingEnabled = true;
            listBoxWeapon.ItemHeight = 15;
            listBoxWeapon.Location = new Point(12, 236);
            listBoxWeapon.Name = "listBoxWeapon";
            listBoxWeapon.Size = new Size(400, 199);
            listBoxWeapon.TabIndex = 22;
            listBoxWeapon.SelectedIndexChanged += listBoxWeapon_SelectedIndexChanged;
            // 
            // buttonAddWeapon
            // 
            buttonAddWeapon.Location = new Point(12, 178);
            buttonAddWeapon.Name = "buttonAddWeapon";
            buttonAddWeapon.Size = new Size(104, 23);
            buttonAddWeapon.TabIndex = 23;
            buttonAddWeapon.Text = "Add";
            buttonAddWeapon.UseVisualStyleBackColor = true;
            buttonAddWeapon.Click += buttonAddWeapon_Click;
            // 
            // comboBoxArmor
            // 
            comboBoxArmor.FormattingEnabled = true;
            comboBoxArmor.Items.AddRange(new object[] { "Standard", "Ferro-Fibrous", "Light Ferro-Fibrous", "Heavy Ferro-Fibrous", "Stealth", "Ferro-Fibrous Prototype", "Idustrial", "Heavy Industrial", "Primitive" });
            comboBoxArmor.Location = new Point(418, 100);
            comboBoxArmor.Name = "comboBoxArmor";
            comboBoxArmor.Size = new Size(211, 23);
            comboBoxArmor.TabIndex = 24;
            // 
            // labelArmorType
            // 
            labelArmorType.AutoSize = true;
            labelArmorType.Location = new Point(335, 103);
            labelArmorType.Name = "labelArmorType";
            labelArmorType.Size = new Size(77, 15);
            labelArmorType.TabIndex = 25;
            labelArmorType.Text = "Armor Type";
            // 
            // comboBoxWeapons
            // 
            comboBoxWeapons.FormattingEnabled = true;
            comboBoxWeapons.Items.AddRange(new object[] { "MG", "Flamer", "AC/2", "AC/5", "AC/10", "AC/20", "UAC/2", "UAC/5", "UAC/10", "UAC/20", "LB2-X", "LB5-X", "LB10-X", "LB20-X", "SRM-2", "SRM-4", "SRM-6", "Streak SRM-2", "Streak SRM-4", "Streak SRM-6", "LRM-5", "LRM-10", "LRM-15", "LRM-20", "S Las", "M Las", "L Las", "ER S Las", "ER M Las", "ER L Las", "S Pul Las", "M Pul Las", "L Pul Las", "PPC", "ER PPC", "Gauss Rifle" });
            comboBoxWeapons.Location = new Point(122, 208);
            comboBoxWeapons.Name = "comboBoxWeapons";
            comboBoxWeapons.Size = new Size(221, 23);
            comboBoxWeapons.TabIndex = 26;
            comboBoxWeapons.SelectedIndexChanged += comboBoxWeapons_SelectedIndexChanged;
            // 
            // comboBoxEquipment
            // 
            comboBoxEquipment.FormattingEnabled = true;
            comboBoxEquipment.Items.AddRange(new object[] { "Ammo", "CASE", "CASE II", "AMS", "TAG", "NARC", "TSM", "MASC", "Supercharger", "AES", "Partial Wing", "Targeting Computer", "AES", "Partial Wing", "Targeting Computer", "PPC Capacitor", "Electronic Warfare Equipment", "Artemis IV" });
            comboBoxEquipment.Location = new Point(122, 442);
            comboBoxEquipment.Name = "comboBoxEquipment";
            comboBoxEquipment.Size = new Size(221, 23);
            comboBoxEquipment.TabIndex = 27;
            comboBoxEquipment.SelectedIndexChanged += comboBoxEquipment_SelectedIndexChanged;
            // 
            // comboBoxWeaponLoc
            // 
            comboBoxWeaponLoc.FormattingEnabled = true;
            comboBoxWeaponLoc.Items.AddRange(new object[] { "(LA)", "(RA)", "(T)", "(HD)", "(LL)", "(RL)" });
            comboBoxWeaponLoc.Location = new Point(349, 208);
            comboBoxWeaponLoc.Name = "comboBoxWeaponLoc";
            comboBoxWeaponLoc.Size = new Size(63, 23);
            comboBoxWeaponLoc.TabIndex = 28;
            // 
            // comboBoxEquipLoc
            // 
            comboBoxEquipLoc.FormattingEnabled = true;
            comboBoxEquipLoc.Items.AddRange(new object[] { "(LA)", "(RA)", "(T)", "(HD)", "(LL)", "(RL)" });
            comboBoxEquipLoc.Location = new Point(349, 442);
            comboBoxEquipLoc.Name = "comboBoxEquipLoc";
            comboBoxEquipLoc.Size = new Size(63, 23);
            comboBoxEquipLoc.TabIndex = 29;
            comboBoxEquipLoc.SelectedIndexChanged += comboBoxEquipLoc_SelectedIndexChanged;
            // 
            // labelTechBase
            // 
            labelTechBase.AutoSize = true;
            labelTechBase.Location = new Point(680, 103);
            labelTechBase.Name = "labelTechBase";
            labelTechBase.Size = new Size(63, 15);
            labelTechBase.TabIndex = 30;
            labelTechBase.Text = "TechBase";
            // 
            // textBoxTechBase
            // 
            textBoxTechBase.Location = new Point(749, 102);
            textBoxTechBase.Name = "textBoxTechBase";
            textBoxTechBase.Size = new Size(211, 21);
            textBoxTechBase.TabIndex = 31;
            // 
            // textBoxArmorHD
            // 
            textBoxArmorHD.Location = new Point(680, 249);
            textBoxArmorHD.Name = "textBoxArmorHD";
            textBoxArmorHD.Size = new Size(100, 21);
            textBoxArmorHD.TabIndex = 32;
            // 
            // labelArmorHD
            // 
            labelArmorHD.AutoSize = true;
            labelArmorHD.Location = new Point(717, 231);
            labelArmorHD.Name = "labelArmorHD";
            labelArmorHD.Size = new Size(21, 15);
            labelArmorHD.TabIndex = 33;
            labelArmorHD.Text = "HD";
            // 
            // labelArmor
            // 
            labelArmor.AutoSize = true;
            labelArmor.Location = new Point(705, 208);
            labelArmor.Name = "labelArmor";
            labelArmor.Size = new Size(42, 15);
            labelArmor.TabIndex = 34;
            labelArmor.Text = "Armor";
            // 
            // textBoxArmorLT
            // 
            textBoxArmorLT.Location = new Point(577, 301);
            textBoxArmorLT.Name = "textBoxArmorLT";
            textBoxArmorLT.Size = new Size(100, 21);
            textBoxArmorLT.TabIndex = 35;
            // 
            // textBoxArmorLA
            // 
            textBoxArmorLA.Location = new Point(471, 327);
            textBoxArmorLA.Name = "textBoxArmorLA";
            textBoxArmorLA.Size = new Size(100, 21);
            textBoxArmorLA.TabIndex = 36;
            // 
            // textBoxArmorRT
            // 
            textBoxArmorRT.Location = new Point(783, 301);
            textBoxArmorRT.Name = "textBoxArmorRT";
            textBoxArmorRT.Size = new Size(100, 21);
            textBoxArmorRT.TabIndex = 37;
            // 
            // textBoxArmorLTR
            // 
            textBoxArmorLTR.Location = new Point(577, 385);
            textBoxArmorLTR.Name = "textBoxArmorLTR";
            textBoxArmorLTR.Size = new Size(100, 21);
            textBoxArmorLTR.TabIndex = 38;
            // 
            // textBoxArmorRTR
            // 
            textBoxArmorRTR.Location = new Point(783, 385);
            textBoxArmorRTR.Name = "textBoxArmorRTR";
            textBoxArmorRTR.Size = new Size(100, 21);
            textBoxArmorRTR.TabIndex = 39;
            // 
            // textBoxArmorRA
            // 
            textBoxArmorRA.Location = new Point(887, 327);
            textBoxArmorRA.Name = "textBoxArmorRA";
            textBoxArmorRA.Size = new Size(100, 21);
            textBoxArmorRA.TabIndex = 40;
            // 
            // textBoxArmorCTR
            // 
            textBoxArmorCTR.Location = new Point(680, 385);
            textBoxArmorCTR.Name = "textBoxArmorCTR";
            textBoxArmorCTR.Size = new Size(100, 21);
            textBoxArmorCTR.TabIndex = 41;
            // 
            // textBoxArmorLL
            // 
            textBoxArmorLL.Location = new Point(577, 437);
            textBoxArmorLL.Name = "textBoxArmorLL";
            textBoxArmorLL.Size = new Size(100, 21);
            textBoxArmorLL.TabIndex = 42;
            // 
            // textBoxArmorRL
            // 
            textBoxArmorRL.Location = new Point(783, 437);
            textBoxArmorRL.Name = "textBoxArmorRL";
            textBoxArmorRL.Size = new Size(100, 21);
            textBoxArmorRL.TabIndex = 43;
            // 
            // labelArmorLT
            // 
            labelArmorLT.AutoSize = true;
            labelArmorLT.Location = new Point(612, 283);
            labelArmorLT.Name = "labelArmorLT";
            labelArmorLT.Size = new Size(21, 15);
            labelArmorLT.TabIndex = 44;
            labelArmorLT.Text = "LT";
            // 
            // labelArmorRT
            // 
            labelArmorRT.AutoSize = true;
            labelArmorRT.Location = new Point(822, 283);
            labelArmorRT.Name = "labelArmorRT";
            labelArmorRT.Size = new Size(21, 15);
            labelArmorRT.TabIndex = 45;
            labelArmorRT.Text = "RT";
            // 
            // labelArmorLTR
            // 
            labelArmorLTR.AutoSize = true;
            labelArmorLTR.Location = new Point(612, 367);
            labelArmorLTR.Name = "labelArmorLTR";
            labelArmorLTR.Size = new Size(28, 15);
            labelArmorLTR.TabIndex = 46;
            labelArmorLTR.Text = "LTR";
            // 
            // labelArmorRTR
            // 
            labelArmorRTR.AutoSize = true;
            labelArmorRTR.Location = new Point(822, 367);
            labelArmorRTR.Name = "labelArmorRTR";
            labelArmorRTR.Size = new Size(28, 15);
            labelArmorRTR.TabIndex = 47;
            labelArmorRTR.Text = "RTR";
            // 
            // textBoxArmorCT
            // 
            textBoxArmorCT.Location = new Point(680, 301);
            textBoxArmorCT.Name = "textBoxArmorCT";
            textBoxArmorCT.Size = new Size(100, 21);
            textBoxArmorCT.TabIndex = 48;
            // 
            // labelArmorCT
            // 
            labelArmorCT.AutoSize = true;
            labelArmorCT.Location = new Point(717, 283);
            labelArmorCT.Name = "labelArmorCT";
            labelArmorCT.Size = new Size(21, 15);
            labelArmorCT.TabIndex = 49;
            labelArmorCT.Text = "CT";
            // 
            // labelArmorCTR
            // 
            labelArmorCTR.AutoSize = true;
            labelArmorCTR.Location = new Point(717, 367);
            labelArmorCTR.Name = "labelArmorCTR";
            labelArmorCTR.Size = new Size(28, 15);
            labelArmorCTR.TabIndex = 50;
            labelArmorCTR.Text = "CTR";
            // 
            // labelArmorLA
            // 
            labelArmorLA.AutoSize = true;
            labelArmorLA.Location = new Point(509, 309);
            labelArmorLA.Name = "labelArmorLA";
            labelArmorLA.Size = new Size(21, 15);
            labelArmorLA.TabIndex = 51;
            labelArmorLA.Text = "LA";
            // 
            // labelArmorRA
            // 
            labelArmorRA.AutoSize = true;
            labelArmorRA.Location = new Point(931, 309);
            labelArmorRA.Name = "labelArmorRA";
            labelArmorRA.Size = new Size(21, 15);
            labelArmorRA.TabIndex = 52;
            labelArmorRA.Text = "RA";
            // 
            // labelArmorRL
            // 
            labelArmorRL.AutoSize = true;
            labelArmorRL.Location = new Point(822, 419);
            labelArmorRL.Name = "labelArmorRL";
            labelArmorRL.Size = new Size(21, 15);
            labelArmorRL.TabIndex = 53;
            labelArmorRL.Text = "RL";
            // 
            // labelArmorLL
            // 
            labelArmorLL.AutoSize = true;
            labelArmorLL.Location = new Point(612, 419);
            labelArmorLL.Name = "labelArmorLL";
            labelArmorLL.Size = new Size(21, 15);
            labelArmorLL.TabIndex = 54;
            labelArmorLL.Text = "LL";
            // 
            // buttonRemoveEquipment
            // 
            buttonRemoveEquipment.Location = new Point(12, 470);
            buttonRemoveEquipment.Name = "buttonRemoveEquipment";
            buttonRemoveEquipment.Size = new Size(104, 23);
            buttonRemoveEquipment.TabIndex = 55;
            buttonRemoveEquipment.Text = "Remove";
            buttonRemoveEquipment.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveWeapon
            // 
            buttonRemoveWeapon.Location = new Point(12, 208);
            buttonRemoveWeapon.Name = "buttonRemoveWeapon";
            buttonRemoveWeapon.Size = new Size(104, 23);
            buttonRemoveWeapon.TabIndex = 56;
            buttonRemoveWeapon.Text = "Remove";
            buttonRemoveWeapon.UseVisualStyleBackColor = true;
            // 
            // comboBoxEquipmentSubtype
            // 
            comboBoxEquipmentSubtype.FormattingEnabled = true;
            comboBoxEquipmentSubtype.Location = new Point(122, 471);
            comboBoxEquipmentSubtype.Name = "comboBoxEquipmentSubtype";
            comboBoxEquipmentSubtype.Size = new Size(221, 23);
            comboBoxEquipmentSubtype.TabIndex = 57;
            // 
            // mainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 710);
            Controls.Add(comboBoxEquipmentSubtype);
            Controls.Add(buttonRemoveWeapon);
            Controls.Add(buttonRemoveEquipment);
            Controls.Add(labelArmorLL);
            Controls.Add(labelArmorRL);
            Controls.Add(labelArmorRA);
            Controls.Add(labelArmorLA);
            Controls.Add(labelArmorCTR);
            Controls.Add(labelArmorCT);
            Controls.Add(textBoxArmorCT);
            Controls.Add(labelArmorRTR);
            Controls.Add(labelArmorLTR);
            Controls.Add(labelArmorRT);
            Controls.Add(labelArmorLT);
            Controls.Add(textBoxArmorRL);
            Controls.Add(textBoxArmorLL);
            Controls.Add(textBoxArmorCTR);
            Controls.Add(textBoxArmorRA);
            Controls.Add(textBoxArmorRTR);
            Controls.Add(textBoxArmorLTR);
            Controls.Add(textBoxArmorRT);
            Controls.Add(textBoxArmorLA);
            Controls.Add(textBoxArmorLT);
            Controls.Add(labelArmor);
            Controls.Add(labelArmorHD);
            Controls.Add(textBoxArmorHD);
            Controls.Add(textBoxTechBase);
            Controls.Add(labelTechBase);
            Controls.Add(comboBoxEquipLoc);
            Controls.Add(comboBoxWeaponLoc);
            Controls.Add(comboBoxEquipment);
            Controls.Add(comboBoxWeapons);
            Controls.Add(labelArmorType);
            Controls.Add(comboBoxArmor);
            Controls.Add(buttonAddWeapon);
            Controls.Add(listBoxWeapon);
            Controls.Add(buttonAddEquip);
            Controls.Add(listBoxEquip);
            Controls.Add(textBoxJump);
            Controls.Add(labelJump);
            Controls.Add(textBoxWalk);
            Controls.Add(labelWalk);
            Controls.Add(checkBoxDouble);
            Controls.Add(textBoxHeatSinks);
            Controls.Add(labelHeatSinks);
            Controls.Add(checkBoxOmni);
            Controls.Add(labelMass);
            Controls.Add(comboBoxMass);
            Controls.Add(labelVariant);
            Controls.Add(labelChassis);
            Controls.Add(textBoxVariant);
            Controls.Add(textBoxChassis);
            Controls.Add(buttonLoad);
            Controls.Add(textBoxMTF);
            Controls.Add(buttonBrowseMTF);
            Controls.Add(buttonGenerate);
            Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "mainWindow";
            Text = "Battletech Override Record Sheet Tool";
            Load += mainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGenerate;
        private Button buttonBrowseMTF;
        private TextBox textBoxMTF;
        private Button buttonLoad;
        private TextBox textBoxChassis;
        private TextBox textBoxVariant;
        private Label labelChassis;
        private Label labelVariant;
        private ComboBox comboBoxMass;
        private Label labelMass;
        private CheckBox checkBoxOmni;
        private Label labelHeatSinks;
        private TextBox textBoxHeatSinks;
        private CheckBox checkBoxDouble;
        private Label labelWalk;
        private TextBox textBoxWalk;
        private TextBox textBoxJump;
        private Label labelJump;
        private ListBox listBoxEquip;
        private Button buttonAddEquip;
        private ListBox listBoxWeapon;
        private Button buttonAddWeapon;
        private ComboBox comboBoxArmor;
        private Label labelArmorType;
        private ComboBox comboBoxWeapons;
        private ComboBox comboBoxEquipment;
        private ComboBox comboBoxWeaponLoc;
        private ComboBox comboBoxEquipLoc;
        private Label labelTechBase;
        private TextBox textBoxTechBase;
        private TextBox textBoxArmorHD;
        private Label labelArmorHD;
        private Label labelArmor;
        private TextBox textBoxArmorLT;
        private TextBox textBoxArmorLA;
        private TextBox textBoxArmorRT;
        private TextBox textBoxArmorLTR;
        private TextBox textBoxArmorRTR;
        private TextBox textBoxArmorRA;
        private TextBox textBoxArmorCTR;
        private TextBox textBoxArmorLL;
        private TextBox textBoxArmorRL;
        private Label labelArmorLT;
        private Label labelArmorRT;
        private Label labelArmorLTR;
        private Label labelArmorRTR;
        private TextBox textBoxArmorCT;
        private Label labelArmorCT;
        private Label labelArmorCTR;
        private Label labelArmorLA;
        private Label labelArmorRA;
        private Label labelArmorRL;
        private Label labelArmorLL;
        private Button buttonRemoveEquipment;
        private Button buttonRemoveWeapon;
        private ComboBox comboBoxEquipmentSubtype;
    }
}
