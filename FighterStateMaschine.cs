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
    private readonly float rotSpeed = 1.0f;
    public bool initFinished = false;
    public bool actionsOK = false;
    public int initRoll;
    public string nameOfActor;
    private BattleStateMaschine bMaschine;
    private Vector3 startPosition;
    private Quaternion startQuat;
    public Ally BaseAlly;
    public Enemy BaseEnemy;
    public FighterState fState;
    public SkillLibrary sLib;
    public TurnHandler Actions = new TurnHandler();
    public List<GameObject> enemyTargets = new List<GameObject>();
    public GameObject selectedEnemyCommand;

    // note: Most of this class' methods will function differently depending
    // on whether the combatant is an ally or enemy
    // it will read the tag of the GameObject that this script is attached to
    // to determine this

    // IMPORTANT: All coroutines must be encapsulated in one state case with
    // no other instructions or functions contained inside

    // Start is called before the first frame update
    void Start()
    {
        //Attack = gameObject.AddComponent<StdAttack>();
        //Defend = gameObject.AddComponent<Defend>();
        nameOfActor = this.gameObject.GetComponent<Actor>().GetName();
        sLib = GameObject.Find("SkillManager").GetComponent<SkillLibrary>();
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
        // initFinished = false;
        startPosition = transform.position;
        startQuat = transform.rotation;
        // SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        switch (fState)
        {
            case (FighterState.Processing):
                initFinished = false;
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
                // if (this.gameObject.CompareTag("Enemy")) Debug.Log("AddToList");
                // adds the ally to the list of allies to manage
                if (this.gameObject.CompareTag("Ally"))
                {
                    bMaschine.AlliesToManage.Add(this.gameObject);
                }
                fState = FighterState.SelectAction;
                break;
            case (FighterState.SelectAction):
                // if (this.gameObject.CompareTag("Enemy")) Debug.Log("SelectAction");
                // the state where the combatant's actions for the round are
                // chosen
                if (this.gameObject.CompareTag("Enemy")) EnemyChooseAction();
                break;
            case (FighterState.Waiting):
                // default state when combatant isn't doing anything
                break;
            case (FighterState.PerformAction):
                // ReleasePosition();
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
                initFinished = true;
                // when the combatant is dead
                break;
        }

        if (this.gameObject.CompareTag("Ally"))
        {
            if (BaseAlly.CurHP.GetVal() < 0)
            {
                BaseAlly.CurHP.SetVal(0);
                Die();
            }
        }
        else if (this.gameObject.CompareTag("Enemy"))
        {
            if (BaseEnemy.CurHP.GetVal() < 0)
            {
                BaseEnemy.CurHP.SetVal(0);
                Die();
            }
        }
       
    }

    public void SetPosition()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void ReleasePosition()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.None;
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
        List<GameObject> skillList = new List<GameObject>();
        skillList = gameObject.GetComponent<Actor>().ActorsPreparedSkills;
        int enemyAP = gameObject.GetComponent<Actor>().AP.GetVal();

        if (skillList.Count == 0)
        {
            return;
        }

        while (enemyAP > 0)
        {
            selectedEnemyCommand = Instantiate(skillList[Random.Range(0, skillList.Count)]);

            if (selectedEnemyCommand.GetComponent<BattleSkill>().Target == BaseSkill.SkillTarget.OneEnemy)
            {
                List<GameObject> targets = new List<GameObject>();
                targets.Add(bMaschine.AlliesInBattle[Random.Range(0, bMaschine.AlliesInBattle.Count)]);
                enemyTargets = targets;
            }
            else if (selectedEnemyCommand.GetComponent<BattleSkill>().Target == BaseSkill.SkillTarget.AllEnemies)
            {
                List<GameObject> targets = new List<GameObject>();
                foreach (GameObject i in bMaschine.AlliesInBattle)
                {
                    targets.Add(i);
                }
                enemyTargets = targets;
            }
            else if (selectedEnemyCommand.GetComponent<BattleSkill>().Target == BaseSkill.SkillTarget.OneAlly)
            {
                List<GameObject> targets = new List<GameObject>();
                targets.Add(bMaschine.EnemiesInBattle[Random.Range(0, bMaschine.AlliesInBattle.Count)]);
                enemyTargets = targets;
            }
            else if (selectedEnemyCommand.GetComponent<BattleSkill>().Target == BaseSkill.SkillTarget.AllAllies)
            {
                List<GameObject> targets = new List<GameObject>();
                foreach (GameObject i in bMaschine.EnemiesInBattle)
                {
                    targets.Add(i);
                }
                enemyTargets = targets;
            }
            else
            {
                List<GameObject> targets = new List<GameObject>();
                foreach (GameObject i in bMaschine.AlliesInBattle)
                {
                    targets.Add(i);
                }
                foreach (GameObject i in bMaschine.EnemiesInBattle)
                {
                    targets.Add(i);
                }
                enemyTargets = targets;
            }
            SetAction setActionBuf = EnemyAssembleSetAction();
            Actions.ActorsActions.Add(setActionBuf);
            enemyAP -= selectedEnemyCommand.GetComponent<BattleSkill>().apCost;
        }
       
        Actions.validated = true;
        fState = FighterState.Waiting;
    }

    // when the ally combatant will automatically attack
    public void AutoAllyChooseAction()
    {
        Actions.whoseTurn = BaseAlly.GetName();
        Actions.ActorGameObject = this.gameObject;
        List<GameObject> targets = new List<GameObject>();
        targets.Add(bMaschine.EnemiesInBattle[Random.Range(0, bMaschine.EnemiesInBattle.Count)]);
        while (Actions.actorsAP > 0)
        {
            SetAction ActorsSetAction = new SetAction
            {
                CurrentActor = this.gameObject,
                ActorsTarget = targets,
                //ActorsSkill = sLib.Find("Slash")
            };
            Actions.ActorsActions.Add(ActorsSetAction);
            --Actions.actorsAP;
        }
        Actions.validated = true;
        fState = FighterState.Waiting;
    }

    public SetAction EnemyAssembleSetAction()
    {
        SetAction setAction = new SetAction()
        {
            CurrentActor = this.gameObject,
            ActorsTarget = enemyTargets,
            ActorsSkill = selectedEnemyCommand.GetComponent<BattleSkill>()
        };

        return setAction;
    }

    public void ReceiveAllyActions(List<SetAction> setActions)
    {
        Actions.whoseTurn = BaseAlly.GetName();
        Actions.ActorGameObject = this.gameObject;
        foreach (SetAction i in setActions)
        {
            Actions.ActorsActions.Add(i);
        }
        Actions.validated = true;
        fState = FighterState.Waiting;
    }

    // when the ally combatant will automatically defend
    public void AutoAllyChooseDefend()
    {
        Actions.whoseTurn = BaseAlly.GetName();
        List<GameObject> targets = new List<GameObject>();
        targets.Add(this.gameObject);
        Actions.ActorGameObject = this.gameObject;
        while (Actions.actorsAP > 0)
        {
            SetAction ActorsSetAction = new SetAction
            {
                CurrentActor = this.gameObject,
                ActorsTarget = targets
            };
            Actions.ActorsActions.Add(ActorsSetAction);
            --Actions.actorsAP;
        }
        Actions.validated = true;
        fState = FighterState.Waiting;
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

    public int DealHealing()
    {
        int healOut = 20;
        if (this.gameObject.CompareTag("Enemy"))
        {
            healOut += 5 * BaseEnemy.Spr.GetVal();
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            healOut += 5 * BaseAlly.Spr.GetVal();
        }
        return healOut;

    }

    public void TakeHealing(int healSrc)
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            int finalHeal = healSrc;
            BaseEnemy.CurHP.Modify(finalHeal);
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            int finalHeal = healSrc;
            BaseAlly.CurHP.Modify(-1 * finalHeal);
        }

    }

    public int RaiseStats(int src)
    {
        return 0;
    }

    public int LowerStats(int src)
    {
        return 0;
    }

    // does the roll for accuracy
    public int ApplyAccuracy()
    {
        int outAcc = 0;
  
        if (this.gameObject.CompareTag("Enemy"))
        {
            outAcc = BaseEnemy.Acc.GetVal() + Random.Range(0, 30);
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            outAcc = BaseAlly.Acc.GetVal() + Random.Range(0, 30);
        }
        return outAcc;
    }

    // determines if the fighter has evaded
    public bool EvadeOrNot(int acc)
    {
        bool evaded = false;

        if (this.gameObject.CompareTag("Enemy"))
        {
            if (acc < BaseEnemy.Eva.GetVal()) evaded = true;
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            if (acc < BaseAlly.Eva.GetVal()) evaded = true;
        }
        return evaded;
    }

    // when the combatant dies
    public void Die()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(nameOfActor + " dies!");
            for (int i = 0; i < bMaschine.EnemiesInBattle.Count; ++i)
            {
                if (bMaschine.EnemiesInBattle[i].GetComponent<FighterStateMaschine>().nameOfActor == this.nameOfActor)
                {
                    bMaschine.EnemiesInBattle.RemoveAt(i);
                    break;

                }
            }
            bMaschine.lootedGold += this.gameObject.GetComponent<Enemy>().MoneyDrop.GetVal();
            bMaschine.xpGained += this.gameObject.GetComponent<Enemy>().enemyXP.GetVal();
            int rng = Random.Range(0, 100);
            if (rng >= 50)
            {
                bMaschine.loot.AddRange(this.gameObject.GetComponent<Enemy>().enemyLoot);
            }
            fState = FighterState.Dead;
            Destroy(this.gameObject);
        }
        else if (this.gameObject.CompareTag("Ally"))
        {
            Debug.Log(nameOfActor + " dies!");
            for (int i = 0; i < bMaschine.AlliesInBattle.Count; ++i)
            {
                if (bMaschine.AlliesInBattle[i].GetComponent<FighterStateMaschine>().nameOfActor == this.nameOfActor)
                {
                    bMaschine.AlliesInBattle.RemoveAt(i);
                    break;

                }
            }
            fState = FighterState.Dead; 
        }
    }

    // moves the GameObject towards the desired location
    public bool MoveToLocation(Vector3 tar)
    {
        return tar != (transform.position = Vector3.MoveTowards(transform.position, tar,
                       animSpeed * Time.deltaTime));
    }

    // reset the combatant's queue of actions
    public void ResetActions()
    {
        Actions.ActorsActions.Clear();
        Actions.validated = false;
    }

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

        foreach (SetAction i in Actions.ActorsActions)
        {
            yield return i.ActorsSkill.Sequence(i.CurrentActor, i.ActorsTarget.ToArray());    
        }

        // return to original position
        Debug.Log("Moving to original position: " + nameOfActor);
        Vector3 originalPosition = startPosition;
        StartCoroutine(RotateTowardsLocation(originalPosition));
        while (MoveToLocation(originalPosition)) { yield return null; }
        StartCoroutine(RotateBack(startQuat));

        actionStarted = false;
        
        fState = FighterState.Finished;
    }

    public IEnumerator RotateTowardsLocation(Vector3 tar)
    {
        Quaternion lookRotate = Quaternion.LookRotation(tar - transform.position);
        float rotTime = 0.0f;
        while (rotTime < 1.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotate, rotTime);
            rotTime += Time.deltaTime * rotSpeed;
            yield return null;
        }
    }

    public IEnumerator RotateBack(Quaternion qua)
    {
        float rotTime = 0.0f;
        while (rotTime < 1.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, qua, rotTime);
            rotTime += Time.deltaTime * rotSpeed;
            yield return null;
        }
    }
}
