using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Resonant Destiny
// FILE: BattleStateMaschine.cs
// ORGN: Unity - RD Prototype I
// DATE: 19 August 2022
//---------------------------------------------------
// Description:
// This script contains the state machines handling
// the different phases of a battle.
//---------------------------------------------------
// PROPERTY OF Mr. De Palme - DO NOT STEAL
//---------------------------------------------------

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: SCRIPT STILL UNDER CONSTRUCTION. DO NOT USE.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

public class BattleStateMaschine : MonoBehaviour
{
    // different phases of a round in battle
    public enum Act
    {
        Roll,
        Begin,
        EnemySelect,
        WaitForInput,
        TakeAction,
        PerformAction
    }

    // manages the user interface 
    public enum PlayerGUI
    {
        Activate,
        Waiting,
        End
    }

    private bool eQueueOk = true;
    private bool aQueueOk = true;
    private bool aInitVerified = true;
    private bool eInitVerified = true;
    private BattleSkill CurrentSkill;
    private SetAction CurrentAction;
    public Act bState;
    public PlayerGUI actorInput;
    public TurnHandler AllysChoice;

    private GameObject CurrentActor;
    public GameObject Selector;
    public GameObject EnemyButton;
    public GameObject AttackPanel;
    public GameObject SelectEnemyPanel;

    public Transform Spacer;

    public List<GameObject> RoundQueue = new List<GameObject>();
    public List<GameObject> AlliesInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();
    public List<GameObject> AlliesToManage = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        bState = Act.Roll;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        AlliesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        actorInput = PlayerGUI.Activate;
        Selector.SetActive(false);
        AttackPanel.SetActive(false);
        SelectEnemyPanel.SetActive(false);
        EnemyButtons();
    }

    // Update is called once per frame
    void Update()
    {
        switch (bState)
        {
            case (Act.Roll):
                // roll for initiative (calculate initiative value to be used for
                // determining turn order)
                foreach (GameObject i in EnemiesInBattle)
                {
                    EnemyStateMaschine eMaschine = i.GetComponent<EnemyStateMaschine>();
                    if (!eMaschine.initFinished)
                    {
                        eInitVerified = false;
                    }
                    else
                    {
                        eInitVerified = true;
                    }
                }
                foreach (GameObject j in AlliesInBattle)
                {
                    AllyStateMaschine aMaschine = j.GetComponent<AllyStateMaschine>();
                    if (!aMaschine.initFinished)
                    {
                        aInitVerified = false;
                    }
                    else
                    {
                        aInitVerified = true;
                    }
                }
                if (eInitVerified && aInitVerified)
                {
                    bState = Act.Begin;
                }
                break;
            case (Act.Begin):
                // determine turn order
                TurnOrderDeterminator();
                bState = Act.EnemySelect;
                break;
            case (Act.EnemySelect):
                // enemies will select their actions
                foreach (GameObject k in RoundQueue)
                {
                    if (k.CompareTag("Enemy"))
                    {
                        EnemyStateMaschine eMaschine = k.GetComponent<EnemyStateMaschine>();
                        eMaschine.eState = EnemyStateMaschine.EnemyState.SelectAction;
                    }
                }
                bState = Act.WaitForInput;
                break;
            case (Act.WaitForInput):
                // will let player input actions for their party
                foreach (GameObject l in RoundQueue)
                {
                    if (l.CompareTag("Enemy"))
                    {
                        EnemyStateMaschine eMaschine = l.GetComponent<EnemyStateMaschine>();
                        if (!eMaschine.EAction.validated)
                        {
                            eQueueOk = false;
                        }
                        else
                        {
                            eQueueOk = true;
                        }
                    }
                    if (l.CompareTag("Ally"))
                    {
                        AllyStateMaschine aMaschine = l.GetComponent<AllyStateMaschine>();
                        if (!aMaschine.AAction.validated)
                        {
                            aQueueOk = false;
                        }
                        else
                        {
                            aQueueOk = true;
                        }
                    }
                }

                // once actions of all combatants are verified
                if (eQueueOk && aQueueOk)
                {
                    bState = Act.TakeAction;
                }
                break;
            case (Act.TakeAction):
                // combatants will now prepare their actions
                //
                // if there is no more in the queue, the turn ends and is reset
                if (RoundQueue.Count == 0)
                {
                    bState = Act.Roll;
                }
                GameObject Actor = RoundQueue[0];
                if (Actor.CompareTag("Enemy"))
                {
                    EnemyStateMaschine eMaschine = Actor.GetComponent<EnemyStateMaschine>();
                    // eMaschine.EnemysTarget = ...
                    eMaschine.eState = EnemyStateMaschine.EnemyState.PerformAction;
                }
                if (Actor.CompareTag("Ally"))
                {
                    AllyStateMaschine aMaschine = Actor.GetComponent<AllyStateMaschine>();
                    aMaschine.AAction = AllysChoice;
                    // aMaschine.allysTarget = ...
                    aMaschine.aState = AllyStateMaschine.AllyState.PerformAction;
                }
                bState = Act.PerformAction;
                break;
            case (Act.PerformAction):
                break;
        }

        // meant for player input
        switch (actorInput)
        {
            case (PlayerGUI.Activate):
                break;
            case (PlayerGUI.Waiting):
                break;
            case (PlayerGUI.End):
                break;
        }
    }

    // these buttons will correspond to enemies and the player can choose
    // who to attack by pressing their respective button
    public void EnemyButtons()
    {
        ;
    }

    // input functions let player choose actions for their characters
    public void Input1()
    {
        ;
    }

    public void Input2()
    {
        ;
    }

    // ends the process of inputting actions
    public void AllyInputEnd()
    {
        ;
    }

    // uses initiative rolls to determine turn order
    public void TurnOrderDeterminator()
    {
        foreach (GameObject m in AlliesInBattle)
        {
            RoundQueue.Add(m);
        }

        foreach (GameObject n in EnemiesInBattle)
        {
            RoundQueue.Add(n);
        }

        // TODO: Find a better way to sort these
        RoundQueue.Sort((rq1, rq2) =>
        {
            int ini1 = 0;
            int ini2 = 0;
            
            if (rq1.CompareTag("Ally"))
            {
                AllyStateMaschine act1 = rq1.GetComponent<AllyStateMaschine>();
                ini1 = act1.initRoll;
            }
            if (rq1.CompareTag("Enemy"))
            {
                EnemyStateMaschine act1 = rq1.GetComponent<EnemyStateMaschine>();
                ini1 = act1.initRoll;
            }
            if (rq2.CompareTag("Ally"))
            {
                AllyStateMaschine act2 = rq2.GetComponent<AllyStateMaschine>();
                ini2 = act2.initRoll;
            }
            if (rq2.CompareTag("Enemy"))
            {
                EnemyStateMaschine act2 = rq2.GetComponent<EnemyStateMaschine>();
                ini2 = act2.initRoll;
            }
            return ini2.CompareTo(ini1);
        });
    }
}
