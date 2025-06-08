// =============================================================================
// FILE: BasePersonality.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Defines the basic structure of a personality.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePersonality : MonoBehaviour
{
    /// <summary>
    /// The name of the personality
    /// </summary>
    protected string personalityName;
    /// <summary>
    /// The description of the personality
    /// </summary>
    protected string personalityDesc;
    /// <summary>
    /// The modifier to the Strength statistic upon leveling up
    /// </summary>
    protected float stModifier;
    /// <summary>
    /// The modifier to the Agility statistic upon leveling up
    /// </summary>
    protected float agModifier;
    /// <summary>
    /// The modifier to the Vitality statistic upon leveling up
    /// </summary>
    protected float viModifier;
    /// <summary>
    /// The modifier to the Endurance statistic upon leveling up
    /// </summary>
    protected float enModifier;
    /// <summary>
    /// The modifier to the Devotion statistic upon leveling up
    /// </summary>
    protected float deModifier;
    /// <summary>
    /// The modifier to the Charisma statistic upon leveling up
    /// </summary>
    protected float chModifier;
    /// <summary>
    /// The modifier to the Luck statistic upon leveling up
    /// </summary>
    protected float luModifier;
    /// <summary>
    /// The modifier to the Intelligence statistic upon leveling up
    /// </summary>
    protected float inModifier;
    /// <summary>
    /// The modifier to the Perception statistic upon leveling up
    /// </summary>
    protected float peModifier;
    /// <summary>
    /// The list of component resistances associated with the personality
    /// </summary>
    protected List<CompResistance> PersonalityResistances = new List<CompResistance>();

    /// <summary>
    /// Sets the main perk of the personality on the appropriate targets
    /// </summary>
    /// <param name="affectedAllies">The affected target allies</param>
    protected virtual void OnSetPerk(List<Ally> affectedAllies)
    {

    }

    /// <summary>
    /// Sets the main drawback of the personality on the appropriate targets
    /// </summary>
    /// <param name="affectedAllies">The affected target allies</param>
    protected virtual void OnSetDrawback(List<Ally> affectedAllies)
    {

    }

    /// <summary>
    /// Unsets the main perk of the personality on the appropriate targets
    /// </summary>
    /// <param name="affectedAllies">The affected target allies</param>
    protected virtual void OnUnsetPerk(List<Ally> affectedAllies)
    {

    }

    /// <summary>
    /// Unsets the main drawback of the personality on the appropriate targets
    /// </summary>
    /// <param name="affectedAllies">The affected target allies</param>
    protected virtual void OnUnsetDrawback(List<Ally> affectedAllies)
    {

    }
}
