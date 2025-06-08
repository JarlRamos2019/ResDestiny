// =============================================================================
// FILE: Actor.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the definition and implementation of the logic of an actor in the
// game.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The actor class.
/// Represents an actor in the game
/// </summary>
public class Actor : MonoBehaviour
{
    /// <summary>
    /// The specific instance of the actor
    /// </summary>
    public static Actor instance;
    /// <summary>
    /// The name of the actor
    /// </summary>
    protected string actorName;
    /// <summary>
    /// The Strength statistic
    /// </summary>
    public Statistic St;
    /// <summary>
    /// The Agility statistic
    /// </summary>
    public Statistic Ag;
    /// <summary>
    /// The Vitality statistic
    /// </summary>
    public Statistic Vi;
    /// <summary>
    /// The Endurance statistic
    /// </summary>
    public Statistic En;
    /// <summary>
    /// The Devotion statistic
    /// </summary>
    public Statistic De;
    /// <summary>
    /// The Charisma statistic
    /// </summary>
    public Statistic Ch;
    /// <summary>
    /// The Luck statistic
    /// </summary>
    public Statistic Lu;
    /// <summary>
    /// The Intelligence statistic
    /// </summary>
    public Statistic In;
    /// <summary>
    /// The Perception statistic
    /// </summary>
    public Statistic Pe;
    /// <summary>
    /// Current hit points (HP)
    /// </summary>
    public Statistic CurHP;
    /// <summary>
    /// Current mind points (MP)
    /// </summary>
    public Statistic CurMP;
    /// <summary>
    /// Maximum hit points (HP)
    /// </summary>
    public Statistic MaxHP;
    /// <summary>
    /// Maximum mind points (MP)
    /// </summary>
    public Statistic MaxMP;
    /// <summary>
    /// Current armor condition (AC)
    /// </summary>
    public Statistic CurAC;
    /// <summary>
    /// Current action points (AP)
    /// </summary>
    public Statistic AP;
    /// <summary>
    /// The Physical Attack statistic
    /// </summary>
    public Statistic PAT;
    /// <summary>
    /// The Physical Defense statistic
    /// </summary>
    public Statistic PDE;
    /// <summary>
    /// The Armor Condition statistic
    /// </summary>
    public Statistic AC;
    /// <summary>
    /// The Elemental Attack statistic
    /// </summary>
    public Statistic EAT;
    /// <summary>
    /// The Elemental Defense statistic
    /// </summary>
    public Statistic EDE;
    /// <summary>
    /// The Bravery statistic
    /// </summary>
    public Statistic Bra;
    /// <summary>
    /// The Accuracy statistic
    /// </summary>
    public Statistic Acc;
    /// <summary>
    /// The Critical Chance statistic
    /// </summary>
    public Statistic CC;
    /// <summary>
    /// The Critical Bonus statistic
    /// </summary>
    public Statistic CB;
    /// <summary>
    /// The Initiative statistic
    /// </summary>
    public Statistic Ini;
    /// <summary>
    /// The Fortitude statistic
    /// </summary>
    public Statistic Frt;
    /// <summary>
    /// The Reflex statistic
    /// </summary>
    public Statistic Ref;
    /// <summary>
    /// The Subterfuge statistic
    /// </summary>
    public Statistic Sub;
    /// <summary>
    /// The Spirit statistic
    /// </summary>
    public Statistic Spr;
    /// <summary>
    /// The Persuasion statistic
    /// </summary>
    public Statistic Per;
    /// <summary>
    /// The Evasion statistic
    /// </summary>
    public Statistic Eva;
    /// <summary>
    /// The Parry statistic
    /// </summary>
    public Statistic Par;
    /// <summary>
    /// The Counter statistic
    /// </summary>
    public Statistic Cou;
    /// <summary>
    /// The Riposte statistic
    /// </summary>
    public Statistic Rip;
    /// <summary>
    /// The Interrupt statistic
    /// </summary>
    public Statistic Itr;
    /// <summary>
    /// The Stun statistic
    /// </summary>
    public Statistic Stu;
    /// <summary>
    /// The Incapacitate statistic
    /// </summary>
    public Statistic Ica;
    /// <summary>
    /// The Stagger Rate statistic
    /// </summary>
    public Statistic Sta;
    /// <summary>
    /// How much an actor weighs
    /// </summary>
    public Statistic ActorWeight;
    /// <summary>
    /// The actor's resistances
    /// </summary>
    public List<CompResistance> Resistances;
    /// <summary>
    /// The actor's prepared skills
    /// </summary>
    public List<GameObject> ActorsPreparedSkills;
    /// <summary>
    /// The actor's inventory
    /// </summary>
    public Inventory ActorInventory;
    /// <summary>
    /// The actor's personality
    /// </summary>
    public BasePersonality personality;
    /// <summary>
    /// The icon associated with the actor
    /// </summary>
    public Image actorIcon;
    /// <summary>
    /// The Openness statistic
    /// </summary>
    public Statistic Op;
    /// <summary>
    /// The Conscientiousness statistic
    /// </summary>
    public Statistic Co;
    /// <summary>
    /// The Extraversion statistic
    /// </summary>
    public Statistic Ex;
    /// <summary>
    /// The Agreeableness statistic
    /// </summary>
    public Statistic An;
    /// <summary>
    /// The Neuroticism statistic
    /// </summary>
    public Statistic Ne;
    /// <summary>
    /// The party that the actor is in (if any)
    /// </summary>
    public Party actorsParty;
    /// <summary>
    /// The trinket that is equipped to the actor
    /// </summary>
    public Equipment trinket;
    /// <summary>
    /// Boolean value indicating if actor is "open"
    /// </summary>
    protected bool _isOp;
    /// <summary>
    /// Boolean value indicating if actor is "conscious" of themselves
    /// </summary>
    protected bool _isCo;
    /// <summary>
    /// Boolean value indicating if actor is "extraverted"
    /// </summary>
    protected bool _isEx;
    /// <summary>
    /// Boolean value indicating if actor is "agreeable"
    /// </summary>
    protected bool _isAn;
    /// <summary>
    /// Boolean value indicating if actor is "neurotic"
    /// </summary>
    protected bool _isNe;

