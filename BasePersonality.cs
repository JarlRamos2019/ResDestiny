using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos / Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// ORGN: Unity - RD Prototype I
// FILE: BasePersonality.cs
// DATE: 16 August 2022
// =============================================================================

[System.Serializable]
public class BasePersonality : MonoBehaviour
{

    /*
    public BasePersonality(float s, float a, float v, float e, float d, float c,
        float l, float i, float p, string name, string desc, List<CompResistance> res)
    {
        stAmp = s;
        agAmp = a;
        viAmp = v;
        enAmp = e;
        deAmp = d;
        chAmp = c;
        luAmp = l;
        inAmp = i;
        peAmp = p;
        PersResistances = res;
    }
    */

    public float stAmp;
    public float agAmp;
    public float viAmp;
    public float enAmp;
    public float deAmp;
    public float chAmp;
    public float luAmp;
    public float inAmp;
    public float peAmp;

    public string persName;
    public string persDesc;

    public string GetName() { return persName; }
    public string GetDesc() { return persDesc; }

    public List<CompResistance> PersResistances = new List<CompResistance>();

    public delegate void PersEffects();
    public PersEffects pEffectsOnChange;
    public PersEffects pEffectsOnRevert;
}
