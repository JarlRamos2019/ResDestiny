using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//==============================================================================
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// FILE: BattleStateMaschine.cs
// ORGN: Unity - RD Prototype I
// DATE: 19 August 2022 - Modified 23 April 2023
//==============================================================================
// Description:
// This script contains the state machines handling the different phases of
// a battle.
//==============================================================================

public class BattleStateMaschine : MonoBehaviour
{
    // different phases of a round in battle
    public enum Act
    {
        Roll,
        Begin,
        EnemySelect,
        InitialInput,
        WaitForInput,
        SwitchCharacter,
        PerformAction,
        End,
        Victory,
        Defeat
    }

    // manages the user interface 
    public enum PlayerGUI
    {
        Initial,
        Setup,
        Command,
        Target,
        Idle
    }

    private bool queueOk = true;
    private bool InitVerified = true;
    private bool isRolling;
    public bool initialActive;
    public bool mainActive;
    public bool targetActive;
    public bool registered;
    public Act bState;
    public PlayerGUI actorInput;
    public TurnHandler AllysChoice;
    public GameObject apBar;
    public GameObject canvas;
    public GameObject statBar;
    public GameObject initialCommand;
    public GameObject mainCommand;
    public GameObject targetCommand;
    public GameObject skillSelectPrefab;
    public GameObject targetSelectPrefab;
    public GameObject[] initialAllyPositions;
    public GameObject[] initialEnemyPositions;
    public BattleSkill theCommand;
    public Button Atk;
    public Button Def;
    public Transform initialContent;
    public Transform mainContent;
    public Transform targetContent;
   
    public int initialSelected;
    public int secondSelected;
    public int targetSelected;
    public int selectedAlly;
    public int currentAP;
    public int commandIndex;
    public int targetIndex;
    public int lootedGold;
    public int xpGained;
    public List<BaseSkill> listOfAvailableSkills = new List<BaseSkill>();
    public List<SetAction> currentSetActions = new List<SetAction>();
    public List<GameObject> loot = new List<GameObject>();
    public string theSelectedTarget;
    public GameStateMaschine gMaschine;

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

