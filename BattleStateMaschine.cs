using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// FILE: BattleStateMaschine.cs
// ORGN: Unity - RD Prototype I
// DATE: 19 August 2022 - Modified 23 April 2023
//---------------------------------------------------
// Description:
// This script contains the state machines handling
// the different phases of a battle.
// --------------------------------------------------

public class BattleStateMaschine : MonoBehaviour
{
    // different phases of a round in battle
    public enum Act
    {
        Roll,
        Begin,
        EnemySelect,
        WaitForInput,
        PerformAction,
        End
    }

    // manages the user interface 
    public enum PlayerGUI
    {
        Activate,
        Waiting,
        End
    }

    private bool queueOk = true;
    private bool InitVerified = true;
    public Act bState;
    public PlayerGUI actorInput;
    public TurnHandler AllysChoice;

    // list contains all the characters and enemies that will fight in the
    // battle
    public List<GameObject> Combatants = new List<GameObject>();
    public List<GameObject> AlliesInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();
    public List<GameObject> AlliesToManage = new List<GameObject>();

    // IMPORTANT: All coroutines must be encapsulated in one state case with
    // no other instructions or functions contained inside

    // Start is called before the first frame update
    void Start()
    {
        bState = Act.Roll;
        // RegisterCombantants();
        actorInput = PlayerGUI.Activate;
    }

    // Update is called once per frame
    void Update()
    {
        switch (bState)
        {
            case (Act.Roll):
                RegisterCombatants();
                // roll for initiative (calculate initiative value to be used for
                // determining turn order)
                foreach (GameObject i in Combatants)
                {
                    // "turns on" each combatant
                    FighterStateMaschine fMaschine = i.GetComponent<FighterStateMaschine>();
                    fMaschine.fState = FighterStateMaschine.FighterState.Processing;
                    if (!fMaschine.initFinished)
                    {
                        InitVerified = false;
                    }
                    else
                    {
                        InitVerified = true;
                    }
                }
                // if initiative was determined for all combatants, move to the
                // next state
                if (InitVerified) bState = Act.Begin;
                break;
            case (Act.Begin):
                // determine turn order
                TurnOrderDeterminator();
                bState = Act.EnemySelect;
                break;
            case (Act.EnemySelect):
                // enemies will select their actions
                foreach (GameObject k in Combatants)
                {
                    if (k.CompareTag("Enemy"))
                    {
                        FighterStateMaschine fMaschine = k.GetComponent<FighterStateMaschine>();
                        fMaschine.fState = FighterStateMaschine.FighterState.SelectAction;
                    }
                }
                bState = Act.WaitForInput;
                break;
            case (Act.WaitForInput):
                // waits for the player to input actions for their party
                foreach (GameObject l in Combatants)
                {
                    // scan combatants to check if they have selected all their
                    // actions for the round
                    FighterStateMaschine fMaschine = l.GetComponent<FighterStateMaschine>();
                    if (!fMaschine.Actions.validated) queueOk = false;
                    else queueOk = true;
                }
                // once actions of all combatants have been validated
                if (queueOk) bState = Act.PerformAction;
                break;
            case (Act.PerformAction):
                // this state is where the combatants will start fighting
                // after their actions have been selected
                ExecuteTurns();
                break;
            case (Act.End):
                // ends current round and begins the next round
                bState = Act.Roll;
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

    // identifies every entity that will participate in combat
    public void RegisterCombatants()
    {
        Combatants.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Combatants.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        AlliesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
    }

    // uses initiative rolls to determine turn order
    // standard bubble sort using the initiative roll of each combatant
    public void TurnOrderDeterminator()
    {
        bool isSwapped;
        do
        {
            isSwapped = false;
            for (int i = 0; i < Combatants.Count - 2; ++i)
            {
                int init1;
                int init2;

                FighterStateMaschine FSM1 = Combatants[i].GetComponent<FighterStateMaschine>();
                FighterStateMaschine FSM2 = Combatants[i + 1].GetComponent<FighterStateMaschine>();
                init1 = FSM1.initRoll;
                init2 = FSM2.initRoll;

                if (init1 < init2)
                {
                    _ = new GameObject();
                    GameObject temp = Combatants[i];
                    Combatants[i] = Combatants[i + 1];
                    Combatants[i + 1] = temp;
                    isSwapped = true;
                }

            }
        } while (isSwapped);
    }

    // begins the fight
    public void ExecuteTurns() { StartCoroutine(ActionSequence()); }

    // coroutine that will have each combatant execute their actions
    // it will wait until the combatant is finished fighting
    public IEnumerator ActionSequence()
    {
        foreach (GameObject i in Combatants.ToArray())
        {
            FighterStateMaschine FSM = i.GetComponent<FighterStateMaschine>();
            if (FSM.fState != FighterStateMaschine.FighterState.Finished)
            {
                FSM.fState = FighterStateMaschine.FighterState.PerformAction;
            }
            
            while (FSM.fState != FighterStateMaschine.FighterState.Finished)
            {
                yield return null;
            }
        }
        bState = Act.End;
    }
}
