// =============================================================================
// FILE: Item.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the logic for items in the game.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The item class
/// </summary>
[SerializeField]
public class Item : MonoBehaviour
{
    /// <summary>
    /// Provided target information for an item
    /// </summary>
    public enum ItemTargets
    {
        Self,
        One,
        All
    }

    /// <summary>
    /// The name of the item
    /// </summary>
    public string itemName;
    /// <summary>
    /// The descriptio of the item
    /// </summary>
    public string itemDescription;
    /// <summary>
    /// Additional notes describing the item
    /// </summary>
    public string itemNotes;
    /// <summary>
    /// The value of the item in gold pieces
    /// </summary>
    public Statistic ItemValue;
    /// <summary>
    /// The weight of the item
    /// </summary>
    public Statistic ItemWeight;
    /// <summary>
    /// The item's icon
    /// </summary>
    public Image itemIcon;
    /// <summary>
    /// The item's component (if it has any)
    /// </summary>
    public Comp itemComp;
    /// <summary>
    /// The item's type
    /// </summary>
    public ItemType type;
    /// <summary>
    /// The item's targets
    /// </summary>
    public ItemTargets itemTargets;

    /// <summary>
    /// Virtual function handling when an actor uses an item
    /// </summary>
    /// <param name="targets">The affected targets</param>
    public virtual void OnUse(List<GameObject> targets) {}
    /// <summary>
    /// Function handling the end of timed effects of the item (if any)
    /// </summary>
    public virtual void OnEffectEnd() {}
}