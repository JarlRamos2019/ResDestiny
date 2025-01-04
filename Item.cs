using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Jarl Ramos
// Resonant Destiny Computer Entertainment Laboratory
// Item.cs
// 15 August 2022
//

[System.Serializable]
public class Item : MonoBehaviour
{
    private string itemName;
    private string itemDescription;

    public Statistic ItemValue;
    public Statistic ItemWeight;
    // public Modifier ItemModifier;
    // public CompModifier ItemCompModifier;

    public virtual void Effects()
    {
        ;
    }
    public virtual void OnEffectEnd()
    {
        ;
    }
    public string GetItemName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return itemDescription;
    }
}
