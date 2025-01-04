using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos
// GAME: Project R.D./Resonant Destiny
// FILE: JobLibrary.cs
// ORGN: Unity - RD Prototype I
// DATE: 2 July 2023
// =============================================================================

public class JobLibrary : MonoBehaviour
{
    /*
    public static SkillLibrary skillLibrary;

    private List<BaseRPGClass> lib = new List<BaseRPGClass>();

    public BaseRPGClass Find(string jobName)
    {
        foreach (BaseRPGClass i in lib)
        {
            if (i.GetRPGClassName() == jobName)
            {
                return i;
            }
        }

        return null;
    }

    // =========================================================================
    // 001: Knight =============================================================
    // =========================================================================

    public static List<EquipType> knightProficiencies = new List<EquipType>();
    public static List<BaseSkill> knightSkills = new List<BaseSkill>();

    public void KnightJobEffectOnAssignment()
    {
        Knight.BaseAlly.St.Modify(20);
    }
    public void KnightJobEffectOnDeassignment()
    {
        Knight.BaseAlly.St.Modify(-20);
    }

    public BaseRPGClass Knight = new BaseRPGClass
    (
       "Knight",
       BaseRPGClass.RPGClassType.Pugilist,
       BaseRPGClass.RPGStatTier.S,
       BaseRPGClass.RPGStatTier.C,
       BaseRPGClass.RPGStatTier.E,
       BaseRPGClass.RPGStatTier.A,
       BaseRPGClass.RPGStatTier.D,
       BaseRPGClass.RPGStatTier.D,
       BaseRPGClass.RPGStatTier.C,
       BaseRPGClass.RPGStatTier.A,
       BaseRPGClass.RPGStatTier.C,
       knightProficiencies,
       knightSkills
    );

    // =========================================================================
    // 002: Moon Mage ==========================================================
    // =========================================================================

    public static List<EquipType> mmageProficiencies = new List<EquipType>();
    public static List<BaseSkill> mmageSkills = new List<BaseSkill>();

    public void MoonMageJobEffectOnAssignment()
    {

    }

    public void MoonMageJobEffectOnDeassignment()
    {

    }

    public BaseRPGClass MoonMage = new BaseRPGClass
    (
        "Moon Mage",
        BaseRPGClass.RPGClassType.Arcanist,
        BaseRPGClass.RPGStatTier.D,
        BaseRPGClass.RPGStatTier.C,
        BaseRPGClass.RPGStatTier.C,
        BaseRPGClass.RPGStatTier.B,
        BaseRPGClass.RPGStatTier.B,
        BaseRPGClass.RPGStatTier.C,
        BaseRPGClass.RPGStatTier.B,
        BaseRPGClass.RPGStatTier.A,
        BaseRPGClass.RPGStatTier.C,
        mmageProficiencies,
        mmageSkills
    );

    void Awake()
    {
        knightProficiencies.Add(EquipType.LightArmor);
        knightProficiencies.Add(EquipType.Shield);
        knightProficiencies.Add(EquipType.LightArmor);
        knightProficiencies.Add(EquipType.HeavyArmor);
        knightSkills.Add(skillLibrary.Slash);
        Knight.effectOnAssignment = KnightJobEffectOnAssignment;
        Knight.effectOnDeassignment = KnightJobEffectOnDeassignment;
        mmageProficiencies.Add(EquipType.Robe);
        mmageProficiencies.Add(EquipType.Buckler);
        mmageProficiencies.Add(EquipType.Staff);
        knightSkills.Add(skillLibrary.Fire);
        MoonMage.effectOnAssignment = MoonMageJobEffectOnAssignment;
        MoonMage.effectOnDeassignment = MoonMageJobEffectOnDeassignment;
        lib.Add(Knight);
        lib.Add(MoonMage);
    }
    */

}
