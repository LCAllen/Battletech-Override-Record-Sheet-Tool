using System;
using System.Runtime.CompilerServices;
using System.Transactions;

public abstract class Weapon
{
    internal int amount = 0;
    internal string displayName = "";
    internal string damage = "";
    internal int heat = 0;
    internal string location = "";
    internal string pointBlankRange = "";
    internal string shortRange = "";
    internal string mediumRange = "";
    internal string longRange = "";
    internal string extraLongRange = "";

    public override string ToString()
    {
        if (this.amount == 1)
            return (this.displayName.PadRight(14)
                + (this.damage + '/' + this.heat).PadRight(10, ' ')
                + this.location.ToUpper().PadRight(8)
                + this.pointBlankRange.PadLeft(2)
                + ' ' + this.shortRange.PadLeft(2)
                + ' ' + this.mediumRange.PadLeft(2)
                + ' ' + this.longRange.PadLeft(2)
                + ' ' + this.extraLongRange.PadLeft(2));
        else 
        return (this.amount + " "
            + this.displayName.PadRight(12)
            + (this.damage + '/' + this.heat).PadRight(10, ' ')
            + this.location.ToUpper().PadRight(8)
            + this.pointBlankRange.PadLeft(2)
            + ' ' + this.shortRange.PadLeft(2)
            + ' ' + this.mediumRange.PadLeft(2)
            + ' ' + this.longRange.PadLeft(2)
            + ' ' + this.extraLongRange.PadLeft(2));
    }
}

// MG (AI)		1/0	0/0/-/-/-
internal class MG : Weapon
{
	internal MG(int amount, string loc)
	{
        this.amount = amount;
        this.displayName = "MG (AI)";
		this.damage = "1";
		this.heat = 0;
		this.location = loc;
		this.pointBlankRange = "+0";
		this.shortRange = "+0";
		this.mediumRange = "-";
		this.longRange = "-";
		this.extraLongRange = "-";
	}
}

