// =============================================================================
// FILE: Equipment.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the logic for equippable items in the game.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Equipment class
/// </summary>
public class Equipment : Item
{
    /// <summary>
    /// The type of equipment that the item is
    /// </summary>
    public EquipType equipType;
    /// <summary>
    /// Where the equipment can be equipped to
    /// </summary>
    public EquipRegion equipRegion;

    /// <summary>
    /// Virtual function handling armor effects when equipped
    /// </summary>
    /// <param name="targetAlly">The allies affected</param>
    public virtual void OnEquip(GameObject targetAlly) {}
    /// <summary>
    /// Virtual function handling armor effects when unequipped
    /// </summary>
    /// <param name="targetAlly">The allies affected</param>
    public virtual void OnUnequip(GameObject targetAlly) {}
}

