using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// =============================================================================
// NAME: Jarl Ramos / Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// ORGN: Unity - RD Prototype I
// FILE: BaseSkill.cs
// DATE: 15 August 2022
// =============================================================================

public class BaseSkill : MonoBehaviour
{
    public enum SkillTarget
    {
        OneAlly,
        OneEnemy,
        AllAllies,
        AllEnemies,
        All,
        Self
    }

    public enum SkillType
    {
        Martial,
        Sniping,
        Chivalry,
        Thievery,
        Asceticism,
        Glima,
        Hunting,
        Bardsong,
        Dancing,
        Bushido,
        Ninjutsu,
        MoonMagic,
        SunMagic,
        GeoMagic,
        ShadowMagic,
        PsychicMagic,
        Alchemy,
        Necromancy,
        Ritualism,
        Scholarship,
        EnemySkill,
        Shamancy,
        Plasmancy,
        Fanaticism,
        Sorcery,
        Theology,
        FaeMagic,
        Enchantment,
        Transactions,
        Mechanics,
        Taming,
        Gambling,
        Defend
    }

    protected bool isPrepared = false;
    public string skillName;
    public string skillDescription;
    public SkillType Type;
    public int heal;
    public int mpCost;
    public int hpCost;
    public List<Comp> SkillComp = new List<Comp>();
    public SkillTarget Target;
    public Image skillIcon;
    public Image[] componentIcons;

    public virtual void Effects()
    {
       
    }

    public virtual void OnEffectEnd()
    {
        
    }

    public virtual IEnumerator Sequence(GameObject src, GameObject[] targets)
    {
        yield return null;

    }

    public bool IsItPrepared()
    {
        return isPrepared;
    }
 
    public void SetPreparation(bool input)
    {
        isPrepared = input;
    }

    public string GetSkillName()
    {
        return skillName;
    }
}
