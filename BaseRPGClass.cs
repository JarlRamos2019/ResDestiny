using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos
// GAME: Project R.D./Resonant Destiny
// FILE: BaseRPGClass.cs
// ORGN: Unity - RD Prototype I
// DATE: 17 August 2022
// =============================================================================

public class BaseRPGClass : MonoBehaviour
{
    public enum RPGStatTier
    {
        SS,
        S,
        A,
        B,
        C,
        D,
        E
    }

    public enum RPGClassType
    {
        Pugilist,
        Specialist,
        Arcanist,
        PugSpe,
        PugArc,
        SpeArc,
        PugSpeArc
    }

    [SerializeField] protected string RPGClassName;
    public RPGClassType rpgClassType;
    public RPGStatTier stTier;
    public RPGStatTier agTier;
    public RPGStatTier viTier;
    public RPGStatTier enTier;
    public RPGStatTier deTier;
    public RPGStatTier chTier;
    public RPGStatTier luTier;
    public RPGStatTier inTier;
    public RPGStatTier peTier;

    public Ally BaseAlly;
    public Statistic AllysSP;        // Skill points
    public Statistic AllysClassRank; // Class rank

    public List<EquipType> EqProficiencies = new List<EquipType>();
    public List<GameObject> RPGClassSkills = new List<GameObject>();

    /*
    public BaseRPGClass(string name, RPGClassType type, RPGStatTier s,
        RPGStatTier a, RPGStatTier v, RPGStatTier e, RPGStatTier d,
        RPGStatTier c, RPGStatTier l, RPGStatTier i, RPGStatTier p,
        List<EquipType> prof, List<BaseSkill> bSkill)
    {
        RPGClassName = name;
        rpgClassType = type;
        stTier = s;
        agTier = a;
        viTier = v;
        enTier = e;
        deTier = d;
        chTier = c;
        inTier = i;
        peTier = p;
        EqProficiencies = prof;
        RPGClassSkills = bSkill;

    }
    */

    public int CalculateBonus(RPGStatTier statTier)
    {
        int bonus = 0;
        switch (statTier)
        {
            case (RPGStatTier.SS):
                bonus = 70 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
            case (RPGStatTier.S):
                bonus = 50 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
            case (RPGStatTier.A):
                bonus = 40 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
            case (RPGStatTier.B):
                bonus = 30 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
            case (RPGStatTier.C):
                bonus = 20 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
            case (RPGStatTier.D):
                bonus = 10 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
            case (RPGStatTier.E):
                bonus = 5 * (int)(0.25f * AllysClassRank.GetVal() + 0.1f * BaseAlly.ActorLevel.GetVal());
                break;
        }

        return bonus;
    }

    public virtual void RPGClassEffects()
    {
        ;
    }

    /*
    public delegate void JobEffects();

    public JobEffects effectOnAssignment;
    public JobEffects effectOnDeassignment;
    */

    public string GetRPGClassName()
    {
        return RPGClassName;
    }
}
