using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// FILE: Ally.cs
// ORGN: Unity - RD Prototype I
// DATE: 15 August 2022
//---------------------------------------------------
// Description:
// This script contains statistics and methods
// pertaining to player characters in the game.
// --------------------------------------------------

public class Ally : Actor
{
    public BaseRPGClass ActiveClass;
    public BaseRPGClass ActiveSubCl;
    public List<BaseRPGClass> AllysClasses = new List<BaseRPGClass>();

    public BasePersonality AllyPers;

    public Statistic XP;  // Experience points

    // personality traits
    public Statistic Op;  // Openness
    public Statistic Co;  // Conscientiousness
    public Statistic Ex;  // Extraversion
    public Statistic An;  // Agreeableness
    public Statistic Ne;  // Neuroticism

    public bool isOp;
    public bool isCo;
    public bool isEx;
    public bool isAn;
    public bool isNe;

    public void AdjustTraits()
    {
        // this will determine the bools for each trait
    }

    public BasePersonality DeterminePers()
    {
        // supposed to contain all 32 personalities

        if (isOp && isCo && isEx && isAn && isNe)
        {
            return gameObject.AddComponent<Exemplar>();
        }
        else
        {
            return null;
        } 
    }

    // allows the player to change a character's class
    public void ChangeClass(BaseRPGClass rpgClass)
    {
        bool isPresentInList = false;
        ActiveClass = rpgClass;
        ActiveClass.BaseAlly = this;
        foreach (BaseRPGClass c in AllysClasses)
        {
            string cName1 = c.GetRPGClassName();
            string cName2 = rpgClass.GetRPGClassName();
            if (cName1 == cName2)
            {
                isPresentInList = true;
            }
        }

        if (!isPresentInList)
        {
            AllysClasses.Add(rpgClass);
        } 
    }

}

