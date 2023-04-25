using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================================
// NAME: Jarl Ramos / Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// ORGN: Unity - RD Prototype I
// FILE: FighterStateMaschine.cs
// DATE: 23 April 2023
// =============================================================================
// Description: Creates a state maschine for a combatant during a battle.
//
// Instructions: Attach this to a GameObject representing a combatant that has
// either the "Ally" or "Enemy" script attached and tag the GameObject as either
// an "Enemy" or an "Ally".
// =============================================================================

public class FighterStateMaschine : MonoBehaviour
{
    // all states the combatant can take on
    public enum FighterState
    {
        Processing,
        AddToList,
        SelectAction,
        Waiting,
        PerformAction,
        ReceiveAction,
        Finished,
        Dead
    }

    private bool actionStarted = false;
    private readonly float animSpeed = 5f;
    public bool initFinished = false;
    public bool actionsOK = false;
    public int initRoll;

    private BattleStateMaschine bMaschine;
    private Vector3 startPosition;
    public Ally BaseAlly;
    public Enemy BaseEnemy;
    public FighterState fState;
    public TurnHandler Actions = new TurnHandler();
    public StdAttack Attack;

    // note: Most of this class' methods will function differently depending
    // on whether the combatant is an ally or enemy
    // it will read the tag of the GameObject that this script is attached to
    // to determine this

    // IMPORTANT: All coroutines must be encapsulated in one state case with
    // no other instructions or functions contained inside

    // Start is called before the first frame update
    void Start()
    {
        BaseAlly = gameObject.GetComponent<Ally>();
        BaseEnemy = gameObject.gameObject.GetComponent<Enemy>();
        bMaschine = GameObject.Find("BattleManager").GetComponent<BattleStateMaschine>();
        if (this.gameObject.CompareTag("Ally"))
        {
            // connection to GameObject's Ally script
            BaseAlly = this.gameObject.GetComponent<Ally>();
            BaseEnemy = null;
        }
        else if (this.gameObject.CompareTag("Enemy"))
        {
            // connection to GameObject's Enemy script
            BaseEnemy = this.gameObject.GetComponent<Enemy>();
            BaseAlly = null;
        }
        fState = FighterState.Processing;
        initFinished = false;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (fState)
        {
            case (FighterState.Processing):
                // will determine the initiative roll as well as
                // initialize the combatant's Action Points (AP)
                DetermineInitiative();
                if (this.gameObject.CompareTag("Ally"))
                {
                    Actions.actorsAP = BaseAlly.AP.GetVal();
                }
                else if (this.gameObject.CompareTag("Enemy"))
                {
                    Actions.actorsAP = BaseEnemy.AP.GetVal();
                }
                fState = FighterState.AddToList;
                break;
            case (FighterState.AddToList):
                // adds the ally to the list of allies to manage
                if (this.gameObject.CompareTag("Ally"))
                {
                    bMaschine.AlliesToManage.Add(this.gameObject);
                }
                fState = FighterState.SelectAction;
                break;
            case (FighterState.SelectAction):
                // the state where the combatant's actions for the round are
                // chosen
                if (this.gameObject.CompareTag("Ally"))
                {
                    AutoAllyChooseAction();
                    fState = FighterState.Waiting;
                }
                else if (this.gameObject.CompareTag("Enemy"))
                {
                    EnemyChooseAction();
                    fState = FighterState.Waiting;
                }
                break;
            case (FighterState.Waiting):
                // default state when combatant isn't doing anything
                break;
            case (FighterState.PerformAction):
                // combatant will proceed with carrying out actions
                StartCoroutine(ExecuteActions());
                break;
            case (FighterState.ReceiveAction):
                // when the combatant might receive damage, healing, or other
                // external stimuli from other combatants
                Die();
                break;
            case (FighterState.Finished):
                // when the combatant is finished with their actions
                ResetActions();
                break;
            case (FighterState.Dead):
                // when the combatant is dead
                break;
        }
    }

    // die roll function where the combatant's initiative roll is determined
    // this will affect its place in the round order
    public void DetermineInitiative()
    {
        int rawMod = Random.Range(1, 21);
        float middleMod = rawMod * 0.01f;
        int plusMinus = Random.Range(0, 2);

        if (this.gameObject.CompareTag("Enemy"))
        {
            int finalMod = (int)(BaseEnemy.Ini.GetVal() * middleMod);
            if (plusMinus == 0) // if finalMod is to be subtracted
            {
                initRoll = BaseEnemy.Ini.GetVal() - finalMod;
            }
            else // if finalMod is to be added
            {
                initRoll = BaseEnemy.Ini.GetVal() + finalMod;
            }
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            int finalMod = (int)(BaseAlly.Ini.GetVal() * middleMod);
            if (plusMinus == 0) // if finalMod is to be subtracted
            {
                initRoll = BaseAlly.Ini.GetVal() - finalMod;
            }
            else // if finalMod is to be added
            {
                initRoll = BaseAlly.Ini.GetVal() + finalMod;
            }
        }
        initFinished = true;
    }

