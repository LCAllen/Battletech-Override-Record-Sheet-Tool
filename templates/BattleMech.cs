public class BattleMech
{
	public string chassis = "";
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
    public int armorHD = 0;
	public int armorLT = 0;
    public int armorCT = 0;
    public int armorRT = 0;
    public int armorLTR = 0;
    public int armorCTR = 0;
    public int armorRTR = 0;
    public int armorLL = 0;
    public int armorRL = 0;

    public List<Weapon> weapons;
    public List<Equipment> equip;
    public string weaponsString;
    public string equipString;

    internal BattleMech()
	{
        this.weapons = new List<Weapon>();
        this.equip = new List<Equipment>();
    }

	internal void printBattleMech()
	{
		Console.Out.WriteLine(chassis);
        Console.Out.WriteLine(variant);
        Console.Out.WriteLine(omnimech);
        Console.Out.WriteLine(mass);
        Console.Out.WriteLine(walk);
        Console.Out.WriteLine(jump);
        Console.Out.WriteLine(armorLA);
        Console.Out.WriteLine(armorRA);
        Console.Out.WriteLine(armorHD);
        Console.Out.WriteLine(armorLT);
        Console.Out.WriteLine(armorCT);
        Console.Out.WriteLine(armorRT);
        Console.Out.WriteLine(armorLTR);
        Console.Out.WriteLine(armorCTR);
        Console.Out.WriteLine(armorRTR);
        Console.Out.WriteLine(armorLL);
        Console.Out.WriteLine(armorRL);
	}
}
