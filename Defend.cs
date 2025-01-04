using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : BattleSkill
{
    public Defend()
    {
        skillName = "Defend";
        skillDescription = "Basic defense.";
        Type = SkillType.Martial;
        heal = 0;
        mpCost = 0;
        hpCost = 0;
        Target = SkillTarget.Self;

        damage = 0;
        reCost = 0;
        skillSpeed = 99;

    }

    public override void Effects()
    {
        base.Effects();
    }
    public override void OnEffectEnd()
    {
        base.OnEffectEnd();
    }
}