    // when the enemy combatant will select its actions
    public void EnemyChooseAction()
    {
        Actions.whoseTurn = BaseEnemy.GetName();
        Actions.ActorGameObject = this.gameObject;
        while (Actions.actorsAP > 0)
        {
            SetAction ActorsSetAction = new SetAction();
            ActorsSetAction.CurrentActor = this.gameObject;
            ActorsSetAction.ActorsTarget = bMaschine.AlliesInBattle[Random.Range(0, bMaschine.AlliesInBattle.Count)];
            ActorsSetAction.ActorsSkill = Attack;
            Actions.ActorsActions.Add(ActorsSetAction);
            --Actions.actorsAP;
        }
        Actions.validated = true;
    }

    // when the ally combatant will automatically select its actions
    public void AutoAllyChooseAction()
    {
        Actions.whoseTurn = BaseAlly.GetName();
        Actions.ActorGameObject = this.gameObject;
        while (Actions.actorsAP > 0)
        {
            SetAction ActorsSetAction = new SetAction();
            ActorsSetAction.CurrentActor = this.gameObject;
            ActorsSetAction.ActorsTarget = bMaschine.EnemiesInBattle[Random.Range(0, bMaschine.EnemiesInBattle.Count)];
            ActorsSetAction.ActorsSkill = Attack;
            Actions.ActorsActions.Add(ActorsSetAction);
            --Actions.actorsAP;
        }
        Actions.validated = true;
    }

    // example of a simple damage-dealing function
    public int DealDamage()
    {
        int dmgOut = 20;
        if (this.gameObject.CompareTag("Enemy"))
        {
            dmgOut += 5 * BaseEnemy.PAT.GetVal();
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            dmgOut += 5 * BaseAlly.PAT.GetVal();
        }
        return dmgOut;
    }

    // example of a simple damage-taking function
    public void TakeDamage(int dmgSrc)
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            int finalDmg = dmgSrc - BaseEnemy.PDE.GetVal();
            BaseEnemy.CurHP.Modify(-1 * finalDmg);
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            int finalDmg = dmgSrc - BaseAlly.PDE.GetVal();
            BaseAlly.CurHP.Modify(-1 * finalDmg);
        }
    }

    // when the combatant dies
    public void Die()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            if (BaseEnemy.CurHP.GetVal() == 0)
            {
                fState = FighterState.Dead;
            }
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            if (BaseAlly.CurHP.GetVal() == 0)
            {
                fState = FighterState.Dead;
            }
        }
    }

    // moves the GameObject towards the desired location
    public bool MoveToLocation(Vector3 tar)
    {
        return tar != (transform.position = Vector3.MoveTowards(transform.position, tar,
                       animSpeed * Time.deltaTime));
    }

    // reset the combatant's queue of actions
    public void ResetActions() { Actions.ActorsActions.Clear(); }

    // simple coroutine simulating what happens during the fight
    public IEnumerator ExecuteActions()
    {
        if (actionStarted)
        {
            yield break;
        }

        if (fState != FighterState.PerformAction)
        {
            yield break;
        }

        actionStarted = true;

        foreach (SetAction i in Actions.ActorsActions.ToArray())
        {
            // travel to enemy the combatant wants to attack
            Vector3 targetPosition = new Vector3(i.ActorsTarget.transform.position.x - 1.0f,
                                                 i.ActorsTarget.transform.position.y,
                                                 i.ActorsTarget.transform.position.z - 1.0f);
            while (MoveToLocation(targetPosition)) {yield return null;}
            yield return new WaitForSeconds(0.1f);

            // exchange hits and do damage
            string n = "";
            if (this.gameObject.CompareTag("Ally"))
            {
                n = BaseAlly.GetName();
            }
            else if (this.gameObject.CompareTag("Enemy"))
            {
                n = BaseEnemy.GetName();
            }
            Debug.Log(n + " attacks!");
            yield return new WaitForSeconds(0.05f);
        }
        // return to original position
        Vector3 originalPosition = startPosition;
        while (MoveToLocation(originalPosition)) { yield return null; }

        actionStarted = false;
        
        fState = FighterState.Finished;
    }
}
