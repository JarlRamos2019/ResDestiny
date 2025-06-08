// =============================================================================
// FILE: Proficiency.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the code for proficiencies (i.e. armor/weapon types) in the game.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Proficiency class
/// Contains basic information about each consistency
/// </summary>
public class Proficiency : MonoBehaviour
{
    /// <summary>
    /// The equip type of the proficiency
    /// </summary>
    public EquipType EquipType;
    /// <summary>
    /// The image associated with the proficiency
    /// </summary>
    public Image equipTypeImage;
}
