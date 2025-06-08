// =============================================================================
// FILE: Hero.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Defines the basic structure of the Hero.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Ally
{
    /// <summary>
    /// Enum representing your gender
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// Your gender
    /// </summary>
    public Gender herosGender;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="herosName">Your name that you will input at the beginning of game</param>
    /// <param name="isHeroLeftHanded">Your dexterity (true means left-handed)</param>
    /// <param name="selectedGender">Your selected gender you will input</param>
    public Hero(string herosName, bool isHeroLeftHanded, Gender selectedGender)
    {
        actorName = herosName;
        isLeftHanded = isHeroLeftHanded;
        herosGender = selectedGender;
    }
    /// <summary>
    /// The start method
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// The update method
    /// </summary>
    private void Update()
    {
        
    }

    /// <summary>
    /// Adjusts a personality trait based on your actions
    /// </summary>
    /// <param name="trait">The personality trait</param>
    /// <param name="op">The operation denoting addition ("More") or subtraction ("Less")</param>
    /// <param name="val">The integer value being added or subtracted</param>
    public void AdjustTrait(PersonalityTraits trait, Operation op, int val)
    {
        switch (trait)
        {
            case PersonalityTraits.Openness:
                if (op == Operation.More) Op.Modify(val);
                else Op.Modify(-val);
                break;
            case PersonalityTraits.Conscientiousness:
                if (op == Operation.More) Co.Modify(val);
                else Co.Modify(-val);
                break;
            case PersonalityTraits.Extraversion:
                if (op == Operation.More) Ex.Modify(val);
                else Ex.Modify(-val);
                break;
            case PersonalityTraits.Agreeableness:
                if (op == Operation.More) An.Modify(val);
                else An.Modify(-val);
                break;
            case PersonalityTraits.Neuroticism:
                if (op == Operation.More) Ne.Modify(val);
                else Ne.Modify(-val);
                break;
            default:
                Debug.LogError("AdjustTraits: Invalid personality trait value");
                break;
        }
    }
}
