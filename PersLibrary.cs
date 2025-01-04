using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos / Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// ORGN: Unity - RD Prototype I
// FILE: PersLibrary.cs
// DATE: 2 July 2023
// =============================================================================

public class PersLibrary : MonoBehaviour
{
    public static PersLibrary Instance;
    public GameObject[] personalities;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
}
