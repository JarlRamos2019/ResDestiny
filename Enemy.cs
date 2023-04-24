using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// FILE: Enemy.cs
// ORGN: Unity - RD Prototype I
// DATE: 15 August 2022
//---------------------------------------------------
// Description:
// This script contains all the statistics pertaining
// to an enemy in the game.
// --------------------------------------------------

public class Enemy : Actor
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        SuperRare,
        UltraRare
    }

    public Rarity EnemyRarity;
    public Statistic MoneyDrop;
}
