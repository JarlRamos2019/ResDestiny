using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Jarl Ramos
// Resonant Destiny Computer Entertainment Laboratory
// Consumable.cs
// 19 August 2022
//

public class Consumable : Item
{
    public enum ConsuType
    {
        Potion,
        Aether,
        Spirit,
        Dew,
        Mist,
        Ambrosia,
        Medicine,
        Alkahest,
        Lubricant,
        Elixir,
        Misc
    }

    public ConsuType Type;
    public Comp ConsuComp;
}
