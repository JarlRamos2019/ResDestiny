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

[System.Serializable]
public class Ally : Actor
{
    public GameObject ActiveClass;
    public GameObject ActiveSubCl;
    public List<GameObject> AllysClasses = new List<GameObject>();

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

    public void DeterminePers()
    {
        // supposed to contain all 32 personalities

        if (isOp && isCo && isEx && isAn && isNe)
        {
            /*
            PersLibrary persLibrary = gameObject.AddComponent<PersLibrary>();
            AllyPers = persLibrary.Exemplar;
            */
            
        }
        else
        {
  
        } 
    }

    // allows the player to change a character's class
    public void ChangeClass(GameObject rpgClass)
    {
        bool isPresentInList = false;
        ActiveClass = rpgClass;
        ActiveClass.GetComponent<BaseRPGClass>().BaseAlly = this;
        foreach (GameObject c in AllysClasses)
        {
            string cName1 = c.GetComponent<BaseRPGClass>().GetRPGClassName();
            string cName2 = rpgClass.GetComponent<BaseRPGClass>().GetRPGClassName();
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

    public void LevelUp()
    {

    }

}

