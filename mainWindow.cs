using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
            document.Info.Title = "Created with PDFsharp";
            PdfPage page = document.AddPage();
            page.Width = "6in";
            page.Height = "4in";
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);
            XFont headerFont = new XFont("Verdana", 14, XFontStyleEx.Regular);
            XFont detailFont = new XFont("Verdana", 8, XFontStyleEx.Regular);
            XFont weaponFont = new XFont("Courier New", 8, XFontStyleEx.Bold);

            // Draw Backgroun
            DrawImage(gfx, "data\\blankMech.png", 0, 0, 430, 285);
            const string filename = "Out.pdf";

            // Write Mech Chassis + Variant (Trim to 29 ~ max size)
            tf.DrawString(battleMech.chassis + " " + battleMech.variant, headerFont, XBrushes.Black,
              new XRect(12, 8, 250, 20),
              XStringFormats.TopLeft);

            if (!battleMech.omnimech)
            {
                tf.DrawString("BattleMech", detailFont, XBrushes.Black,
                  new XRect(33, 38, 250, 10),
                  XStringFormats.TopLeft);
            }
            else
            {
                tf.DrawString("OmniMech", detailFont, XBrushes.Black,
                  new XRect(33, 38, 250, 10),
                  XStringFormats.TopLeft);
            }

            tf.DrawString(battleMech.mass.ToString(), detailFont, XBrushes.Black,
              new XRect(33, 48, 100, 10),
              XStringFormats.TopLeft);

            tf.DrawString(battleMech.walk.ToString(), detailFont, XBrushes.Black,
              new XRect(33, 61, 100, 10),
              XStringFormats.TopLeft);

            tf.DrawString(" / " + Math.Ceiling(battleMech.walk * 1.5).ToString(), detailFont, XBrushes.Black,
              new XRect(40, 61, 100, 10),
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
              new XRect(111, 61, 100, 10),
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
              new XRect(33, 71, 100, 10),
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
              new XRect(40, 71, 100, 10),
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
                  new XRect(55, 71, 100, 10),
                  XStringFormats.TopLeft);
            }

            string allEquipment = "";
            foreach (Equipment equip in battleMech.equip)
            {
                allEquipment += (equip.ToString() + " | ");
            }
            tf.DrawString(allEquipment, detailFont, XBrushes.Black,
              new XRect(50, 215, 180, 60),
              XStringFormats.TopLeft);

            string allWeapons = "";
            foreach (Weapon weapon in battleMech.weapons)
            {
                allWeapons += (weapon.ToString() + '\n');
            }
            tf.DrawString(allWeapons, weaponFont, XBrushes.Black,
              new XRect(16, 95, 250, 60),
              XStringFormats.TopLeft);

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

            /*public string chassis = "";
            public string variant = "";
            public bool omnimech = false;
            public bool doubleHeatSinks = false;
            public string techBase = "Inner Sphere";
            public int mass = 0;
            public int walk = 0;
            public int jump = 0;
            public int heatSinks = 0;
            public string armorType = "";
            public int armorLA = 0;
            public int armorRA = 0;
            public int armorHead = 0;
            public int armorLT = 0;
            public int armorCT = 0;
            public int armorRT = 0;
            public int armorLTR = 0;
            public int armorCTR = 0;
            public int armorRTR = 0;
            public int armorLL = 0;
            public int armorRL = 0;*/

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
            battleMech.weapons = listBoxWeapon.Items.OfType<Weapon>().ToList();
            battleMech.equip = listBoxEquip.Items.OfType<Equipment>().ToList();

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

            listBoxWeapon.DataSource = battlemech.weapons;
            listBoxEquip.DataSource = battlemech.equip;
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddWeapon_Click(object sender, EventArgs e)
        {

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
            switch(comboBoxEquipment.Text)
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
                    foreach (string ammo in ammoList)
                    {
                        comboBoxEquipmentSubtype.Items.Add(ammo);
                    }
                    break;
                case "CASE": comboBoxEquipmentSubtype.Items.Clear(); break;

                case "CASE II": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "AMS": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "TAG": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "NARC": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "TSM": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "MASC": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "Supercharger": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "AES": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "Partial Wing": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "Targeting Computer": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "Electronic Warfare Equipment":
                    List<string> ECMList = new List<string> {
                        "Guardian",
                        "Angel"
                    };
                    comboBoxEquipmentSubtype.Items.Clear(); 
                    foreach (string ecm in ECMList)
                    {
                        comboBoxEquipmentSubtype.Items.Add(ecm);
                    }
                    break;
                case "PPC Capacitor": comboBoxEquipmentSubtype.Items.Clear(); break;
                case "Artemis IV": comboBoxEquipmentSubtype.Items.Clear(); break;
            }
        }
    }
}
