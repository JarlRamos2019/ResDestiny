using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos
// GAME: Project R.D./Resonant Destiny
// FILE: Equipment.cs
// ORGN: Unity - RD Prototype I
// DATE: 17 August 2022
// =============================================================================

public class Equipment : Item
{
    public EquipType equipType;
    public EquipRegion equipRegion;
}

public enum EquipType
{
    Clothing,
    LightArmor,
    HeavyArmor,
    Robe,
    Sword,
    Axe,
    Spear,
    Dagger,
    Hammer,
    Greatsword,
    Staff,
    Bow,
    Crossbow,
    Shuriken,
    Whip,
    Katana,
    Club,
    Ball,
    Claw,
    Arrow,
    Bolt,
    Shield,
    Buckler,
    Horn,
    Lute,
    Harp,
    Trinket
}

public enum EquipRegion
{
    UpperArmor,
    LowerArmor,
    LeftHand,
    RightHand,
    Trinket
}