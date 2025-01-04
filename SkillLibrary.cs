using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos
// GAME: Project R.D./Resonant Destiny
// FILE: SkillLibrary.cs
// ORGN: Unity - RD Prototype I
// DATE: 2 July 2023
// =============================================================================

public class SkillLibrary : MonoBehaviour
{

    /*
    private List<BattleSkill> lib = new List<BattleSkill>();

    public BattleSkill Find(string skillName)
    {
        foreach (BattleSkill i in lib)
        {
            if (i.GetSkillName() == skillName)
            {
                return i;
            }
        }
        return null;
    }
    /*
     * BATTLE SKILL SYNTAX:
     * Name
     * Description
     * Skill Type
     * Healing
     * MP Cost
     * HP Cost
     * Components
     * Target
     * Damage
     * Re Cost
     * Skill Speed
     * Duration
     * Sequence Function
     * Sequence Function With Multiple Targets
     * AP Cost
     */

    /*
    // =========================================================================
    // 001: Slash ==============================================================
    // =========================================================================

    private static List<Comp> SlashComp = new List<Comp>();

    private static void SlashSequence(Actor target)
    {

    }

    public BattleSkill Slash = new BattleSkill(
        "Slash",
        "A sword attack.",
        BaseSkill.SkillType.Martial,
        0,
        0,
        0,
        SlashComp,
        BaseSkill.SkillTarget.OneEnemy,
        500,
        0,
        12,
        1,
        SlashSequence,
        null,
        1
        );



    // =========================================================================
    // 002: Fire ===============================================================
    // =========================================================================

    private static List<Comp> FireComp = new List<Comp>();

    private static void FireSequence(Actor target)
    {

    }

    public BattleSkill Fire = new BattleSkill(
        "Fire",
        "Shoot a magical fireball at one enemy.",
        BaseSkill.SkillType.MoonMagic,
        0,
        4,
        0,
        FireComp,
        BaseSkill.SkillTarget.OneEnemy,
        750,
        0,
        3,
        1,
        FireSequence,
        null,
        2
        );

    // =========================================================================
    // 003: Defend =============================================================
    // =========================================================================


    private static void DefendSequence(Actor target)
    {

    }

    public BattleSkill Defend = new BattleSkill(
        "Defend",
        "Reduce damage and negate all weaknesses.",
        BaseSkill.SkillType.Defend,
        0,
        0,
        0,
        null,
        BaseSkill.SkillTarget.Self,
        0,
        0,
        9,
        1,
        DefendSequence,
        null,
        1
        );
  

    void Awake()
    {
        SlashComp.Add(Comp.Slash);
        FireComp.Add(Comp.Fire);
        lib.Add(Slash);
        lib.Add(Fire);
        lib.Add(Defend);
    }
    */

}
