using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static System.Windows.Forms.LinkLabel;

namespace BORST
{
    internal class BattleMechBuilder
    {
        public static BattleMech BuildBattleMechFromMTFFile(string mtf)
        {
            BattleMech battleMech = new BattleMech();

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
                            battleMech.armorHead = int.Parse(line.Split(':')[1]);
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
            return battleMech;
        }

        private static void ParseAndAddEquipment(BattleMech battleMech, StreamReader reader, string location)
        {
            
            for (int i = 0; i < 12; i++)
            {
                var line = reader.ReadLine();
                string equip = line.ToLower();
                string sub = "";

                switch (equip)
                {
                    case string type when type.Contains("ammo"):
                        switch (type) 
                        {
                            case string subtype when subtype.Contains("lrm-5"):
                                sub = "LRM-5";
                                break;
                            case string subtype when subtype.Contains("lrm-10"):
                                sub = "LRM-10";
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
                            case string subtype when subtype.Contains("ac/2"):
                                sub = "AC/2";
                                break;
                            case string subtype when subtype.Contains("ac/5"):
                                sub = "AC/5";
                                break;
                            case string subtype when subtype.Contains("ac/10"):
                                sub = "AC/10";
                                break;
                            case string subtype when subtype.Contains("ac/20"):
                                sub = "AC/20";
                                break;
                            case string subtype when subtype.Contains("lb 2-x ac"):
                                sub = "LB 2-X AC";
                                break;
                            case string subtype when subtype.Contains("lb 5-x ac"):
                                sub = "LB 5-X AC";
                                break;
                            case string subtype when subtype.Contains("lb 10-x ac"):
                                sub = "LB 10-X AC";
                                break;
                            case string subtype when subtype.Contains("lb 20-x ac"):
                                sub = "LB 10-X AC";
                                break;
                            case string subtype when subtype.Contains("ultra ac/2"):
                                sub = "UAC/2";
                                break;
                            case string subtype when subtype.Contains("ultra ac/5"):
                                sub = "UAC/5";
                                break;
                            case string subtype when subtype.Contains("ultra ac/10"):
                                sub = "UAC/10";
                                break;
                            case string subtype when subtype.Contains("ultra ac/20"):
                                sub = "UAC/20";
                                break;
                            case string subtype when subtype.Contains("gauss"):
                                sub = "Gauss";
                                break;
                            case string subtype when subtype.Contains("ams"):
                                sub = "AMS";
                                break;
                            case string subtype when subtype.Contains("arrowivammo"):
                                sub = "Arrow IV";
                                break;
                            case string subtype when subtype.Contains("arrowivhomingammo"):
                                sub = "Arrow IV - Homing";
                                break;
                            case string subtype when subtype.Contains("arrowivclusterammo"):
                                sub = "Arrow IV - Cluster";
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
        }

        private static void ParseAndAddWeapons(BattleMech battleMech, StreamReader reader, int numWeapons)
        {
            for(int i = 0;i < numWeapons;i++) 
            {
                var line = reader.ReadLine();
                string weapon = line.Split(',')[0].Replace(",", "").ToLower();
                string location = line.Split(',')[1].Replace(" ", "").ToLower();
                string locationCode = "";
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
                switch (weapon)
                {
                    case "machine gun":
                        if(battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new MG(locationCode));
                        else battleMech.weapons.Add(new cMG(locationCode));
                        break;
                    case "ac/2":
                        battleMech.weapons.Add(new AC2(locationCode));
                        break;
                    case "ac/5":
                        battleMech.weapons.Add(new AC5(locationCode));
                        break;
                    case "ac/10":
                        battleMech.weapons.Add(new AC10(locationCode));
                        break;
                    case "ac/20":
                        battleMech.weapons.Add(new AC10(locationCode));
                        break;
                    case "small laser":
                        battleMech.weapons.Add(new SLas(locationCode));
                        break;
                    case "medium laser":
                        battleMech.weapons.Add(new MLas(locationCode));
                        break;
                    case "large laser":
                        battleMech.weapons.Add(new LLas(locationCode));
                        break;
                    case "small pulse laser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SpLas(locationCode));
                        else battleMech.weapons.Add(new cSpLas(locationCode));
                        break;
                    case "medium pulse laser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new MpLas(locationCode));
                        else battleMech.weapons.Add(new cMpLas(locationCode));
                        break;
                    case "large pulse laser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LpLas(locationCode));
                        else battleMech.weapons.Add(new cLpLas(locationCode));
                        break;
                    case "er small laser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erSLas(locationCode));
                        else battleMech.weapons.Add(new cerSLas(locationCode));
                        break;
                    case "er medium laser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erMLas(locationCode));
                        else battleMech.weapons.Add(new cerMLas(locationCode));
                        break;
                    case "er large laser":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erLLas(locationCode));
                        else battleMech.weapons.Add(new cerLLas(locationCode));
                        break;
                    case "ppc":
                        battleMech.weapons.Add(new PPC(locationCode));
                        break;
                    case "er ppc":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erPPC(locationCode));
                        else battleMech.weapons.Add(new cerPPC(locationCode));
                        break;
                    case "gauss rifle":
                        battleMech.weapons.Add(new Gauss(locationCode));
                        break;
                    case "arrow iv":
                        battleMech.weapons.Add(new ArrowIV(locationCode));
                        break;
                    case "lrm 5":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM5(locationCode));
                        else battleMech.weapons.Add(new cLRM5(locationCode));
                        break;
                    case "lrm 10":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM10(locationCode));
                        else battleMech.weapons.Add(new cLRM10(locationCode));
                        break;
                    case "lrm 15":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM15(locationCode));
                        else battleMech.weapons.Add(new cLRM15(locationCode));
                        break;
                    case "lrm 20":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new LRM20(locationCode));
                        else battleMech.weapons.Add(new cLRM20(locationCode));
                        break;
                    case "srm 2":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SRM2(locationCode));
                        else battleMech.weapons.Add(new cSRM2(locationCode));
                        break;
                    case "srm 4":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SRM4(locationCode));
                        else battleMech.weapons.Add(new cSRM4(locationCode));
                        break;
                    case "srm 6":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new SRM6(locationCode));
                        else battleMech.weapons.Add(new cSRM6(locationCode));
                        break;
                    case "lb 2-x ac":
                        battleMech.weapons.Add(new LB2X(locationCode));
                        break;
                    case "lb 5-x ac":
                        battleMech.weapons.Add(new LB5X(locationCode));
                        break;
                    case "lb 10-x ac":
                        battleMech.weapons.Add(new LB10X(locationCode));
                        break;
                    case "lb 20-c ac":
                        battleMech.weapons.Add(new LB20X(locationCode));
                        break;
                    case "ultra ac/2":
                        battleMech.weapons.Add(new UAC2(locationCode));
                        break;
                    case "ultra ac/5":
                        battleMech.weapons.Add(new UAC5(locationCode));
                        break;
                    case "ultra ac/10":
                        battleMech.weapons.Add(new UAC10(locationCode));
                        break;
                    case "ultra ac/20":
                        battleMech.weapons.Add(new UAC20(locationCode));
                        break;
                    case "flamer":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new Flamer(locationCode));
                        else battleMech.weapons.Add(new cFlamer(locationCode));
                        break;
                    case "er flamer":
                        if (battleMech.techBase == "Inner Sphere") battleMech.weapons.Add(new erFlamer(locationCode));
                        else battleMech.weapons.Add(new erFlamer(locationCode));
                        break;
                }
            }
        }

        public static BattleMech BuildBattleMechFromGUI()
        {
            BattleMech battleMech = new BattleMech();
            
                return battleMech;
        }

        public static BattleMech BuildTestBattleMech()
        {
            BattleMech battleMech = new BattleMech
            {
                chassis = "Marauder",
                variant = "MAD-1R",
                mass = 75,
                omnimech = false,
                heatSinks = 16,
                doubleHeatSinks = false,
                walk = 4,
                jump = 0,
                weapons = new List<Weapon>() { new PPC("la"), new MLas("la"), new PPC("ra"), new MLas("la"), new AC5("rt") },
                equip = new List<Equipment> { new Ammo("AC/5", "RT"), new CASE("RT", "") }
            };

            return battleMech;
        }
    }
}