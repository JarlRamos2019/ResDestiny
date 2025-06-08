// =============================================================================
// FILE: Exemplar.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Defines the Exemplar personality.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The examplar personality class
/// </summary>
public class Exemplar : BasePersonality
{

    /// <summary>
    /// Constructor
    /// </summary>
    public Exemplar()
    {
        personalityName = Constants.EXEMPLAR;
        personalityDesc = "description goes here";
        stModifier = 1.8f;
        agModifier = 1.8f;
        viModifier = 1.4f;
        enModifier = 1.1f;
        deModifier = 1.6f;
        chModifier = 1.8f;
        luModifier = 1.05f;
        inModifier = 1.8f;
        peModifier = 1.1f;
    }
}
