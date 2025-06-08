// =============================================================================
// FILE: Companion.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Defines the basic structure of a companion of the Hero (i.e. all the Allies
// in the party that are not the Hero).
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Companion class.
/// Represents all the allies in the game that are not the Hero
/// </summary>
public class Companion : Ally
{
    /// <summary>
    /// List of the maximum number of points each intimacy level can have
    /// </summary>
    protected readonly List<int> INTIMACY_LV_POINTS = new List<int>()
    { 10, 10, 20, 30, 50, 80, 130, 210, 340, 550, 890, 1440, 2330, 3770, 6100 };
    /// <summary>
    /// The lowest intimacy level
    /// </summary>
    protected readonly int INTIMACY_LV_LOWERBOUND = -1;
    /// <summary>
    /// The highest intimacy level when not married
    /// </summary>
    protected readonly int INTIMACY_LV_UPPERBOUND_NORMAL = 10;
    /// <summary>
    /// The highest intimacy level when married
    /// </summary>
    protected readonly int INTIMACY_LV_UPPERBOUND_MARRIED = 15;

    /// <summary>
    /// The maximum number of intimacy points for the current intimacy level
    /// </summary>
    protected int highestIntimacyPoints;
    /// <summary>
    /// The current highest intimacy level
    /// </summary>
    protected int highestIntimacyLevel;
    /// <summary>
    /// Denotes if a companion can be married
    /// </summary>
    protected bool isBachelor;
    /// <summary>
    /// Denotes if the companion and the Hero are married
    /// </summary>
    public bool isMarried;
    /// <summary>
    /// The current amount of intimacy points between the companion and the Hero
    /// </summary>
    public Statistic intimacyPoints;
    /// <summary>
    /// The current intimacy level between the companion and the Hero
    /// </summary>
    public Statistic intimacyLevel;

    /// <summary>
    /// The start method
    /// </summary>
    void Start()
    {
     
    }

    /// <summary>
    /// The update method
    /// </summary>
    void Update()
    {
        // increase the intimacy level if the player has accumulated enough points
        if (intimacyPoints.GetVal() > highestIntimacyPoints && intimacyLevel.GetVal() < highestIntimacyLevel)
        {
            IntimacyLevelUp();
        }

        // decrease the intimacy level if the player has lost enough points
        if (intimacyPoints.GetVal() <= 0 && intimacyLevel.GetVal() > INTIMACY_LV_LOWERBOUND)
        {
            IntimacyLevelDown();
        }  
    }

    /// <summary>
    /// Increases the intimacy level when the maximum amount of intimacy points has been reached
    /// </summary>
    public void IntimacyLevelUp()
    {
        intimacyLevel.Modify(1);
        intimacyPoints.SetVal(0);
        highestIntimacyPoints = INTIMACY_LV_POINTS[intimacyLevel.GetVal() - 1];
    }

    /// <summary>
    /// Decreases the intimacy level when the amount of intimacy points drops below 0
    /// </summary>
    public void IntimacyLevelDown()
    {
        intimacyLevel.Modify(-1);
        intimacyPoints.SetVal(0);
        highestIntimacyPoints = INTIMACY_LV_POINTS[intimacyLevel.GetVal() - 1];
    }

    /// <summary>
    /// Marry the companion
    /// </summary>
    public void Marry()
    {
        isMarried = true;
        highestIntimacyLevel = INTIMACY_LV_UPPERBOUND_MARRIED;
    }

    /// <summary>
    /// Get it on with the companion
    /// </summary>
    public void GetItOn()
    {

    }
}
