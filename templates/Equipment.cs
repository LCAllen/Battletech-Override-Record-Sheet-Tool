using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public abstract class Equipment
{
    protected string displayName = "";
    protected string mtsName = "";
    protected string location = "";
    protected string subtype = "";

    public override string ToString()
    {
        return (this.displayName + " - "
            + this.subtype + " "
            + this.location.ToUpper());
    }
}
internal class Ammo : Equipment
{
    internal Ammo(string loc, string subtype)
    {
        this.displayName = "Ammo";
        this.mtsName = "Ammo";
        this.location = loc;
        this.subtype = subtype;

    }
}

internal class APods : Equipment
{
    internal APods(string loc, string subtype)
    {
        this.displayName = "A-Pods";
        this.mtsName = "AntiPersonnelPod";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class Probe : Equipment
{
    internal Probe(string loc, string subtype)
    {
        this.displayName = "Active Probe";
        this.mtsName = "ActiveProbe";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ECM : Equipment
{
    internal ECM(string loc, string subtype)
    {
        this.displayName = "ECM";
        this.mtsName = "ECM";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class EWEquipment : Equipment
{
    internal EWEquipment(string loc, string subtype)
    {
        this.displayName = "EW Equipment";
        this.mtsName = "ElectronicWarfareEquipment";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class C3 : Equipment
{
    internal C3(string loc, string subtype)
    {
        this.displayName = "C3";
        this.mtsName = "C3";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class FCS : Equipment
{
    internal FCS(string loc, string subtype)
    {
        this.displayName = "FCS";
        this.mtsName = "ArtemisIV";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class NARC : Equipment
{
    internal NARC(string loc, string subtype)
    {
        this.displayName = "NARC";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class TAG : Equipment
{
    internal TAG(string loc, string subtype)
    {
        this.displayName = "TAG";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class MASC : Equipment
{
    internal MASC(string loc, string subtype)
    {
        this.displayName = "MASC";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class Supercharger : Equipment
{
    internal Supercharger(string loc, string subtype)
    {
        this.displayName = "Supercharger";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class TSM : Equipment
{
    internal TSM(string loc, string subtype)
    {
        this.displayName = "TSM";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class PartialWing : Equipment
{
    internal PartialWing(string loc, string subtype)
    {
        this.displayName = "Partial Wing";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class AMS : Equipment
{
    internal AMS(string loc, string subtype)
    {
        this.displayName = "AMS";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class LAMS : Equipment
{
    internal LAMS(string loc, string subtype)
    {
        this.displayName = "LAMS";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class AES : Equipment
{
    internal AES(string loc, string subtype)
    {
        this.displayName = "AES";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ArmoredComponent : Equipment
{
    internal ArmoredComponent(string loc, string subtype)
    {
        this.displayName = "Armored Component";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class CASE : Equipment
{
    internal CASE(string loc, string subtype)
    {
        this.displayName = "CASE";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class CASEII : Equipment
{
    internal CASEII(string loc, string subtype)
    {
        this.displayName = "CASE II";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class HeavyDutyGyro : Equipment
{
    internal HeavyDutyGyro(string loc, string subtype)
    {
        this.displayName = "Heavy Duty Gyro";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ImprovedJumpJets : Equipment
{
    internal ImprovedJumpJets(string loc, string subtype)
    {
        this.displayName = "Improved Jump Jets";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ReflectiveArmor : Equipment
{
    internal ReflectiveArmor(string loc, string subtype)
    {
        this.displayName = "Reflective Armor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ReactiveArmor : Equipment
{
    internal ReactiveArmor(string loc, string subtype)
    {
        this.displayName = "Reactive Armor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class BallisticReinforcedArmor : Equipment
{
    internal BallisticReinforcedArmor(string loc, string subtype)
    {
        this.displayName = "Ballistic Reinforced Armor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class StealthArmor : Equipment
{
    internal StealthArmor(string loc, string subtype)
    {
        this.displayName = "Stealth Armor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class HardenedArmor : Equipment
{
    internal HardenedArmor(string loc, string subtype)
    {
        this.displayName = "Hardened Armor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class FerroLamellorArmor : Equipment
{
    internal FerroLamellorArmor(string loc, string subtype)
    {
        this.displayName = "Ferro-Lamellor Armor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class UMU : Equipment
{
    internal UMU(string loc, string subtype)
    {
        this.displayName = "UMU";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class MechanicalJumpBoosters : Equipment
{
    internal MechanicalJumpBoosters(string loc, string subtype)
    {
        this.displayName = "Mechanical Jump Boosters";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class CompositeStructure : Equipment
{
    internal CompositeStructure(string loc, string subtype)
    {
        this.displayName = "Composite Structure";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ReinforcedStructure : Equipment
{
    internal ReinforcedStructure(string loc, string subtype)
    {
        this.displayName = "Reinforced Structure";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class SmallCockpit : Equipment
{
    internal SmallCockpit(string loc, string subtype)
    {
        this.displayName = "Small Cockpit";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class TorsoMountedCockpit : Equipment
{
    internal TorsoMountedCockpit(string loc, string subtype)
    {
        this.displayName = "Torso Mounted Cockpit";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class TargetingComputer : Equipment
{
    internal TargetingComputer(string loc, string subtype)
    {
        this.displayName = "Targeting Computer";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class MeleeWeapon : Equipment
{
    internal MeleeWeapon(string loc, string subtype)
    {
        this.displayName = "Melee";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class Artillery : Equipment
{
    internal Artillery(string loc, string subtype)
    {
        this.displayName = "Artillery";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class PPCCapacitor : Equipment
{
    internal PPCCapacitor(string loc, string subtype)
    {
        this.displayName = "PPC Capacitor";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class ATM : Equipment
{
    internal ATM(string loc, string subtype)
    {
        this.displayName = "ATM";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class iATM : Equipment
{
    internal iATM(string loc, string subtype)
    {
        this.displayName = "iATM";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class C3M : Equipment
{
    internal C3M(string loc, string subtype)
    {
        this.displayName = "C3M";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class C3S : Equipment
{
    internal C3S(string loc, string subtype)
    {
        this.displayName = "C3S";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class XLEngine : Equipment
{
    internal XLEngine(string loc, string subtype)
    {
        this.displayName = "XL Engine";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class XXLEngine : Equipment
{
    internal XXLEngine(string loc, string subtype)
    {
        this.displayName = "XXL Engine";
        this.location = loc;
        this.subtype = subtype;
    }
}

internal class LEngine : Equipment
{
    internal LEngine(string loc, string subtype)
    {
        this.displayName = "Light Engine";
        this.location = loc;
        this.subtype = subtype;
    }
}

// missing BMM equipment: Full-Head Ejection System, Machine Gun Array, OS Missile Launcher
// missing ASC equipment: various non-mech, ARS, BAR, BHJ, SHLD, MAS, ABA, DN, ES, SEAL, IRA, etc.

// No "Ammo" special rule in Override CRB, Special Ammunition listed under Appendix, pg 45-46
// No reference to "A-Pods" in Override CRB (Only Coolant and ECM Ammo)
// No reference to "CASE" in Override CRB (only CASE II and Vehicle CASE, Override CRB pg 36)
// PPC Capacitor and iATM listed in Override CRB update notes, not equipment
// list organized in Override CRB order, save Ammo and A-Pods first, CASE before CASE II