// AC/2		1/0	4/2/0/2/4
internal class AC2 : Weapon
{
    internal AC2(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "AC/2";
        this.damage = "1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+4";
        this.shortRange = "+2";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// AC/5		2/0	2/0/2/4/-
internal class AC5 : Weapon
{
    internal AC5(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "AC/5";
        this.damage = "2";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+2";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// AC/10		4/1	0/0/2/4/-
internal class AC10 : Weapon
{
    internal AC10(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "AC/10";
        this.damage = "4";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// AC/20		7/1	0/0/2/-/-
internal class AC20 : Weapon
{
    internal AC20(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "AC/20";
        this.damage = "7";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// UAC/2 (RF)	1/0	2/0/0/2/2
internal class UAC2 : Weapon
{
    internal UAC2(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "UAC/2 (RF)";
        this.damage = "1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+2";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+2";
    }
}

// UAC/5 (RF)	2/0	0/0/0/2/4
internal class UAC5 : Weapon
{
    internal UAC5(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "UAC/5 (RF)";
        this.damage = "2";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// UAC/10 (RF)	4/1	0/0/2/4/-
internal class UAC10 : Weapon
{
    internal UAC10(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "UAC/10 (RF)";
        this.damage = "4";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// UAC/20 (RF)	7/1	0/0/2/-/-
internal class UAC20 : Weapon
{
    internal UAC20(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "UAC/20 (RF)";
        this.damage = "7";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// LB 2-X		1/0	4/2/0/2/2
internal class LB2X : Weapon
{
    internal LB2X(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LB 2-X";
        this.damage = "1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+4";
        this.shortRange = "+2";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+2";
    }
}

// LB 5-X	     1+C1/0	2/0/0/2/4
internal class LB5X : Weapon
{
    internal LB5X(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LB 5-X";
        this.damage = "1+C1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+2";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// LB 10-X     1+C3/0	0/0/2/4/-
internal class LB10X : Weapon
{
    internal LB10X(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LB 10-X";
        this.damage = "1+C3";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// LB 20-X     1+C6/1	0/0/2/-/-
internal class LB20X : Weapon
{
    internal LB20X(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LB 20-X";
        this.damage = "1+C6";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// SRM-2	  1+M1(2)/0	0/0/2/-/-
internal class SRM2 : Weapon
{
    internal SRM2(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "SRM-2";
        this.damage = "1+M1(2)";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// SRM-4	  1+M1(3)/1	0/0/2/-/-
internal class SRM4 : Weapon
{
    internal SRM4(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "SRM-4";
        this.damage = "1+M1(3)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// SRM-6	  1+M2(4)/1	0/0/2/-/-
internal class SRM6 : Weapon
{
    internal SRM6(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "SRM-6";
        this.damage = "1+M2(4)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// SSRM-2  1+M1(2)/0	0/0/2/-/-
internal class StreakSRM2 : Weapon
{
    internal StreakSRM2(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "Streak SRM-2";
        this.damage = "1+M1(2)";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// SSRM-4  1+M1(3)/1	0/0/2/-/-
internal class StreakSRM4 : Weapon
{
    internal StreakSRM4(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "Streak SRM-4";
        this.damage = "1+M1(3)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// SSRM-6  1+M2(4)/1	0/0/2/-/-
internal class StreakSRM6 : Weapon
{
    internal StreakSRM6(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "Streak SRM-6";
        this.damage = "1+M2(4)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// LRM-5	  1+M1(2)/0	4/2/0/2/4
internal class LRM5 : Weapon
{
    internal LRM5(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LRM-5";
        this.damage = "1+M1(2)";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+4";
        this.shortRange = "+2";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// LRM-10	  1+M2(4)/1	4/2/0/2/4
internal class LRM10 : Weapon
{
    internal LRM10(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LRM-10";
        this.damage = "1+M2(4)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+4";
        this.shortRange = "+2";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// LRM-15	  1+M3(5)/1	4/2/0/2/4
internal class LRM15 : Weapon
{
    internal LRM15(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LRM-15";
        this.damage = "1+M3(5)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+4";
        this.shortRange = "+2";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// LRM-20	  2+M3(7)/1	4/2/0/2/4
internal class LRM20 : Weapon
{
    internal LRM20(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "LRM-20";
        this.damage = "2+M3(7)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+4";
        this.shortRange = "+2";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// S Laser		1/0	0/0/-/-/-
internal class SLas : Weapon
{
    internal SLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "S Las";
        this.damage = "1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "-";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// M Laser		2/1	0/0/2/-/-
internal class MLas : Weapon
{
    internal MLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "M Las";
        this.damage = "2";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// L Laser		3/2	0/0/2/4/-
internal class LLas : Weapon
{
    internal LLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "L Las";
        this.damage = "3";
        this.heat = 2;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// ER S Laser	2/0	0/0/4/-/-
internal class erSLas : Weapon
{
    internal erSLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "ER S Las";
        this.damage = "2";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+4";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// ER M Laser	3/1	0/0/2/4/-
internal class erMLas : Weapon
{
    internal erMLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "ER M Las";
        this.damage = "3";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// ER L Laser	4/2	0/0/0/2/2
internal class erLLas : Weapon
{
    internal erLLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "ER L Las";
        this.damage = "4";
        this.heat = 2;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+2";
    }
}

// SP Laser (AI)	1/0    -2/-2/2/-/-
internal class SpLas : Weapon
{
    internal SpLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "S Pul Las (AI)";
        this.damage = "1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "-2";
        this.shortRange = "-2";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// MP Laser	3/1    -2/-2/0/-/-
internal class MpLas : Weapon
{
    internal MpLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "M Pul Las";
        this.damage = "3";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "-2";
        this.shortRange = "-2";
        this.mediumRange = "+0";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// LP Laser	4/2    -2/-2/-2/0/2
internal class LpLas : Weapon
{
    internal LpLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "L Pul Las";
        this.damage = "4";
        this.heat = 2;
        this.location = loc;
        this.pointBlankRange = "-2";
        this.shortRange = "-2";
        this.mediumRange = "-2";
        this.longRange = "0";
        this.extraLongRange = "+2";
    }
}

// PPC		4/2	2/0/2/4/-
internal class PPC : Weapon
{
    internal PPC(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "PPC";
        this.damage = "4";
        this.heat = 2;
        this.location = loc;
        this.pointBlankRange = "+2";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// ER PPC		5/3	0/0/0/2/4
internal class erPPC : Weapon
{
    internal erPPC(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "ER PPC";
        this.damage = "5";
        this.heat = 3;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// cFlamer	     1+H1/1	0/0/-/-/-
internal class Flamer : Weapon
{
    internal Flamer(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "Flamer";
        this.damage = "1+H1";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "-";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// erFlamer	     1+H1/1	0/0/-/-/-
internal class erFlamer : Weapon
{
    internal erFlamer(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "ER Flamer";
        this.damage = "1+H1";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "-";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// Gauss	5/0	2/0/0/2/4
internal class Gauss : Weapon
{
    internal Gauss(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "Gauss";
        this.damage = "5";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+2";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// Arrow IV	0/0	0/0/0/0/0
internal class ArrowIV : Weapon
{
    internal ArrowIV(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "Arrow IV";
        this.damage = "0";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+0";
        this.extraLongRange = "+0";
    }
}

// cMG (AI)	1/0	0/0/-/-/-
internal class cMG : Weapon
{
	internal cMG(int amount, string loc)
	{
        this.amount = amount;
        this.displayName = "cMG (AI)";
		this.damage = "1";
		this.heat = 0;
		this.location = loc;
		this.pointBlankRange = "+0";
		this.shortRange = "+0";
		this.mediumRange = "-";
		this.longRange = "-";
		this.extraLongRange = "-";
	}
}

// cUAC/2 (RF)	1/0	2/0/0/2/2
internal class cUAC2 : Weapon
{
	internal cUAC2(int amount, string loc)
	{
        this.amount = amount;
        this.displayName = "cUAC/2";
		this.damage = "1";
		this.heat = 0;
		this.location = loc;
		this.pointBlankRange = "+2";
		this.shortRange = "+0";
		this.mediumRange = "+0";
		this.longRange = "+2";
		this.extraLongRange = "+2";
	}
}

// cUAC/5 (RF)	2/0	0/0/0/2/4
internal class cUAC5 : Weapon
{
	internal cUAC5(int amount, string loc)
	{
        this.amount = amount;
        this.displayName = "cUAC/5";
		this.damage = "2";
		this.heat = 0;
		this.location = loc;
		this.pointBlankRange = "+0";
		this.shortRange = "+0";
		this.mediumRange = "+0";
		this.longRange = "+2";
		this.extraLongRange = "+4";
	}
}

// cUAC/10 (RF)	4/1	0/0/2/4/-
internal class cUAC10 : Weapon
{
	internal cUAC10(int amount, string loc)
	{
        this.amount = amount;
        this.displayName = "cUAC/10";
		this.damage = "4";
		this.heat = 1;
		this.location = loc;
		this.pointBlankRange = "+0";
		this.shortRange = "+0";
		this.mediumRange = "+2";
		this.longRange = "+4";
		this.extraLongRange = "-";
	}
}

// cUAC/20 (RF)	7/1	0/0/2/-/-
internal class cUAC20 : Weapon
{
	internal cUAC20(int amount, string loc)
	{
        this.amount = amount;
        this.displayName = "cUAC/20";
		this.damage = "7";
		this.heat = 1;
		this.location = loc;
		this.pointBlankRange = "+0";
		this.shortRange = "+0";
		this.mediumRange = "+2";
		this.longRange = "-";
		this.extraLongRange = "-";
	}
}
// cSRM-2	  1+M1(2)/0	0/0/2/-/-
internal class cSRM2 : Weapon
{
    internal cSRM2(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cSRM-2";
        this.damage = "1+M1(2)";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cSRM-4	  1+M1(3)/1	0/0/2/-/-
internal class cSRM4 : Weapon
{
    internal cSRM4(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cSRM-4";
        this.damage = "1+M1(3)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cSRM-6	  1+M2(4)/1	0/0/2/-/-
internal class cSRM6 : Weapon
{
    internal cSRM6(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cSRM-6";
        this.damage = "1+M2(4)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cSSRM-2  1+M1(2)/0	0/0/2/-/-
internal class cStreakSRM2 : Weapon
{
    internal cStreakSRM2(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cStreak SRM-2";
        this.damage = "1+M1(2)";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cSSRM-4  1+M1(3)/1	0/0/2/-/-
internal class cStreakSRM4 : Weapon
{
    internal cStreakSRM4(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cStreak SRM-4";
        this.damage = "1+M1(3)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cSSRM-6  1+M2(4)/1	0/0/2/-/-
internal class cStreakSRM6 : Weapon
{
    internal cStreakSRM6(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cStreak SRM-6";
        this.damage = "1+M2(4)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}
// cLRM-5	  1+M1(2)/0	0/0/0/2/4
internal class cLRM5 : Weapon
{
    internal cLRM5(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cLRM-5";
        this.damage = "1+M1(2)";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// cLRM-10	  1+M2(4)/1	0/0/0/2/4
internal class cLRM10 : Weapon
{
    internal cLRM10(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cLRM-10";
        this.damage = "1+M2(4)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// cLRM-15	  1+M3(5)/1	0/0/0/2/4
internal class cLRM15 : Weapon
{
    internal cLRM15(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cLRM-15";
        this.damage = "1+M3(5)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// cLRM-20	  2+M3(7)/1	0/0/0/2/4
internal class cLRM20 : Weapon
{
    internal cLRM20(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cLRM-20";
        this.damage = "2+M3(7)";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// cER S Laser	2/0	0/0/4/-/-
internal class cerSLas : Weapon
{
    internal cerSLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cER S Las";
        this.damage = "2";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+4";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cER M Laser	3/1	0/0/2/4/-
internal class cerMLas : Weapon
{
    internal cerMLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cER M Las";
        this.damage = "3";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+2";
        this.longRange = "+4";
        this.extraLongRange = "-";
    }
}

// cER L Laser	4/2	0/0/0/2/2
internal class cerLLas : Weapon
{
    internal cerLLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cER L Las";
        this.damage = "4";
        this.heat = 2;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+2";
    }
}

// cSP Laser (AI)	1/0    -2/-2/2/-/-
internal class cSpLas : Weapon
{
    internal cSpLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cS Pul Las";
        this.damage = "1";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "-2";
        this.shortRange = "-2";
        this.mediumRange = "+2";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cMP Laser	3/1    -2/-2/0/-/-
internal class cMpLas : Weapon
{
    internal cMpLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cM Pul Las";
        this.damage = "3";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "-2";
        this.shortRange = "-2";
        this.mediumRange = "+0";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}

// cLP Laser	4/2    -2/-2/-2/0/2
internal class cLpLas : Weapon
{
    internal cLpLas(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cL Pul Las";
        this.damage = "4";
        this.heat = 2;
        this.location = loc;
        this.pointBlankRange = "-2";
        this.shortRange = "-2";
        this.mediumRange = "-2";
        this.longRange = "0";
        this.extraLongRange = "+2";
    }
}

// cER PPC		5/3	0/0/0/2/4
internal class cerPPC : Weapon
{
    internal cerPPC(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cER PPC";
        this.damage = "5";
        this.heat = 3;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

internal class cGauss : Weapon
{
    internal cGauss(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cGauss";
        this.damage = "5";
        this.heat = 0;
        this.location = loc;
        this.pointBlankRange = "+2";
        this.shortRange = "+0";
        this.mediumRange = "+0";
        this.longRange = "+2";
        this.extraLongRange = "+4";
    }
}

// cFlamer	     1+H1/1	0/0/-/-/-
internal class cFlamer : Weapon
{
    internal cFlamer(int amount, string loc)
    {
        this.amount = amount;
        this.displayName = "cFlamer";
        this.damage = "1+H1";
        this.heat = 1;
        this.location = loc;
        this.pointBlankRange = "+0";
        this.shortRange = "+0";
        this.mediumRange = "-";
        this.longRange = "-";
        this.extraLongRange = "-";
    }
}
