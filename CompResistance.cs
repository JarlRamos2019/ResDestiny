using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Jarl Ramos
// Resonant Destiny Computer Entertainment Laboratory
// CompResistance.cs
// 15 August 2022
//

public class CompResistance
{
    public Comp Comp;
    public int compTier;

    public CompResistance(Comp comp, int compTier)
    {
        this.Comp = comp;
        this.compTier = compTier;
    }
}
