using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Resonant Destiny
// FILE: Statistic.cs
// ORGN: Unity - RD Prototype I
// DATE: 15 August 2022
//---------------------------------------------------
// Description:
// This script handles the behaviour of Statistics
// that will be used in the game.
//---------------------------------------------------
// PROPERTY OF Mr. De Palme - DO NOT STEAL
//---------------------------------------------------

[System.Serializable]
public class Statistic
{
    [SerializeField] private int statValue;

    public Statistic(int value)
    {
        statValue = value;
    }

    // method modifies the statistic; the parameter can
    // also be negative
    public void Modify(int value)
    {
        statValue += value;
    }

    // method modifies the statistic by taking in either an
    // Operation.More or Operation.Less, then taking in a percentage; this will
    // either raise or lower the value by said
    // percentage
    public void AdvModify(Operation op, float value)
    {
        int rawValue = (int)(statValue * value);

        if (op == Operation.More)
        {
            statValue += rawValue;
        }
        else if (op == Operation.Less)
        {
            statValue -= rawValue;
        }

    }

    // method sets the statistic to the parameter
    public void SetVal(int value)
    {
        statValue = value;
    }

    // method allows access to the private statValue
    public int GetVal()
    {
        return statValue;
    }
}

// used for the AdvModify() method
public enum Operation
{
    More,
    Less
}
