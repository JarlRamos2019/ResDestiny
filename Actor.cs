using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// FILE: Actor.cs
// ORGN: Unity - RD Prototype I
// DATE: 15 August 2022
//---------------------------------------------------
// Description:
// Defines a class for actors in the game that
// contains their statistics and qualities that will
// be used in the functions of the game such as the
// battle system.
//---------------------------------------------------

// defines all properties of a game actor
[System.Serializable]
public class Actor : MonoBehaviour
{

    public static Actor instance;

    void Awake()
    {
      /*  
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
      */
    }
    [SerializeField] protected string actorName;

    public Statistic ActorWeight;
    public Statistic ActorLevel;

    // primary statistics
    public Statistic St;  // Strength
    public Statistic Ag;  // Agility
    public Statistic Vi;  // Vitality
    public Statistic En;  // Endurance
    public Statistic De;  // Devotion
    public Statistic Ch;  // Charisma
    public Statistic Lu;  // Luck
    public Statistic In;  // Intelligence
    public Statistic Pe;  // Perception

    // secondary statistics
    public Statistic CurHP;  // Current HP
    public Statistic CurMP;  // Current MP
    public Statistic MaxHP;  // Max HP
    public Statistic MaxMP;  // Max MP
    public Statistic CurAC;
    public Statistic AP;     // Action Points
    public Statistic PAT;    // Physical Attack
    public Statistic PDE;    // Physical Defense
    public Statistic AC;     // Armor Condition
    public Statistic EAT;    // Elemental Attack
    public Statistic EDE;    // Elemental Defense
    public Statistic Bra;    // Bravery
    public Statistic Acc;    // Accuracy
    public Statistic CC;     // Critical Chance
    public Statistic CB;     // Critical Bonus
    public Statistic Ini;    // Initiative
    public Statistic Frt;    // Fortitude
    public Statistic Ref;    // Reflex
    public Statistic Sub;    // Subterfuge
    public Statistic Spr;    // Spirit
    public Statistic Per;    // Persuasion

    // battle feats
    public Statistic Eva;  // Evasion
    public Statistic Par;  // Parry
    public Statistic Cou;  // Counter
    public Statistic Rip;  // Riposte
    public Statistic Itr;  // Interrupt
    public Statistic Stu;  // Stun
    public Statistic Ica;  // Incapacitate
    public Statistic Sta;  // Stagger Rate

    public List<CompResistance> Resistances;
    public List<GameObject> ActorSkills;
    public Inventory ActorInventory;
    public Image actorIcon;

    public void GenerateSecondaryStatistics()
    {

    }

    // gets actor name
    public string GetName()
    {
        return actorName;
    }

    public void SetName(string newName)
    {
        actorName = newName;
    }
}

// list of all components in the game; represent
// resistances and weaknesses to elements and physical
// attacks
public enum Comp
{
    Slash,
    Bludgeon,
    Pierce,
    Sonic,
    Force,
    Fire,
    Ice,
    Lightning,
    Wind,
    Water,
    Earth,
    Acid,
    Dark,
    Light,
    Biologic,
    Necrotic,
    Psychic,
    None
}