    /// <summary>
    /// Property governing Openness
    /// </summary>
    public bool IsOp
    {
        get => _isOp;
        set
        {
            if (_isOp != value)
            {
                _isOp = value;
                DeterminePersonality();
            }
        }
    }
    /// <summary>
    /// Property governing Conscientiousness
    /// </summary>
    public bool IsCo
    {
        get => _isCo;
        set
        {
            if (_isCo != value)
            {
                _isCo = value;
                DeterminePersonality();
            }
        }
    }
    /// <summary>
    /// Property governing Extraversion
    /// </summary>
    public bool IsEx
    {
        get => _isEx;
        set
        {
            if (_isEx != value)
            {
                _isEx = value;
                DeterminePersonality();
            }
        }
    }
    /// <summary>
    /// Property governing Agreeableness
    /// </summary>
    public bool IsAn
    {
        get => _isAn;
        set
        {
            if (_isAn != value)
            {
                _isAn = value;
                DeterminePersonality();
            }
        }
    }
    /// <summary>
    /// Property governing Neuroticism
    /// </summary>
    public bool IsNe
    {
        get => _isNe;
        set
        {
            if (_isNe != value)
            {
                _isNe = value;
                DeterminePersonality();
            }
        }
    }

    /// <summary>
    /// The Awake method
    /// </summary>
    private void Awake()
    {
        /*  
          if (instance != null && instance != this)
          {
              Destroy(gameObject);
              return;
          }
          instance = this;
          DontDestroyOnLoad(gameObject);
        */
    }