        for (int i = 0; i < 4; ++i)
        {
            statBar.transform.Find("StatData" + i).gameObject.SetActive(false);
        }
        canvas = GameObject.Find("Canvas");
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
        initialCommand.SetActive(false);
        mainCommand.SetActive(false);
        targetCommand.SetActive(false);
        isRolling = false;
        actorInput = PlayerGUI.Idle;
        bState = Act.Roll;
        initialActive = false;
        mainActive = false;
        targetActive = false;
        commandIndex = 0;
        registered = false;
        lootedGold = 0;
        xpGained = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bState);
        switch (bState)
        {
            case (Act.Roll):
                if (!isRolling)
                {
                    StartCoroutine(RollingSequence());
                }
                selectedAlly = 0;
                break;
            case (Act.Begin):
                // determine turn order
                commandIndex = 0;
                targetIndex = 0;
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
                bState = Act.InitialInput;
                break;
            case (Act.InitialInput):
                actorInput = PlayerGUI.Initial;
                currentAP = GetCharacterAP();
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
                if (queueOk)
                {
                    actorInput = PlayerGUI.Idle;
                    
                }
                //bState = Act.SwitchCharacter;
                break;
            case Act.SwitchCharacter:
                CleanUpAPBar();
                ++selectedAlly;
                while (selectedAlly < AlliesInBattle.Count &&
                       AlliesInBattle[selectedAlly].GetComponent<FighterStateMaschine>().fState == FighterStateMaschine.FighterState.Dead)
                {
                    Debug.Log("passing over dead ally");
                    ++selectedAlly;
                }

                if (selectedAlly >= AlliesInBattle.Count)
                {
                    bState = Act.PerformAction;
                    targetCommand.gameObject.SetActive(false);
                    targetActive = false;
                    actorInput = PlayerGUI.Idle;
                }
                else
                {
                    currentAP = GetCharacterAP();
                    bState = Act.WaitForInput;
                    actorInput = PlayerGUI.Setup;
                }
                break;
            case (Act.PerformAction):
                // this state is where the combatants will start fighting
                // after their actions have been selected
                ExecuteTurns();
                break;
            case (Act.End):
                // ends current round and begins the next round
                ReleaseCombatants();
                registered = false;
                bState = Act.Roll;
                break;
            case (Act.Victory):
                break;
            case (Act.Defeat):
                break;
        }

        // meant for player input
        switch (actorInput)
        {
            case (PlayerGUI.Idle):
                apBar.gameObject.SetActive(false);
                break;
            case (PlayerGUI.Initial):
                initialSelected = 0;
                secondSelected = 0;
                targetSelected = 0;
                initialCommand.SetActive(true);
                break;
            case (PlayerGUI.Setup):
                CleanUpAllMenus();
                apBar.gameObject.SetActive(true);
                if (!mainActive)
                {
                    mainActive = SetCharacterInterface();
                    actorInput = PlayerGUI.Command;
                }
                break;
            case (PlayerGUI.Command):
                DisableAllMainCommandSelectors();
                NavigateThroughMainCommand();
                SelectSkillFromMenu();
                break;
            case (PlayerGUI.Target):
                theSelectedTarget = targetContent.transform.GetChild(targetIndex).GetComponent<TargetSelect>().target.GetComponent<Actor>().GetName();
                DisableAllTargetCommandSelectors();
                NavigateThroughTargetCommand();
                SelectTargetFromMenu();
                break;
        }

        apBar.GetComponent<APBar>().apNum.text = currentAP.ToString();
    }

    public void InstantiateAllAllies(List<GameObject> alliesParty)
    {
        for (int i = 0; i < alliesParty.Count; ++i)
        {
            GameObject newActor = Instantiate(alliesParty[i], initialAllyPositions[i].transform);
            newActor.GetComponent<FighterStateMaschine>().enabled = true;
           
        }
    }
    // identifies every entity that will participate in combat
    public void RegisterCombatants()
    {
        Combatants.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Combatants.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        AlliesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        foreach (GameObject i in Combatants)
        {
            if (!i.GetComponent<FighterStateMaschine>().enabled)
            {
                i.GetComponent<FighterStateMaschine>().enabled = true;
            }
        }
    }

    public void TurnOnCombatants()
    {
        foreach (GameObject i in Combatants)
        {
            // "turns on" each combatant
            FighterStateMaschine fMaschine = i.GetComponent<FighterStateMaschine>();
            if (fMaschine.fState != FighterStateMaschine.FighterState.Dead)
            {
                fMaschine.fState = FighterStateMaschine.FighterState.Processing;
            }
            
            if (!fMaschine.initFinished) InitVerified = false;
            else InitVerified = true;
        }
    }

    public void PopulateStatBar()
    {
        int count = AlliesInBattle.Count;
        switch (count)
        {
            case 1:
                statBar.transform.Find("StatData3").gameObject.SetActive(true);
                break;
            case 2:
                for (int i = 2; i < 4; ++i)
                {
                    int allyIndex = i - 2;
                    statBar.transform.Find("StatData" + i).gameObject.SetActive(true);
                    statBar.transform.Find("StatData" + i).gameObject.GetComponent<StatNumbers>().ally = AlliesInBattle[allyIndex];

                }
                break;
            case 3:
                for (int i = 1; i < 4; ++i)
                {
                    int allyIndex = i - 1;
                    statBar.transform.Find("StatData" + i).gameObject.SetActive(true);
                    statBar.transform.Find("StatData" + i).gameObject.GetComponent<StatNumbers>().ally = AlliesInBattle[allyIndex];
                }
                break;
            case 4:
                for (int i = 0; i < 4; ++i)
                {
                    statBar.transform.Find("StatData" + i).gameObject.SetActive(true);
                    statBar.transform.Find("StatData" + i).gameObject.GetComponent<StatNumbers>().ally = AlliesInBattle[i];
                }
                break;
        }
    }

    // removes all combatants from the list
    public void ReleaseCombatants()
    {
        Combatants.Clear();
        EnemiesInBattle.Clear();
        AlliesInBattle.Clear();
        AlliesToManage.Clear();
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

    // used in conjunction with AttackButton; clicking on button will automatically
    // set all ally actions to "Attack"
    public void SelectAttackButton()
    {
        foreach (GameObject i in Combatants)
        {
            if (i.CompareTag("Ally"))
            {
                FighterStateMaschine FSM = i.GetComponent<FighterStateMaschine>();
                FSM.AutoAllyChooseAction();
            }
        }

    }

    public void ProcessSelectedSetActions()
    {
        foreach (SetAction i in currentSetActions)
        {
            Debug.Log("Number of targets: " + i.ActorsTarget.Count);
        }
        AlliesInBattle[selectedAlly].GetComponent<FighterStateMaschine>().ReceiveAllyActions(currentSetActions);
    }

    // used in conjunction with DefendButton; clicking on button will automatically
    // set all ally actions to "Defend"
    public void SelectDefendButton()
    {
        foreach (GameObject i in Combatants)
        {
            if (i.CompareTag("Ally"))
            {
                FighterStateMaschine FSM = i.GetComponent<FighterStateMaschine>();
                FSM.AutoAllyChooseDefend();
            }
        }
    }

    public void SetAllInterfacesToFalse()
    {
        initialActive = false;
        mainActive = false;
        targetActive = false;
    }

    public void SetInitialInterface()
    {

    }

    public bool SetCharacterInterface()
    {
        Debug.Log("It is " + AlliesInBattle[selectedAlly].GetComponent<Actor>().GetName() + "'s turn");
        Debug.Log("Current AP: " + currentAP);
        targetCommand.gameObject.SetActive(false);
        mainCommand.gameObject.SetActive(true);
        BringUpAllSkillsOfChosenCharacter();
        return true;
    }

    public int GetCharacterAP()
    {
        return AlliesInBattle[selectedAlly].GetComponent<Actor>().AP.GetVal();
    }
    public void SetTargetInterface()
    {
        BringUpAllAppropriateTargets(mainContent.transform.GetChild(commandIndex).GetComponent<SkillSelect>().skill.GetComponent<BaseSkill>());
        mainCommand.gameObject.SetActive(false);
        targetCommand.gameObject.SetActive(true);
    }

    public void SelectSkillFromMenu()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            theCommand = Instantiate(mainContent.transform.GetChild(commandIndex).GetComponent<SkillSelect>().skill).GetComponent<BattleSkill>();
            Debug.Log("Skill selected: " + theCommand.GetSkillName());
            actorInput = PlayerGUI.Target;
            mainActive = false;
            targetActive = true;
            SetTargetInterface();
        }
    }

    public void SelectTargetFromMenu()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            List<GameObject> theTargets = new List<GameObject>();
            theTargets.Add(targetContent.transform.GetChild(targetIndex).GetComponent<TargetSelect>().target); 
            currentSetActions.Add(AssembleSetAction(theTargets));
            APBar theAPBar = apBar.GetComponent<APBar>();
            GameObject iconOfSkill = Instantiate(theAPBar.apIconPrefab, theAPBar.SkillContent);
            iconOfSkill.GetComponent<APIconScript>().Initialize(theCommand.skillIcon);
            --currentAP;
           
            Debug.Log("Target count: " + currentSetActions[currentSetActions.Count - 1].ActorsTarget.Count);
            Debug.Log("Target name: " + theTargets[0]);
            Debug.Log("AP left: " + currentAP);
            if (currentAP <= 0)
            {
                targetActive = false;
                ProcessSelectedSetActions();
                currentSetActions.Clear();
                actorInput = PlayerGUI.Idle;
                bState = Act.SwitchCharacter;
            }
            
        }


    }

    public void NavigateThroughMainCommand()
    {
        if (mainActive)
        {
            if (Input.GetKeyDown(KeyCode.S) && commandIndex < mainContent.transform.childCount - 1)
            {
                ++commandIndex;
            }
            if (Input.GetKeyDown(KeyCode.W) && commandIndex > 0)
            {
                --commandIndex;
            }
            if (mainContent.transform.childCount > 0)
            {
                mainContent.transform.GetChild(commandIndex).Find("selector").gameObject.SetActive(true);
            }
    
        }

    }

    public void NavigateThroughTargetCommand()
    {
        if (targetActive)
        {
            if (Input.GetKeyDown(KeyCode.S) && targetIndex < targetContent.transform.childCount - 1)
            {
                Debug.Log("S");
                ++targetIndex;
            }
            if (Input.GetKeyDown(KeyCode.W) && targetIndex > 0)
            {
                Debug.Log("W");
                --targetIndex;
            }
            targetContent.transform.GetChild(targetIndex).Find("selector").gameObject.SetActive(true);
        }

    }

    public void DisableAllMainCommandSelectors()
    {
        for (int i = 0; i < mainContent.transform.childCount; ++i)
        {
            mainContent.transform.GetChild(i).Find("selector").gameObject.SetActive(false);
        }
    }

    public void DisableAllTargetCommandSelectors()
    {
        for (int i = 0; i < targetContent.transform.childCount; ++i)
        {
            targetContent.transform.GetChild(i).Find("selector").gameObject.SetActive(false);
        }
    }

    public void BringUpAllSkillsOfChosenCharacter()
    {
        Debug.Log("name is " + AlliesInBattle[selectedAlly].GetComponent<Ally>().GetName());
        List<GameObject> skills = AlliesInBattle[selectedAlly].GetComponent<Actor>().ActorsPreparedSkills;
        foreach (GameObject i in skills)
        {
            GameObject newSelect = Instantiate(skillSelectPrefab, mainContent);
            newSelect.GetComponent<SkillSelect>().Initialize(i);
        }
    }

    public void BringUpAllAppropriateTargets(BaseSkill skill)
    {
        if (skill.Target == BaseSkill.SkillTarget.OneEnemy)
        {
            List<GameObject> targets = EnemiesInBattle;
            foreach (GameObject i in targets)
            {
                GameObject newTargetSelect = Instantiate(targetSelectPrefab, targetContent);
                newTargetSelect.GetComponent<TargetSelect>().Initialize(i);
            }
        }
        else if (skill.Target == BaseSkill.SkillTarget.OneAlly)
        {
            List<GameObject> targets = AlliesInBattle;
            foreach (GameObject i in targets)
            {
                GameObject newTargetSelect = Instantiate(targetSelectPrefab, targetContent);
                newTargetSelect.GetComponent<TargetSelect>().Initialize(i);
            }
        }
        else if (skill.Target == BaseSkill.SkillTarget.Self)
        {
            List<GameObject> targets = new List<GameObject>();
            targets.Add(AlliesInBattle[selectedAlly]);
            GameObject newTargetSelect = Instantiate(targetSelectPrefab, targetContent);
            newTargetSelect.GetComponent<TargetSelect>().Initialize(targets[0]);
        }
        else if (skill.Target == BaseSkill.SkillTarget.AllEnemies)
        {
            
        }
        else if (skill.Target == BaseSkill.SkillTarget.AllAllies)
        {

        }
        else
        {

        }

    }

    /*
    public void SelectAllTargets(BaseSkill skill)
    {
        if (skill.Target == BaseSkill.SkillTarget.AllAllies)
        {
            foreach (GameObject i in AlliesInBattle)
            {
                theTargets.Add(i);
            }
        }
        else if (skill.Target == BaseSkill.SkillTarget.AllEnemies)
        {
            foreach (GameObject i in EnemiesInBattle)
            {
                theTargets.Add(i);
            }

        }
        else if (skill.Target == BaseSkill.SkillTarget.All)
        {
            foreach (GameObject i in EnemiesInBattle)
            {
                theTargets.Add(i);
            }
            foreach (GameObject i in AlliesInBattle)
            {
                theTargets.Add(i);
            }
        }
    }
    */

    public SetAction AssembleSetAction(List<GameObject> targets)
    {
        SetAction setAction = new SetAction()
        {
            CurrentActor = AlliesInBattle[selectedAlly],
            ActorsTarget = targets,
            ActorsSkill = theCommand
        };

        return setAction;

    }

    public void CleanUpAPBar()
    {
        foreach (Transform i in apBar.GetComponent<APBar>().SkillContent)
        {
            GameObject.Destroy(i.gameObject);
        }
    }

    public void CleanUpAllMenus()
    {
        foreach (Transform i in mainContent.transform)
        {
            GameObject.Destroy(i.gameObject);
        }
        foreach (Transform i in targetContent.transform)
        {
            GameObject.Destroy(i.gameObject);
        }
        actorInput = PlayerGUI.Command;
    }

    public bool isEveryoneDead()
    {
        foreach (GameObject i in AlliesInBattle)
        {
            if (i.GetComponent<Actor>().CurHP.GetVal() != 0)
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerator RollingSequence()
    {
        if (isRolling)
        {
            yield break;
        }
        else
        {
            isRolling = true;
        }
        Debug.Log(isRolling);
        yield return new WaitForEndOfFrame();

        if (bState != Act.Roll)
        {
            yield break;
        }

        if (!registered)
        {
            RegisterCombatants();
            registered = true;
        }
        
        if (EnemiesInBattle.Count == 0)
        {
            Victory();
            yield break;
        }
        if (isEveryoneDead())
        {
            Defeat();
            yield break;
        }
        PopulateStatBar();
        TurnOnCombatants();
        isRolling = false;
        if (InitVerified) bState = Act.Begin;
    }

    public void Victory()
    {
        Debug.Log("VICTORY!");
        Party party = gMaschine.PlayerParty.GetComponent<Party>();
        party.gold.Modify(lootedGold);
        party.PartyXP.Modify(xpGained);
        foreach (GameObject i in loot)
        {
            party.PartyInventory.AddItem(i);
        }
        gMaschine.gState = GameStateMaschine.GameState.Map;
        StartCoroutine(WaitForVictoryToEnd());
        ExitBattle();
    }

    public void Defeat()
    {
        Debug.Log("The party was vanquished.");
    }


    public void ExitBattle()
    {
        SceneManager.LoadScene("WorldMap", LoadSceneMode.Single);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "WorldMap")
        {
            GameObject manager = GameObject.Find("GameManager");
            if (manager)
            {
                Debug.Log("Game manager exists");
                manager.GetComponent<GameStateMaschine>().PlayerParty.transform.position = manager.GetComponent<GameStateMaschine>().positionOnWorldMap;
            }
        }

    }

    // coroutine that will have each combatant execute their actions
    // it will wait until the combatant is finished fighting
    public IEnumerator ActionSequence()
    {
        foreach (GameObject i in Combatants.ToArray())
        {
            if (i == null)
            {
                continue;
            }
            else
            {
                FighterStateMaschine FSM = i.GetComponent<FighterStateMaschine>();
                if (FSM.fState != FighterStateMaschine.FighterState.Finished &&
                    FSM.fState != FighterStateMaschine.FighterState.Dead)
                {
                    FSM.fState = FighterStateMaschine.FighterState.PerformAction;
                }

                while (FSM.fState != FighterStateMaschine.FighterState.Finished &&
                       FSM.fState != FighterStateMaschine.FighterState.Dead)
                {
                    yield return null;
                }
            }   
        }
        bState = Act.End;
    }

    public IEnumerator WaitForVictoryToEnd()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
