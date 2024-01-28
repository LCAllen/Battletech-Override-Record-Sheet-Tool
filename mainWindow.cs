using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Diagnostics;

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
            XFont headerFont = new XFont("Verdana", 14, XFontStyleEx.Regular);
            XFont detailFont = new XFont("Verdana", 8, XFontStyleEx.Regular);

            // Draw Backgroun
            DrawImage(gfx, "data\\blankMech.png", 0, 0, 430, 285);
            const string filename = "HelloWorld.pdf";

            // Write Mech Chassis + Variant (Trim to 29 ~ max size)
            gfx.DrawString(battleMech.chassis + " " + battleMech.variant, headerFont, XBrushes.Black,
              new XRect(12, 12, 250, 10),
              XStringFormats.CenterLeft);

            gfx.DrawString(battleMech.mass.ToString(), detailFont, XBrushes.Black,
              new XRect(33, 49, 100, 8),
              XStringFormats.CenterLeft);

            gfx.DrawString(battleMech.walk.ToString(), detailFont, XBrushes.Black,
              new XRect(33, 62, 100, 8),
              XStringFormats.CenterLeft);

            int tmm;

            switch (battleMech.walk)
            {
                case 0:
                case 1:
                case 2:
                    tmm = 0;
                    break;
                case 3:
                case 4:
                    tmm = 1;
                    break;
                case 5:
                case 6:
                    tmm = 2;
                    break;
                case 7:
                case 8:
                    tmm = 3;
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
                    tmm = 4;
                    break;
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    tmm = 5;
                    break;
                default: tmm = 6; break;
            }

            gfx.DrawString(tmm.ToString(), detailFont, XBrushes.Black,
              new XRect(33, 72, 100, 8),
              XStringFormats.CenterLeft);

            document.Save(filename);
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
    }
}
