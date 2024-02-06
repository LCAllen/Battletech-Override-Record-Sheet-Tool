using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Windows.Shell;
using System.Windows.Documents;

namespace BORST
{
    internal class BattleMechBuilder
    {
        public static BattleMech BuildBattleMechFromMTFFile(string mtf)
        {
            BattleMech battleMech = new BattleMech();

            try { 
                using (var reader = new StreamReader(mtf))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (line != null)
                        {
                            if (line.ToLower().StartsWith("chassis:"))
                                battleMech.chassis = line.Split(':')[1];
                            if (line.ToLower().StartsWith("model:"))
                                battleMech.variant = line.Split(':')[1];
                            if (line.ToLower().StartsWith("config:"))
                                if (line.Split(':')[1].ToLower().Contains("omni"))
                                    battleMech.omnimech = true;
                            if (line.ToLower().StartsWith("techbase:"))
                                battleMech.techBase = line.Split(':')[1];
                            if (line.ToLower().StartsWith("mass:"))
                                battleMech.mass = int.Parse(line.Split(':')[1]);

                            if (line.ToLower().StartsWith("heat sinks:"))
                            {
                                battleMech.heatSinks = int.Parse(line.Split(':')[1].Split(' ')[0]);
                                if (line.Split(':')[1].Split(' ')[1] == "Double") battleMech.doubleHeatSinks = true;
                            }

                            if (line.ToLower().StartsWith("walk mp:"))
                                battleMech.walk = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("jump mp:"))
                                battleMech.jump = int.Parse(line.Split(':')[1]);

                            if (line.ToLower().StartsWith("armor:"))
                            {
                                line = line.Split(':')[1].ToLower();
                                line = line.Replace("(inner sphere)", "");
                                line = line.Replace("(clan)", "");
                                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(line);
                                battleMech.armorType = line;
                            }
                            if (line.ToLower().StartsWith("la armor:"))
                                battleMech.armorLA = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("ra armor:"))
                                battleMech.armorRA = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("lt armor:"))
                                battleMech.armorLT = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("rt armor:"))
                                battleMech.armorRT = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("ct armor:"))
                                battleMech.armorCT = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("hd armor:"))
                                battleMech.armorHD = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("ll armor:"))
                                battleMech.armorLL = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("rl armor:"))
                                battleMech.armorRL = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("rtl armor:"))
                                battleMech.armorLTR = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("rtr armor:"))
                                battleMech.armorRTR = int.Parse(line.Split(':')[1]);
                            if (line.ToLower().StartsWith("rtc armor:"))
                                battleMech.armorCTR = int.Parse(line.Split(':')[1]);

                            if (line.ToLower().StartsWith("weapons:"))
                            {
                                int numWeapons = int.Parse(line.Split(':')[1]);
                                ParseAndAddWeapons(battleMech, reader, numWeapons);
                            }

                            if (line.ToLower().StartsWith("left arm:")) ParseAndAddEquipment(battleMech, reader, "(LA)");
                            if (line.ToLower().StartsWith("right arm:")) ParseAndAddEquipment(battleMech, reader, "(RA)");
                            if (line.ToLower().StartsWith("left torso:")) ParseAndAddEquipment(battleMech, reader, "(T)");
                            if (line.ToLower().StartsWith("right torso:")) ParseAndAddEquipment(battleMech, reader, "(T)");
                            if (line.ToLower().StartsWith("center torso:")) ParseAndAddEquipment(battleMech, reader, "(T)");
                            if (line.ToLower().StartsWith("head:")) ParseAndAddEquipment(battleMech, reader, "(HD)");
                            if (line.ToLower().StartsWith("left leg:")) ParseAndAddEquipment(battleMech, reader, "(LL)");
                            if (line.ToLower().StartsWith("right leg:")) ParseAndAddEquipment(battleMech, reader, "(RL)");

                            battleMech.equip = battleMech.equip.GroupBy(x => x.ToString()).Select(x => x.First()).ToList();
                        }
                    }
                }
            }catch (Exception e)
            {
                MessageBox.Show("File input Error");
            }
            return battleMech;
        }

        private static void ParseAndAddEquipment(BattleMech battleMech, StreamReader reader, string location)
        {
            
            for (int i = 0; i < 12; i++)
            {
                var line = reader.ReadLine();
                
                // Quick and dirty fix to break the loop if not all 12 equipment slots are populated
                if (line == null) break;

                // Prep string for parsing
                string equip = line.ToLower();
                string sub = "";

                switch (equip)
                {
                    case string type when type.Contains("ammo"):
                        switch (type) 
                        {
                            case string subtype when subtype.Contains("mg"):
                                sub = "MG";
                                break;
                            case string subtype when subtype.Contains("machine gun"):
                                sub = "MG";
                                break;
                            case string subtype when subtype.Contains("lrm5"):
                                sub = "LRM-5";
                                break;
                            case string subtype when subtype.Contains("lrm10"):
                                sub = "LRM-10";
                                break;
                            case string subtype when subtype.Contains("lrm15"):
                                sub = "LRM-15";
                                break;
                            case string subtype when subtype.Contains("lrm20"):
                                sub = "LRM-20";
                                break;
                            case string subtype when subtype.Contains("srm2"):
                                sub = "SRM-2";
                                break;
                            case string subtype when subtype.Contains("srm4"):
                                sub = "SRM-4";
                                break;
                            case string subtype when subtype.Contains("srm6"):
                                sub = "SRM-6";
                                break;
                            case string subtype when subtype.Contains("lrm-5"):
                                sub = "LRM-5";
                                break;
                            case string subtype when subtype.Contains("lrm-10"):
                                sub = "LRM-10";
                                break;
                            case string subtype when subtype.Contains("lrm-15"):
                                sub = "LRM-15";
                                break;
                            case string subtype when subtype.Contains("lrm-20"):
                                sub = "LRM-20";
                                break;
                            case string subtype when subtype.Contains("srm-2"):
                                sub = "SRM-2";
                                break;
                            case string subtype when subtype.Contains("srm-4"):
                                sub = "SRM-4";
                                break;
                            case string subtype when subtype.Contains("srm-6"):
                                sub = "SRM-6";
                                break;
                            case string subtype when subtype.Contains("ac/20"):
                                sub = "AC/20";
                                break;
                            case string subtype when subtype.Contains("ac/10"):
                                sub = "AC/10";
                                break;
                            case string subtype when subtype.Contains("ac/5"):
                                sub = "AC/5";
                                break;
                            case string subtype when subtype.Contains("ac/2"):
                                sub = "AC/2";
                                break;
                            case string subtype when subtype.Contains("lb 20-x ac"):
                                sub = "LB20-X AC";
                                break;
                            case string subtype when subtype.Contains("lb 10-x ac"):
                                sub = "LB10-X AC";
                                break;
                            case string subtype when subtype.Contains("lb 5-x ac"):
                                sub = "LB5-X AC";
                                break;
                            case string subtype when subtype.Contains("lb 2-x ac"):
                                sub = "LB2-X AC";
                                break;
                            case string subtype when subtype.Contains("ultra ac/20"):
                                sub = "UAC/20";
                                break;
                            case string subtype when subtype.Contains("ultra ac/10"):
                                sub = "UAC/10";
                                break;
                            case string subtype when subtype.Contains("ultra ac/5"):
                                sub = "UAC/5";
                                break;
                            case string subtype when subtype.Contains("ultra ac/2"):
                                sub = "UAC/2";
                                break;  
                            case string subtype when subtype.Contains("gauss"):
                                sub = "Gauss";
                                break;
                            case string subtype when subtype.Contains("ams"):
                                sub = "AMS";
                                break;
                            case string subtype when subtype.Contains("arrowivhomingammo"):
                                sub = "Arrow IV - Homing";
                                break;
                            case string subtype when subtype.Contains("arrowivclusterammo"):
                                sub = "Arrow IV - Cluster";
                                break;
                            case string subtype when subtype.Contains("arrowivammo"):
                                sub = "Arrow IV";
                                break;
                        }
                        battleMech.equip.Add(new Ammo(location, sub));
                            break;
                    case string type when type.Contains("case"):
                        battleMech.equip.Add(new CASE(location, ""));
                        break;
                    case string type when type.Contains("caseii"):
                        battleMech.equip.Add(new CASEII(location, ""));
                        break;
                    case string type when type.Contains("antimissilesystem"):
                        battleMech.equip.Add(new AMS(location, ""));
                        break;
                    case string type when type.Contains("tag"):
                        battleMech.equip.Add(new TAG(location, ""));
                        break;
                    case string type when type.Contains("narc"):
                        battleMech.equip.Add(new NARC(location, ""));
                        break;
                    case string type when type.Contains("tsm"):
                        battleMech.equip.Add(new TSM(location, ""));
                        break;
                    case string type when type.Contains("masc"):
                        battleMech.equip.Add(new MASC(location, ""));
                        break;
                    case string type when type.Contains("supercharger"):
                        battleMech.equip.Add(new Supercharger(location, ""));
                        break;
                    case string type when type.Contains("aes"):
                        battleMech.equip.Add(new AES(location, ""));
                        break;
                    case string type when type.Contains("partial wing"):
                        battleMech.equip.Add(new PartialWing(location, ""));
                        break;
                    case string type when type.Contains("targeting computer"):
                        battleMech.equip.Add(new TargetingComputer(location, ""));
                        break;
                    case string type when type.Contains("ppc capacitor"):
                        battleMech.equip.Add(new PPCCapacitor(location, ""));
                        break;
                    case string type when type.Contains("electronicwarfareequipment"):
                        battleMech.equip.Add(new EWEquipment(location, ""));
                        break;
                    case string type when type.Contains("artemisiv"):
                        battleMech.equip.Add(new FCS(location, ""));
                        break;
                    case string type when type.Contains("ecm"):
                        switch (type)
                        {
                            case string subtype when subtype.Contains("guardian"):
                                sub = "Guardian";
                                break;
                            case string subtype when subtype.Contains("angel"):
                                sub = "Angel";
                                break;
                        }
                        break;
                }
            }

            // Create a list to store the duplicate items to remove
            List<Weapon> toRemove = new List<Weapon>();

            // Create a list that contains only distinct weapons
            List<Weapon> distinctWeapons = battleMech.weapons.GroupBy(x => x.displayName + x.location).Select(d => d.First()).ToList();
            
            // For each distinct weapon, count the duplicates and add the duplicates to the toRemove list
            foreach (Weapon weapon in distinctWeapons) 
            {
                List<Weapon> dupes = battleMech.weapons.FindAll(x => x.displayName + x.location == weapon.displayName + weapon.location).Skip(1).ToList();

                int amount = 0;
                foreach (var dupe in dupes)
                {
                    amount += dupe.amount;
                    toRemove.Add(dupe);
                }
                // Update the total count of the weapon
                weapon.amount += amount;
            }
            // Create a new list with the updated count and removed dupes
            List<Weapon> result = battleMech.weapons.Except(toRemove).ToList();
            battleMech.weapons = result;
        }

        private static void ParseAndAddWeapons(BattleMech battleMech, StreamReader reader, int numWeapons)
        {
            for(int i = 0;i < numWeapons;i++) 
            {
                var line = reader.ReadLine();

                int amount = 1;
                if (line != null && Char.IsNumber(line[0]))
                {
                    amount = int.Parse(line[0].ToString());
                    line = line.Remove(0, 1);
                }

                // Exit in error case
                if (line == null) break;

                // Format the weapon string into name and location
                string weapon = line.Split(',')[0].Replace(",", "").ToLower().Replace(" ", "").Replace("is", "").Replace("clan", "");
                string location = line.Split(',')[1].Replace(" ", "").ToLower();
                string locationCode = "";
                
                // Calc location
                switch (location)
                {
                    case "leftarm":
                        locationCode = "(LA)";
                         break;
                    case "rightarm":
                        locationCode = "(RA)";
                        break;
                    case "lefttorso":
                        locationCode = "(T)";
                        break;
                    case "righttorso":
                        locationCode = "(T)";
                        break;
                    case "centertorso":
                        locationCode = "(T)";
                        break;
                    case "head":
                        locationCode = "(HD)";
                        break;
                    case "leftleg":
                        locationCode = "(LL)";
                        break;
                    case "rightleg":
                        locationCode = "(RL)";
                        break;
                }

                // Figure out what type of weapon it is, then add it
                switch (weapon)
                {
                    case "machinegun":
                        if(battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new MG(amount, locationCode));
                        else battleMech.weapons.Add(new cMG(amount, locationCode));
                        break;
                    case "ac/2":
                        battleMech.weapons.Add(new AC2(amount, locationCode));
                        break;
                    case "ac/5":
                        battleMech.weapons.Add(new AC5(amount, locationCode));
                        break;
                    case "ac/10":
                        battleMech.weapons.Add(new AC10(amount, locationCode));
                        break;
                    case "ac/20":
                        battleMech.weapons.Add(new AC20(amount, locationCode));
                        break;
                    case "autocannon/2":
                        battleMech.weapons.Add(new AC2(amount, locationCode));
                        break;
                    case "autocannon/5":
                        battleMech.weapons.Add(new AC5(amount, locationCode));
                        break;
                    case "autocannon/10":
                        battleMech.weapons.Add(new AC10(amount, locationCode));
                        break;
                    case "autocannon/20":
                        battleMech.weapons.Add(new AC20(amount, locationCode));
                        break;
                    case "smalllaser":
                        battleMech.weapons.Add(new SLas(amount, locationCode));
                        break;
                    case "mediumlaser":
                        battleMech.weapons.Add(new MLas(amount, locationCode));
                        break;
                    case "largelaser":
                        battleMech.weapons.Add(new LLas(amount, locationCode));
                        break;
                    case "smallpulselaser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SpLas(amount, locationCode));
                        else battleMech.weapons.Add(new cSpLas(amount, locationCode));
                        break;
                    case "mediumpulselaser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new MpLas(amount, locationCode));
                        else battleMech.weapons.Add(new cMpLas(amount, locationCode));
                        break;
                    case "largepulselaser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LpLas(amount, locationCode));
                        else battleMech.weapons.Add(new cLpLas(amount, locationCode));
                        break;
                    case "ersmalllaser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erSLas(amount, locationCode));
                        else battleMech.weapons.Add(new cerSLas(amount, locationCode));
                        break;
                    case "ermediumlaser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erMLas(amount, locationCode));
                        else battleMech.weapons.Add(new cerMLas(amount, locationCode));
                        break;
                    case "erlargelaser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erLLas(amount, locationCode));
                        else battleMech.weapons.Add(new cerLLas(amount, locationCode));
                        break;
                    case "ppc":
                        battleMech.weapons.Add(new PPC(amount, locationCode));
                        break;
                    case "erppc":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erPPC(amount, locationCode));
                        else battleMech.weapons.Add(new cerPPC(amount, locationCode));
                        break;
                    case "gaussrifle":
                        battleMech.weapons.Add(new Gauss(amount, locationCode));
                        break;
                    case "arrowiv":
                        battleMech.weapons.Add(new ArrowIV(amount, locationCode));
                        break;
                    case "lrm5":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM5(amount, locationCode));
                        else battleMech.weapons.Add(new cLRM5(amount, locationCode));
                        break;
                    case "lrm10":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM10(amount, locationCode));
                        else battleMech.weapons.Add(new cLRM10(amount, locationCode));
                        break;
                    case "lrm15":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM15(amount, locationCode));
                        else battleMech.weapons.Add(new cLRM15(amount, locationCode));
                        break;
                    case "lrm20":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM20(amount, locationCode));
                        else battleMech.weapons.Add(new cLRM20(amount, locationCode));
                        break;
                    case "srm2":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SRM2(amount, locationCode));
                        else battleMech.weapons.Add(new cSRM2(amount, locationCode));
                        break;
                    case "srm4":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SRM4(amount, locationCode));
                        else battleMech.weapons.Add(new cSRM4(amount, locationCode));
                        break;
                    case "srm6":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SRM6(amount, locationCode));
                        else battleMech.weapons.Add(new cSRM6(amount, locationCode));
                        break;
                    case "lb2-xac":
                        battleMech.weapons.Add(new LB2X(amount, locationCode));
                        break;
                    case "lb5-xac":
                        battleMech.weapons.Add(new LB5X(amount, locationCode));
                        break;
                    case "lb10-xac":
                        battleMech.weapons.Add(new LB10X(amount, locationCode));
                        break;
                    case "lb20-xac":
                        battleMech.weapons.Add(new LB20X(amount, locationCode));
                        break;
                    case "ultraac/2":
                        battleMech.weapons.Add(new UAC2(amount, locationCode));
                        break;
                    case "ultraac/5":
                        battleMech.weapons.Add(new UAC5(amount, locationCode));
                        break;
                    case "ultraac/10":
                        battleMech.weapons.Add(new UAC10(amount, locationCode));
                        break;
                    case "ultraac/20":
                        battleMech.weapons.Add(new UAC20(amount, locationCode));
                        break;
                    case "flamer":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new Flamer(amount, locationCode));
                        else battleMech.weapons.Add(new cFlamer(amount, locationCode));
                        break;
                    case "erflamer":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erFlamer(amount, locationCode));
                        else battleMech.weapons.Add(new erFlamer(amount, locationCode));
                        break;
                }
            }
        }

        public static void DrawPDFFromBattleMech(BattleMech battleMech)
        {

            void DrawImage(XGraphics gfx, string path, int x, int y, int width, int height)
            {
                XImage image = XImage.FromFile(path);
                gfx.DrawImage(image, x, y, width, height);
            }

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
            // Pick background based on tonnage
            switch (battleMech.mass)
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
                default:
                    blankPdfPath = "data\\blankMech_100t.png"; break;
            }

            // Draw background
            DrawImage(gfx, blankPdfPath, 0, 0, 504, 360);

            // Calc mech name
            string nameAndVariant = "";
            nameAndVariant = battleMech.chassis + " " + battleMech.variant;
            string filename;
            if (nameAndVariant != "") filename = nameAndVariant + ".pdf"; else filename = "Error";
            document.Info.Title = nameAndVariant;

            // Write Mech Chassis + Variant (Trim to 29 ~ max size)
            tf.DrawString(battleMech.chassis + " " + battleMech.variant, headerFont, XBrushes.Black,
              new XRect(13, 12, 250, 20),
              XStringFormats.TopLeft);

            // Draw omnimech status
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

            // Draw tonnage
            tf.DrawString(battleMech.mass.ToString() + " Tons", detailFont, XBrushes.Black,
              new XRect(41, 62, 100, 10),
              XStringFormats.TopLeft);

            // Draw walk speed
            tf.DrawString(battleMech.walk.ToString(), detailFont, XBrushes.Black,
              new XRect(40, 79, 100, 10),
              XStringFormats.TopLeft);

            // Draw sprint speed
            tf.DrawString(" / " + Math.Ceiling(battleMech.walk * 1.5).ToString(), detailFont, XBrushes.Black,
              new XRect(46, 79, 100, 10),
              XStringFormats.TopLeft);

            // Calc cooling
            int cooling;
            if (!battleMech.doubleHeatSinks)
            {
                cooling = (int)((battleMech.heatSinks + 2) / 5);
            }
            else
            {
                cooling = (int)((battleMech.heatSinks + 1) / 2.5);
            }

            // Draw cooling
            tf.DrawString(cooling.ToString(), detailFont, XBrushes.Black,
              new XRect(130, 79, 100, 10),
              XStringFormats.TopLeft);

            // Calc walk TMM
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

            // Draw walk TMM
            tf.DrawString(tmmWalk.ToString(), detailFont, XBrushes.Black,
              new XRect(40, 91, 100, 10),
              XStringFormats.TopLeft);

            // Calc run TMM
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

            // Draw run TMM
            tf.DrawString(" / " + tmmRun.ToString(), detailFont, XBrushes.Black,
              new XRect(46, 91, 100, 10),
              XStringFormats.TopLeft);

            // Calc jump TMM
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

                // Draw jump TMM
                tf.DrawString(" / " + tmmJump.ToString(), detailFont, XBrushes.Black,
                  new XRect(61, 91, 100, 10),
                  XStringFormats.TopLeft);
            }

            // Draw weapon list
            string allWeapons = "";
            foreach (Weapon weapon in battleMech.weapons)
            {
                allWeapons += (weapon.ToString() + '\n');
            }
            tf.DrawString(allWeapons, weaponFont, XBrushes.Black,
              new XRect(16, 124, 250, 100),
              XStringFormats.TopLeft);

            // Draw equipment list
            string allEquipment = "";
            foreach (Equipment equip in battleMech.equip)
            {
                allEquipment += (equip.ToString() + " | ");
            }
            tf.DrawString(allEquipment, detailFont, XBrushes.Black,
              new XRect(55, 273, 180, 60),
              XStringFormats.TopLeft);

            // Calc melee damage
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

            // Draw melee damage
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

            // Calc head armor
            HDArmorPips = (int)Math.Floor(battleMech.armorHD / 2.0);
            if (HDArmorPips == 0) HDArmorPips = 1;

            // Draw head armor
            switch (HDArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsHD\\HD1.png", 374, 75, 25, 14);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsHD\\HD2.png", 374, 75, 25, 14);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsHD\\HD3.png", 374, 75, 25, 14);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsHD\\HD4.png", 374, 75, 25, 14);
                    break;
            }

            // Calc torso armor
            TArmorPips = (int)Math.Round((battleMech.armorCT + battleMech.armorLT + battleMech.armorRT) / 6.0, 0, MidpointRounding.AwayFromZero);
            if (TArmorPips == 0) TArmorPips = 1;

            // Draw torso armor
            switch (TArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsCT\\CT1.png", 354, 120, 66, 21);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsCT\\CT2.png", 354, 120, 66, 21);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsCT\\CT3.png", 354, 120, 66, 21);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsCT\\CT4.png", 354, 120, 66, 21);
                    break;
                case 5:
                    DrawImage(gfx, "data\\pipsCT\\CT5.png", 354, 120, 66, 21);
                    break;
                case 6:
                    DrawImage(gfx, "data\\pipsCT\\CT6.png", 354, 120, 66, 21);
                    break;
                case 7:
                    DrawImage(gfx, "data\\pipsCT\\CT7.png", 354, 120, 66, 21);
                    break;
                case 8:
                    DrawImage(gfx, "data\\pipsCT\\CT8.png", 354, 120, 66, 21);
                    break;
                case 9:
                    DrawImage(gfx, "data\\pipsCT\\CT9.png", 354, 120, 66, 21);
                    break;
                case 10:
                    DrawImage(gfx, "data\\pipsCT\\CT10.png", 354, 120, 66, 21);
                    break;
                case 11:
                    DrawImage(gfx, "data\\pipsCT\\CT11.png", 354, 120, 66, 21);
                    break;
                case 12:
                    DrawImage(gfx, "data\\pipsCT\\CT12.png", 354, 120, 66, 21);
                    break;
                case 13:
                    DrawImage(gfx, "data\\pipsCT\\CT13.png", 354, 120, 66, 21);
                    break;
                case 14:
                    DrawImage(gfx, "data\\pipsCT\\CT14.png", 354, 120, 66, 21);
                    break;
                case 15:
                    DrawImage(gfx, "data\\pipsCT\\CT15.png", 354, 120, 66, 21);
                    break;
                case 16:
                    DrawImage(gfx, "data\\pipsCT\\CT16.png", 354, 120, 66, 21);
                    break;
                case 17:
                    DrawImage(gfx, "data\\pipsCT\\CT17.png", 354, 120, 66, 21);
                    break;
                case 18:
                    DrawImage(gfx, "data\\pipsCT\\CT18.png", 354, 120, 66, 21);
                    break;
                case 19:
                    DrawImage(gfx, "data\\pipsCT\\CT19.png", 354, 120, 66, 21);
                    break;
                case 20:
                    DrawImage(gfx, "data\\pipsCT\\CT20.png", 354, 120, 66, 21);
                    break;
                case 21:
                    DrawImage(gfx, "data\\pipsCT\\CT21.png", 354, 120, 66, 21);
                    break;
                    // ...
            }

            // Calc rear torso armor
            RTArmorPips = (int)Math.Round((battleMech.armorCTR + battleMech.armorLTR + battleMech.armorRTR) / 6.0, 0, MidpointRounding.AwayFromZero);
            if (RTArmorPips == 0) RTArmorPips = 1;

            // Draw rear torso armor
            switch (RTArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsRT\\RT1.png", 374, 288, 24, 27);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsRT\\RT2.png", 374, 288, 24, 27);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsRT\\RT3.png", 374, 288, 24, 27);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsRT\\RT4.png", 374, 288, 24, 27);
                    break;
                case 5:
                    DrawImage(gfx, "data\\pipsRT\\RT5.png", 374, 288, 24, 27);
                    break;
                case 6:
                    DrawImage(gfx, "data\\pipsRT\\RT6.png", 374, 288, 24, 27);
                    break;
                case 7:
                    DrawImage(gfx, "data\\pipsRT\\RT7.png", 374, 288, 24, 27);
                    break;
                case 8:
                    DrawImage(gfx, "data\\pipsRT\\RT8.png", 374, 288, 24, 27);
                    break;
                case 9:
                    DrawImage(gfx, "data\\pipsRT\\RT9.png", 374, 288, 24, 27);
                    break;
                case 10:
                    DrawImage(gfx, "data\\pipsRT\\RT10.png", 374, 288, 24, 27);
                    break;
                    // ...
            }
            // Calc left arm armor
            LAArmorPips = (int)Math.Floor((battleMech.armorLA + 1) / 3.0);
            if (LAArmorPips == 0) LAArmorPips = 1;

            // Draw left arm armor
            switch (LAArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsLA\\LA1.png", 303, 104, 19, 40);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsLA\\LA2.png", 303, 104, 19, 40);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsLA\\LA3.png", 303, 104, 19, 40);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsLA\\LA4.png", 303, 104, 19, 40);
                    break;
                case 5:
                    DrawImage(gfx, "data\\pipsLA\\LA5.png", 303, 104, 19, 40);
                    break;
                case 6:
                    DrawImage(gfx, "data\\pipsLA\\LA6.png", 303, 104, 19, 40);
                    break;
                case 7:
                    DrawImage(gfx, "data\\pipsLA\\LA7.png", 303, 104, 19, 40);
                    break;
                case 8:
                    DrawImage(gfx, "data\\pipsLA\\LA8.png", 303, 104, 19, 40);
                    break;
                case 9:
                    DrawImage(gfx, "data\\pipsLA\\LA9.png", 303, 104, 19, 40);
                    break;
                case 10:
                    DrawImage(gfx, "data\\pipsLA\\LA10.png", 303, 104, 19, 40);
                    break;
                case 11:
                    DrawImage(gfx, "data\\pipsLA\\LA11.png", 303, 104, 19, 40);
                    break;
                    // ...
            }

            // Calc right arm armor
            RAArmorPips = (int)Math.Floor((battleMech.armorRA + 1) / 3.0);
            if (RAArmorPips == 0) RAArmorPips = 1;

            // Draw right arm armor
            switch (RAArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsRA\\RA1.png", 450, 104, 19, 40);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsRA\\RA2.png", 450, 104, 19, 40);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsRA\\RA3.png", 450, 104, 19, 40);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsRA\\RA4.png", 450, 104, 19, 40);
                    break;
                case 5:
                    DrawImage(gfx, "data\\pipsRA\\RA5.png", 450, 104, 19, 40);
                    break;
                case 6:
                    DrawImage(gfx, "data\\pipsRA\\RA6.png", 450, 104, 19, 40);
                    break;
                case 7:
                    DrawImage(gfx, "data\\pipsRA\\RA7.png", 450, 104, 19, 40);
                    break;
                case 8:
                    DrawImage(gfx, "data\\pipsRA\\RA8.png", 450, 104, 19, 40);
                    break;
                case 9:
                    DrawImage(gfx, "data\\pipsRA\\RA9.png", 450, 104, 19, 40);
                    break;
                case 10:
                    DrawImage(gfx, "data\\pipsRA\\RA10.png", 450, 104, 19, 40);
                    break;
                case 11:
                    DrawImage(gfx, "data\\pipsRA\\RA11.png", 450, 104, 19, 40);
                    break;
                    // ...
            }

            // Calc left leg armor
            LLArmorPips = (int)Math.Floor((battleMech.armorLL + 1) / 3.0);
            if (LLArmorPips == 0) LLArmorPips = 1;

            // Draw left leg armor
            switch (LLArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsLL\\LL1.png", 336, 222, 26, 47);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsLL\\LL2.png", 336, 222, 26, 47);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsLL\\LL3.png", 336, 222, 26, 47);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsLL\\LL4.png", 336, 222, 26, 47);
                    break;
                case 5:
                    DrawImage(gfx, "data\\pipsLL\\LL5.png", 336, 222, 26, 47);
                    break;
                case 6:
                    DrawImage(gfx, "data\\pipsLL\\LL6.png", 336, 222, 26, 47);
                    break;
                case 7:
                    DrawImage(gfx, "data\\pipsLL\\LL7.png", 336, 222, 26, 47);
                    break;
                case 8:
                    DrawImage(gfx, "data\\pipsLL\\LL8.png", 336, 222, 26, 47);
                    break;
                case 9:
                    DrawImage(gfx, "data\\pipsLL\\LL9.png", 336, 222, 26, 47);
                    break;
                case 10:
                    DrawImage(gfx, "data\\pipsLL\\LL10.png", 336, 222, 26, 47);
                    break;
                case 11:
                    DrawImage(gfx, "data\\pipsLL\\LL11.png", 336, 222, 26, 47);
                    break;
                case 12:
                    DrawImage(gfx, "data\\pipsLL\\LL12.png", 336, 222, 26, 47);
                    break;
                case 13:
                    DrawImage(gfx, "data\\pipsLL\\LL13.png", 336, 222, 26, 47);
                    break;
                case 14:
                    DrawImage(gfx, "data\\pipsLL\\LL14.png", 336, 222, 26, 47);
                    break;
            }

            // Calc right leg armor
            RLArmorPips = (int)Math.Floor((battleMech.armorRL + 1) / 3.0);
            if (RLArmorPips == 0) RLArmorPips = 1;

            // Draw right leg armor
            switch (RLArmorPips)
            {
                case 1:
                    DrawImage(gfx, "data\\pipsRL\\RL1.png", 411, 222, 26, 47);
                    break;
                case 2:
                    DrawImage(gfx, "data\\pipsRL\\RL2.png", 411, 222, 26, 47);
                    break;
                case 3:
                    DrawImage(gfx, "data\\pipsRL\\RL3.png", 411, 222, 26, 47);
                    break;
                case 4:
                    DrawImage(gfx, "data\\pipsRL\\RL4.png", 411, 222, 26, 47);
                    break;
                case 5:
                    DrawImage(gfx, "data\\pipsRL\\RL5.png", 411, 222, 26, 47);
                    break;
                case 6:
                    DrawImage(gfx, "data\\pipsRL\\RL6.png", 411, 222, 26, 47);
                    break;
                case 7:
                    DrawImage(gfx, "data\\pipsRL\\RL7.png", 411, 222, 26, 47);
                    break;
                case 8:
                    DrawImage(gfx, "data\\pipsRL\\RL8.png", 411, 222, 26, 47);
                    break;
                case 9:
                    DrawImage(gfx, "data\\pipsRL\\RL9.png", 411, 222, 26, 47);
                    break;
                case 10:
                    DrawImage(gfx, "data\\pipsRL\\RL10.png", 411, 222, 26, 47);
                    break;
                case 11:
                    DrawImage(gfx, "data\\pipsRL\\RL11.png", 411, 222, 26, 47);
                    break;
                case 12:
                    DrawImage(gfx, "data\\pipsRL\\RL12.png", 411, 222, 26, 47);
                    break;
                case 13:
                    DrawImage(gfx, "data\\pipsRL\\RL13.png", 411, 222, 26, 47);
                    break;
                case 14:
                    DrawImage(gfx, "data\\pipsRL\\RL14.png", 411, 222, 26, 47);
                    break;
                    // ...
            }

            // Save and close
            document.Save(filename);
            document.Close();

            gfx.Dispose();
        }
    }
}