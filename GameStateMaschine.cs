using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//---------------------------------------------------
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Resonant Destiny
// FILE: GameStateMaschine.cs
// ORGN: Unity - RD Prototype I
// DATE: August - September 2022
//---------------------------------------------------
// Description:
// This script contains the state machines handling
// the different aspects of the game.
//---------------------------------------------------
// PROPERTY OF Mr. De Palme - DO NOT STEAL
//---------------------------------------------------

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: CODE STILL BEING ADDED TO SCRIPT. DO NOT USE.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

public class GameStateMaschine : MonoBehaviour
{
    // different phases of the game that can change
    // with input from both the code and the player
    public enum GameState
    {
        Idle,
        Menu,
        Map,
        Battle,
        Cutscene,
        GameOver
    }

    // indicates whether or not dialogue is active
    public enum Dialogue
    {
        Off,
        Activate,
        On,
        Deactivate
    }

    // all selections pertaining to the main menu
    public enum Menu
    {
        Off,
        MainMenu,
        Inventory,
        Equipment,
        Classes,
        Skills,
        Status,
        Journal,
        Formation,
        QuickSave,
        Misc
    }

    public GameState gState;
    public Dialogue diag;
    public Menu menu;

    
    
    public List<GameObject> MonsterParty = new List<GameObject>();
    public List<GameObject> poolOfJobs = new List<GameObject>();
    public static GameStateMaschine Instance;
    public GameObject PlayerParty;
    public GameObject dialogueBox;
    public GameObject mainMenuBox;
    public GameObject menuInterface;
    public TextMeshProUGUI currentDialogue;
    public Vector3 positionOnWorldMap;
    public CompScript comps;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        PlayerParty.GetComponent<Party>().gold.SetVal(0);
        PlayerParty.GetComponent<Party>().PartyXP.SetVal(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Map;
        diag   = Dialogue.Off;
        menu   = Menu.Off;   
    }

    // Update is called once per frame
    void Update()
    {
        /*
        else if (Input.GetKeyDown(KeyCode.Q) && gState == GameState.Menu)
        {
            mainMenuBox.SetActive(false);
            Debug.Log("Entered map");
            gState = GameState.Map;
        }
        */

        // manages the game state
        switch (gState)
        {
            case (GameState.Idle):
                break;
            case (GameState.Menu):
                menu = Menu.MainMenu;
                break;
            case (GameState.Map):
                positionOnWorldMap = PlayerParty.transform.GetChild(0).transform.position;
                if (Input.GetKeyDown(KeyCode.J))
                {
                    menuInterface.SetActive(true);
                    Debug.Log("Entered menu");
                    gState = GameState.Menu;
                }
                break;
            case (GameState.Battle):
                menuInterface.gameObject.SetActive(false);
                break;
            case (GameState.Cutscene):
                break;
            case (GameState.GameOver):
                break;
        }

        // manages the dialogue
        switch (diag)
        {
            case (Dialogue.Off):
                break;
            case (Dialogue.Activate):
                dialogueBox.SetActive(true);
                diag = Dialogue.On;
                break;
            case (Dialogue.On):
                break;
            case (Dialogue.Deactivate):
                dialogueBox.SetActive(false);
                diag = Dialogue.Off;
                break;
        }

        // manages the menu
        switch (menu)
        {
            case (Menu.Off):
                break;
            case (Menu.MainMenu):
                break;
            case (Menu.Inventory):
                break;
            case (Menu.Equipment):
                break;
            case (Menu.Classes):
                break;
            case (Menu.Skills):
                break;
            case (Menu.Status):
                break;
            case (Menu.Journal):
                break;
            case (Menu.Formation):
                break;
            case (Menu.QuickSave):
                break;
            case (Menu.Misc):
                break;
        } 
    }

    public void EnterDialogue(List<string> lines, string speakerName, Image speakerIcon)
    {
        dialogueBox.GetComponent<DialogueBox>().lines = lines;
        dialogueBox.GetComponent<DialogueBox>().speakerName.text = speakerName;
        if (speakerIcon != null)
        {
            dialogueBox.GetComponent<DialogueBox>().theCurrentIcon = speakerIcon;
        }
        else
        {
            dialogueBox.GetComponent<DialogueBox>().theCurrentIcon = null;
        }
        diag = Dialogue.Activate;
    }

    public void EnterBattle(GameObject troop)
    {
        gState = GameState.Battle;
        MonsterParty = UnpackMonsters(troop);
        for (int i = 0; i < PlayerParty.transform.childCount; ++i)
        {
            // PlayerParty.transform.GetChild(i).transform.position = new Vector3(0, 0, 0);
        }
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        // change the scene... 
    }

    public List<GameObject> UnpackMonsters(GameObject troop)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject i in troop.GetComponent<MonsterTroop>().monsters)
        {
            i.gameObject.SetActive(true);
            i.transform.SetParent(null);
            result.Add(i);
            Destroy(troop.gameObject);
        }
        return result;
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
        if (scene.name == "SampleScene")
        {
            GameObject manager = GameObject.Find("BattleManager");
            if (manager)
            {
                Debug.Log("Battle manager exists");
                // manager.GetComponent<BattleStateMaschine>().InstantiateAllAllies(PlayerParty.GetComponent<Party>().ReleasePartyMembers());
            }
        }

    }

    
    public void ReinitializeParty()
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Ally"))
        {
            i.transform.SetParent(PlayerParty.transform);
        }
    }
    
}
