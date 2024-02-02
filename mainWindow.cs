using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;

namespace BORST
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }
        void DrawImage(XGraphics gfx, string path, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(path);
            gfx.DrawImage(image, x, y, width, height);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Create battleMech object from the GUI
            BattleMech battleMech = BuildBattleMechFromGUI();

            // Create and setup new PDF
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Width = "7in";
            page.Height = "5in";
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);
            XFont headerFont = new XFont("Verdana", 14, XFontStyleEx.Regular);
            XFont detailFont = new XFont("Verdana", 8, XFontStyleEx.Regular);
            XFont weaponFont = new XFont("Courier New", 9, XFontStyleEx.Bold);

            string blankPdfPath = "";
            // Draw Backgroun
            switch(battleMech.mass)
            {
                case 20:
                    blankPdfPath = "data\\blankMech_20t.png"; break;
                case 25:
                    blankPdfPath = "data\\blankMech_25t.png"; break;
                case 30:
                    blankPdfPath = "data\\blankMech_30t.png"; break;
                case 35:
                    blankPdfPath = "data\\blankMech_35t.png"; break;
                case 40:
                    blankPdfPath = "data\\blankMech_40t.png"; break;
                case 45:
                    blankPdfPath = "data\\blankMech_45t.png"; break;
                case 50:
                    blankPdfPath = "data\\blankMech_50t.png"; break;
                case 55:
                    blankPdfPath = "data\\blankMech_55t.png"; break;
                case 60:
                    blankPdfPath = "data\\blankMech_60t.png"; break;
                case 65:
                    blankPdfPath = "data\\blankMech_65t.png"; break;
                case 70:
                    blankPdfPath = "data\\blankMech_70t.png"; break;
                case 75:
                    blankPdfPath = "data\\blankMech_75t.png"; break;
                case 80:
                    blankPdfPath = "data\\blankMech_80t.png"; break;
                case 85:
                    blankPdfPath = "data\\blankMech_85t.png"; break;
                case 90:
                    blankPdfPath = "data\\blankMech_90t.png"; break;
                case 95:
                    blankPdfPath = "data\\blankMech_95t.png"; break;
                case 100:
                    blankPdfPath = "data\\blankMech_100t.png"; break;
            }
            DrawImage(gfx, blankPdfPath, 0, 0, 504, 360);
            string nameAndVariant = "";
            nameAndVariant = battleMech.chassis + " " + battleMech.variant;
            document.Info.Title = nameAndVariant;
            string filename = nameAndVariant + ".pdf";

            // Write Mech Chassis + Variant (Trim to 29 ~ max size)
            tf.DrawString(battleMech.chassis + " " + battleMech.variant, headerFont, XBrushes.Black,
              new XRect(13, 12, 250, 20),
              XStringFormats.TopLeft);

            if (!battleMech.omnimech)
            {
                tf.DrawString("BattleMech", detailFont, XBrushes.Black,
                  new XRect(36, 50, 250, 10),
                  XStringFormats.TopLeft);
            }
            else
            {
                tf.DrawString("OmniMech", detailFont, XBrushes.Black,
                  new XRect(36, 50, 250, 10),
                  XStringFormats.TopLeft);
            }

            tf.DrawString(battleMech.mass.ToString() + " Tons", detailFont, XBrushes.Black,
              new XRect(41, 62, 100, 10),
              XStringFormats.TopLeft);

            tf.DrawString(battleMech.walk.ToString(), detailFont, XBrushes.Black,
              new XRect(40, 79, 100, 10),
              XStringFormats.TopLeft);

            tf.DrawString(" / " + Math.Ceiling(battleMech.walk * 1.5).ToString(), detailFont, XBrushes.Black,
              new XRect(46, 79, 100, 10),
              XStringFormats.TopLeft);

            int cooling;
            if (!battleMech.doubleHeatSinks)
            {
                cooling = (int)((battleMech.heatSinks + 2) / 5);
            }
            else
            {
                cooling = (int)((battleMech.heatSinks + 1) / 2.5);
            }
            tf.DrawString(cooling.ToString(), detailFont, XBrushes.Black,
              new XRect(130, 79, 100, 10),
              XStringFormats.TopLeft);

            int tmmWalk;
            switch (battleMech.walk)
            {
                case 0:
                case 1:
                case 2:
                    tmmWalk = 0;
                    break;
                case 3:
                case 4:
                    tmmWalk = 1;
                    break;
                case 5:
                case 6:
                    tmmWalk = 2;
                    break;
                case 7:
                case 8:
                    tmmWalk = 3;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    tmmWalk = 4;
                    break;
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    tmmWalk = 5;
                    break;
                default: tmmWalk = 6; break;
            }

            tf.DrawString(tmmWalk.ToString(), detailFont, XBrushes.Black,
              new XRect(40, 91, 100, 10),
              XStringFormats.TopLeft);

            int tmmRun;
            switch (Math.Ceiling(battleMech.walk * 1.5))
            {
                case 0:
                case 1:
                case 2:
                    tmmRun = 0;
                    break;
                case 3:
                case 4:
                    tmmRun = 1;
                    break;
                case 5:
                case 6:
                    tmmRun = 2;
                    break;
                case 7:
                case 8:
                    tmmRun = 3;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    tmmRun = 4;
                    break;
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    tmmRun = 5;
                    break;
                default: tmmRun = 6; break;
            }

            tf.DrawString(" / " + tmmRun.ToString(), detailFont, XBrushes.Black,
              new XRect(46, 91, 100, 10),
              XStringFormats.TopLeft);

            if (battleMech.jump != 0)
            {
                int tmmJump;
                switch (battleMech.jump)
                {
                    case 0:
                    case 1:
                    case 2:
                        tmmJump = 0;
                        break;
                    case 3:
                    case 4:
                        tmmJump = 1;
                        break;
                    case 5:
                    case 6:
                        tmmJump = 2;
                        break;
                    case 7:
                    case 8:
                        tmmJump = 3;
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                        tmmJump = 4;
                        break;
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                        tmmJump = 5;
                        break;
                    default: tmmJump = 6; break;
                }
                tmmJump += 1;
                tf.DrawString(" / " + tmmJump.ToString(), detailFont, XBrushes.Black,
                  new XRect(61, 91, 100, 10),
                  XStringFormats.TopLeft);
            }

            string allWeapons = "";
            foreach (Weapon weapon in battleMech.weapons)
            {
                allWeapons += (weapon.ToString() + '\n');
            }
            tf.DrawString(allWeapons, weaponFont, XBrushes.Black,
              new XRect(16, 124, 250, 100),
              XStringFormats.TopLeft);

            string allEquipment = "";
            foreach (Equipment equip in battleMech.equip)
            {
                allEquipment += (equip.ToString() + " | ");
            }
            tf.DrawString(allEquipment, detailFont, XBrushes.Black,
              new XRect(55, 273, 180, 60),
              XStringFormats.TopLeft);

            string punchKick = "";
            switch (battleMech.mass)
            {
                case 20:
                case 25:
                case 30:
                    punchKick = "1 / 2";
                    break;
                case 35:
                case 40:
                case 45:
                    punchKick = "2 / 3";
                    break;
                case 50:
                case 55:
                case 60:
                    punchKick = "2 / 4";
                    break;
                case 65:
                case 70:
                case 75:
                    punchKick = "3 / 5";
                    break;
                case 80:
                case 85:
                case 90:
                    punchKick = "3 / 6";
                    break;
                case 95:
                case 100:
                    punchKick = "4 / 7";
                    break;

            }
            tf.DrawString(punchKick, weaponFont, XBrushes.Black,
              new XRect(86, 254, 100, 10),
              XStringFormats.TopLeft);
            int HDArmorPips = 0;
            int TArmorPips = 0;
            int RTArmorPips = 0;
            int LAArmorPips = 0;
            int RAArmorPips = 0;
            int LLArmorPips = 0;
            int RLArmorPips = 0;

            if (battleMech.armorHD == 1) HDArmorPips = 1; else HDArmorPips = (int)Math.Floor(battleMech.armorHD / 2.0);
            if (battleMech.armorCT == 1) TArmorPips = 1; else TArmorPips = (int)Math.Floor(battleMech.armorHD / 2.0);

            document.Save(filename);
            document.Close();

            gfx.Dispose();
        }

        private void buttonBrowseMTF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxMTF.Text = openFileDialog.FileName;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            BattleMech battlemech = BattleMechBuilder.BuildBattleMechFromMTFFile(textBoxMTF.Text);

            PopulateGUIFromBattleMech(battlemech);
        }

        public BattleMech BuildBattleMechFromGUI()
        {
            BattleMech battleMech = new BattleMech();

            battleMech.chassis = textBoxChassis.Text;
            battleMech.variant = textBoxVariant.Text;
            battleMech.omnimech = checkBoxOmni.Checked;
            battleMech.doubleHeatSinks = checkBoxDouble.Checked;
            battleMech.techBase = textBoxTechBase.Text;
            battleMech.mass = int.Parse(comboBoxMass.Text);
            battleMech.walk = int.Parse(textBoxWalk.Text);
            battleMech.jump = int.Parse(textBoxJump.Text);
            battleMech.heatSinks = int.Parse(textBoxHeatSinks.Text);
            battleMech.armorType = comboBoxArmor.Text;
            battleMech.armorLA = int.Parse(textBoxArmorLA.Text);
            battleMech.armorRA = int.Parse(textBoxArmorRA.Text);
            battleMech.armorHD = int.Parse(textBoxArmorHD.Text);
            battleMech.armorLT = int.Parse(textBoxArmorLT.Text);
            battleMech.armorCT = int.Parse(textBoxArmorCT.Text);
            battleMech.armorRT = int.Parse(textBoxArmorRT.Text);
            battleMech.armorLTR = int.Parse(textBoxArmorLTR.Text);
            battleMech.armorRTR = int.Parse(textBoxArmorRTR.Text);
            battleMech.armorLL = int.Parse(textBoxArmorLL.Text);
            battleMech.armorRL = int.Parse(textBoxArmorRL.Text);

            foreach (Weapon weapon in listBoxWeapon.Items)
            {
                battleMech.weapons.Add(weapon);
            }
            foreach (Equipment equip in listBoxEquip.Items)
            {
                battleMech.equip.Add(equip);
            }

            return battleMech;
        }

        private void PopulateGUIFromBattleMech(BattleMech battlemech)
        {
            textBoxChassis.Text = battlemech.chassis;
            textBoxVariant.Text = battlemech.variant;
            textBoxTechBase.Text = battlemech.techBase;
            comboBoxMass.Text = battlemech.mass.ToString();
            checkBoxOmni.Checked = battlemech.omnimech;
            textBoxHeatSinks.Text = battlemech.heatSinks.ToString();
            checkBoxDouble.Checked = battlemech.doubleHeatSinks;
            textBoxWalk.Text = battlemech.walk.ToString();
            textBoxJump.Text = battlemech.jump.ToString();
            comboBoxArmor.Text = battlemech.armorType;
            textBoxArmorHD.Text = battlemech.armorHD.ToString();
            textBoxArmorCT.Text = battlemech.armorCT.ToString();
            textBoxArmorLT.Text = battlemech.armorLT.ToString();
            textBoxArmorRT.Text = battlemech.armorRT.ToString();
            textBoxArmorCTR.Text = battlemech.armorCTR.ToString();
            textBoxArmorLTR.Text = battlemech.armorLTR.ToString();
            textBoxArmorRTR.Text = battlemech.armorRTR.ToString();
            textBoxArmorLA.Text = battlemech.armorLA.ToString();
            textBoxArmorRA.Text = battlemech.armorRA.ToString();
            textBoxArmorLL.Text = battlemech.armorLL.ToString();
            textBoxArmorRL.Text = battlemech.armorRL.ToString();

            listBoxWeapon.Items.Clear();
            foreach (Weapon weapon in battlemech.weapons)
            {
                listBoxWeapon.Items.Add(weapon);
            }
            listBoxEquip.Items.Clear();
            foreach (Equipment equip in battlemech.equip)
            {
                listBoxEquip.Items.Add(equip);
            }

        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddWeapon_Click(object sender, EventArgs e)
        {
            switch (comboBoxWeapons.Text)
            {
                case "MG":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new MG(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cMG(comboBoxWeaponLoc.Text));
                    break;
                case "Flamer":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new Flamer(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cFlamer(comboBoxWeaponLoc.Text));
                    break;
                case "AC/2":
                    listBoxWeapon.Items.Add(new AC2(comboBoxWeaponLoc.Text));
                    break;
                case "AC/5":
                    listBoxWeapon.Items.Add(new AC5(comboBoxWeaponLoc.Text));
                    break;
                case "AC/10":
                    listBoxWeapon.Items.Add(new AC10(comboBoxWeaponLoc.Text));
                    break;
                case "AC/20":
                    listBoxWeapon.Items.Add(new AC20(comboBoxWeaponLoc.Text));
                    break;
                case "UAC/2":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new UAC2(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cUAC2(comboBoxWeaponLoc.Text));
                    break; ;
                case "UAC/5":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new UAC5(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cUAC5(comboBoxWeaponLoc.Text));
                    break;
                case "UAC/10":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new UAC10(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cUAC10(comboBoxWeaponLoc.Text));
                    break;
                case "UAC/20":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new UAC20(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cUAC20(comboBoxWeaponLoc.Text));
                    break;
                case "LB2-X":
                    listBoxWeapon.Items.Add(new LB2X(comboBoxWeaponLoc.Text));
                    break;
                case "LB5-X":
                    listBoxWeapon.Items.Add(new LB5X(comboBoxWeaponLoc.Text));
                    break;
                case "LB10-X":
                    listBoxWeapon.Items.Add(new LB10X(comboBoxWeaponLoc.Text));
                    break;
                case "LB20-X":
                    listBoxWeapon.Items.Add(new LB20X(comboBoxWeaponLoc.Text));
                    break;
                case "SRM-2":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new SRM2(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cSRM2(comboBoxWeaponLoc.Text));
                    break; ;
                case "SRM-4":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new SRM4(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cSRM4(comboBoxWeaponLoc.Text));
                    break;
                case "SRM-6":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new SRM6(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cSRM6(comboBoxWeaponLoc.Text));
                    break;
                case "Streak SRM-2":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new StreakSRM2(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cStreakSRM2(comboBoxWeaponLoc.Text));
                    break; ;
                case "Streak SRM-4":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new StreakSRM4(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cStreakSRM4(comboBoxWeaponLoc.Text));
                    break;
                case "Streak SRM-6":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new StreakSRM6(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cStreakSRM6(comboBoxWeaponLoc.Text));
                    break;
                case "LRM-5":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new LRM5(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cLRM5(comboBoxWeaponLoc.Text));
                    break; ;
                case "LRM-10":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new LRM10(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cLRM10(comboBoxWeaponLoc.Text));
                    break;
                case "LRM-15":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new LRM15(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cLRM15(comboBoxWeaponLoc.Text));
                    break;
                case "LRM-20":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new LRM20(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cLRM20(comboBoxWeaponLoc.Text));
                    break;
                case "S Las":
                    listBoxWeapon.Items.Add(new SLas(comboBoxWeaponLoc.Text));
                    break;
                case "M Las":
                    listBoxWeapon.Items.Add(new MLas(comboBoxWeaponLoc.Text));
                    break;
                case "L Las":
                    listBoxWeapon.Items.Add(new LLas(comboBoxWeaponLoc.Text));
                    break;
                case "ER S Las":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new erSLas(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cerSLas(comboBoxWeaponLoc.Text));
                    break;
                case "ER M Las":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new erMLas(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cerMLas(comboBoxWeaponLoc.Text));
                    break;
                case "ER L Las":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new erLLas(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cerLLas(comboBoxWeaponLoc.Text));
                    break;
                case "S Pul Las":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new SpLas(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cSpLas(comboBoxWeaponLoc.Text));
                    break;
                case "M Pul Las":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new MpLas(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cMpLas(comboBoxWeaponLoc.Text));
                    break;
                case "L Pul Las":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new LpLas(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cLpLas(comboBoxWeaponLoc.Text));
                    break;
                case "PPC":
                    listBoxWeapon.Items.Add(new PPC(comboBoxWeaponLoc.Text));
                    break;
                case "ER PPC":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new erPPC(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cerPPC(comboBoxWeaponLoc.Text));
                    break;
                case "Gauss Rifle":
                    if (!checkBoxOmni.Checked)
                        listBoxWeapon.Items.Add(new Gauss(comboBoxWeaponLoc.Text));
                    else listBoxWeapon.Items.Add(new cGauss(comboBoxWeaponLoc.Text));
                    break;
                case "Arrow IV":
                    listBoxWeapon.Items.Add(new ArrowIV(comboBoxWeaponLoc.Text));
                    break;
            }
        }

        private void comboBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddEquip_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxDouble_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMTF_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEquipLoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEquipment.Text)
            {
                case "Ammo":
                    List<string> ammoList = new List<string> {
                        "LRM - 5",
                        "LRM - 10",
                        "LRM - 15",
                        "LRM - 20",
                        "SRM - 2",
                        "SRM - 4",
                        "SRM - 6",
                        "AC/2",
                        "AC/5",
                        "AC/10",
                        "AC/20",
                        "LB2-X AC",
                        "LB5-X AC",
                        "LB10-X AC",
                        "UAC/2",
                        "UAC/5",
                        "UAC/10",
                        "UAC/20",
                        "Gauss",
                        "AMS",
                        "Arrow IV",
                        "Arrow IV - Homing",
                        "Arrow IV - Cluster"
                    };
                    comboBoxEquipmentSubtype.Items.Clear();
                    comboBoxEquipmentSubtype.Enabled = true;
                    foreach (string ammo in ammoList)
                    {
                        comboBoxEquipmentSubtype.Items.Add(ammo);
                    }
                    break;
                case "CASE": comboBoxEquipmentSubtype.Items.Clear(); break;

                case "CASE II": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "AMS": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "TAG": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "NARC": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "TSM": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "MASC": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "Supercharger": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "AES": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "Partial Wing": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "Targeting Computer": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "Electronic Warfare Equipment":
                    List<string> ECMList = new List<string> {
                        "Guardian",
                        "Angel"
                    };
                    comboBoxEquipmentSubtype.Items.Clear();
                    comboBoxEquipmentSubtype.Enabled = true;
                    foreach (string ecm in ECMList)
                    {
                        comboBoxEquipmentSubtype.Items.Add(ecm);
                    }
                    break;
                case "PPC Capacitor": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
                case "Artemis IV": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
            }
        }

        private void buttonRemoveWeapon_Click(object sender, EventArgs e)
        {
            foreach (Weapon weapon in listBoxWeapon.SelectedItems.OfType<Weapon>().ToList())
                listBoxWeapon.Items.Remove(weapon);
        }

        private void buttonRemoveEquipment_Click(object sender, EventArgs e)
        {
            foreach (Equipment equip in listBoxEquip.SelectedItems.OfType<Equipment>().ToList())
                listBoxEquip.Items.Remove(equip);
        }
    }
}
