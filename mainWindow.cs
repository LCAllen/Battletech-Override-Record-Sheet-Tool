using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace BORST
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }


        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Create battleMech object from the GUI
            BattleMech battleMech = BuildBattleMechFromGUI();
            BattleMechBuilder.DrawPDFFromBattleMech(battleMech);
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
            battleMech.armorCTR = int.Parse(textBoxArmorCTR.Text);
            battleMech.armorLTR = int.Parse(textBoxArmorLTR.Text);
            battleMech.armorRTR = int.Parse(textBoxArmorRTR.Text);
            battleMech.armorLL = int.Parse(textBoxArmorLL.Text);
            battleMech.armorRL = int.Parse(textBoxArmorRL.Text);

            // Populate weapon list from GUI listbox
            foreach (Weapon weapon in listBoxWeapon.Items)
            {
                battleMech.weapons.Add(weapon);
            }

            // Populate equipment list from GUI listbox
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
                    // If ammo is selected, populate subtypes
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

                case "CASE": comboBoxEquipmentSubtype.Items.Clear(); comboBoxEquipmentSubtype.Enabled = false; break;
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
                    // If ECM is selected, populate subtypes
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

        private void buttonBatchLoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
                textBoxBatchLoad.Text = openFolderDialog.SelectedPath;
        }

        private void buttonBatchGenerate_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(textBoxBatchLoad.Text);

            foreach (string file in files)
            {
                if (file.ToLower().Contains(".mtf"))
                {
                    BattleMech battleMech = BattleMechBuilder.BuildBattleMechFromMTFFile(file);
                    BattleMechBuilder.DrawPDFFromBattleMech(battleMech);
                }
            }
        }
    }
}