    /// <summary>
    /// Uses booleans to determine an actor's personality
    /// </summary>
    public void DeterminePersonality()
    {
        if (IsOp && IsCo && IsEx && IsAn && IsNe)
        {
            personality = gameObject.AddComponent<Exemplar>();
        }
        else if (IsOp && IsCo && IsEx && IsAn && !IsNe)
        {
            //TODO: Perfectionist
        }
        else if (IsOp && IsCo && IsEx && !IsAn && IsNe)
        {
            //TODO: Disciplinarian
        }
        else if (IsOp && IsCo && IsEx && !IsAn && !IsNe)
        {
            //TODO: Cutthroat
        }
        else if (IsOp && IsCo && !IsEx && IsAn && IsNe)
        {
            //TODO: Erudite
        }
        else if (IsOp && IsCo && !IsEx && IsAn && !IsNe)
        {
            //TODO: Eccentric
        }
        else if (IsOp && IsCo && !IsEx && !IsAn && IsNe)
        {
            //TODO: Hermit
        }
        else if (IsOp && IsCo && !IsEx && !IsAn && !IsNe)
        {
            //TODO: Savant
        }
        else if (IsOp && !IsCo && IsEx && IsAn && IsNe)
        {
            //TODO: Valiant
        }
        else if (IsOp && !IsCo && IsEx && IsAn && !IsNe)
        {
            //TODO: Hippie
        }
        else if (IsOp && !IsCo && IsEx && !IsAn && IsNe)
        {
            //TODO: Hustler
        }
        else if (IsOp && !IsCo && IsEx && !IsAn && !IsNe)
        {
            //TODO: Anarchist
        }
        else if (IsOp && !IsCo && !IsEx && IsAn && IsNe)
        {
            //TODO: Protégé
        }
        else if (IsOp && !IsCo && !IsEx && IsAn && !IsNe)
        {
            //TODO: Wallflower
        }
        else if (IsOp && !IsCo && !IsEx && !IsAn && IsNe)
        {
            //TODO: Schemer
        }
        else if (IsOp && !IsCo && !IsEx && !IsAn && !IsNe)
        {
            //TODO: Quixotic
        }
        else if (!IsOp && IsCo && IsEx && IsAn && IsNe)
        {
            //TODO: Steadfast
        }
        else if (!IsOp && IsCo && IsEx && IsAn && !IsNe)
        {
            //TODO: Entertainer
        }
        else if (!IsOp && IsCo && IsEx && !IsAn && IsNe)
        {
            //TODO: Muscle-minded
        }
        else if (!IsOp && IsCo && IsEx && !IsAn && !IsNe)
        {
            //TODO: Warhawk
        }
        else if (!IsOp && IsCo && !IsEx && IsAn && IsNe)
        {
            //TODO: Stoic
        }
        else if (!IsOp && IsCo && !IsEx && IsAn && !IsNe)
        {
            //TODO: Idealist
        }
        else if (!IsOp && IsCo && !IsEx && !IsAn && IsNe)
        {
            //TODO: Trooper
        }
        else if (!IsOp && IsCo && !IsEx && !IsAn && !IsNe)
        {
            //TODO: Uptight
        }
        else if (!IsOp && !IsCo && IsEx && IsAn && IsNe)
        {
            //TODO: Chivalric
        }
        else if (!IsOp && !IsCo && IsEx && IsAn && !IsNe)
        {
            //TODO: Joker
        }
        else if (!IsOp && !IsCo && IsEx && !IsAn && IsNe)
        {
            //TODO: Brute
        }
        else if (!IsOp && !IsCo && IsEx && !IsAn && !IsNe)
        {
            //TODO: Killjoy
        }
        else if (!IsOp && !IsCo && !IsEx && IsAn && IsNe)
        {
            //TODO: Darling
        }
        else if (!IsOp && !IsCo && !IsEx && IsAn && !IsNe)
        {
            //TODO: Lecherous
        }
        else if (!IsOp && !IsCo && !IsEx && !IsAn && IsNe)
        {
            //TODO: Slacker
        }
        else
        {
            //TODO: Loner
        }
    }

    /// <summary>
    /// Generates secondary statistics depending on the primary statistics
    /// </summary>
    public void GenerateSecondaryStatistics()
    {
        //TODO: GenerateSecondaryStatistics()
    }

    /// <summary>
    /// Gets the actor's name
    /// </summary>
    /// <returns>The actor's name</returns>
    public string GetName()
    {
        return actorName;
    }

    /// <summary>
    /// Sets the actor's name
    /// </summary>
    /// <param name="newName">The target name</param>
    public void SetName(string newName)
    {
        actorName = newName;
    }

    /// <summary>
    /// Allows the actor to use an item
    /// </summary>
    /// <param name="targetItem">The item being used</param>
    /// <param name="targets">The target for the item</param>
    public void UseItem(GameObject targetItem, List<GameObject> targets)
    {
        Item theItem = targetItem.GetComponent<Item>();
        theItem.OnUse(targets);

        if (theItem.type == ItemType.Consumable)
        {
            Destroy(theItem.gameObject);
        }
    }

    /// <summary>
    /// Handles case where actor gets an item
    /// </summary>
    /// <param name="targetItem">The item being received</param>
    public void ReceiveItem(GameObject targetItem)
    {
        Item theItem = targetItem.GetComponent<Item>();
        ActorWeight.Modify(theItem.ItemWeight.GetVal());
        ActorInventory.AddItem(targetItem);
    }

    /// <summary>
    /// Handles case where actor loses an item
    /// </summary>
    /// <param name="itemName">The item being lost</param>
    public void RemoveItem(string itemName)
    {
        GameObject itemObj = ActorInventory.GetItem(itemName);
        ActorInventory.SubtractItem(itemObj);
        ActorWeight.Modify(-itemObj.GetComponent<Item>().ItemWeight.GetVal());
    }
}


