using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public Selected selected;
    public GameObject[] buttons;
    public GameObject MainCharPanelPrefab;
    public Transform MainCharPanelContent;
    public GameStateMaschine gMaschine;
    public GameObject gManager;
    public List<GameObject> characterButtons;
    public int selectedCharacterIndex;
    public ChooseState cState;
    public bool targetCharacterSelection;

    // Start is called before the first frame update
    void Start()
    {
        targetCharacterSelection = false;
        selected = Selected.Inventory;
        selectedCharacterIndex = 0;
        // gMaschine = gManager.GetComponent<GameStateMaschine>();
    }

    private void OnEnable()
    {
        PopulateTheCharacterPanels();
    }

    private void OnDisable()
    {
        DestroyTheCharacterPanels();
    }
    // Update is called once per frame
    void Update()
    {
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
        switch (cState)
        {
            case ChooseState.SelectMenu:
                if (gMaschine.gState == GameStateMaschine.GameState.Menu)
                {
                    if (Input.GetKeyDown(KeyCode.W) && selected != Selected.Inventory &&
                        selected != Selected.Skills)
                    {
                        --selected;
                        Debug.Log("W: " + selected);
                    }
                    if (Input.GetKeyDown(KeyCode.S) && selected != Selected.LineUp &&
                        selected != Selected.QuickSave)
                    {
                        ++selected;
                        Debug.Log("S: " + selected);
                    }
                    if (Input.GetKeyDown(KeyCode.A) && selected > Selected.LineUp)
                    {
                        selected -= 4;
                        Debug.Log("A: " + selected);
                    }
                    if (Input.GetKeyDown(KeyCode.D) && selected <= Selected.LineUp)
                    {
                        selected += 4;
                        Debug.Log("D: " + selected);
                    }
                }
                    break;
            case ChooseState.SelectCharacter:
                break;
        }

        switch (selected)
        {
            case Selected.Inventory:
                TurnOffAllSelectors();
                buttons[0].transform.GetChild(1).gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.K))
                {
                    GoToInventory();
                }
                break;
            case Selected.Equipment:
                TurnOffAllSelectors();
                buttons[1].transform.GetChild(1).gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.K))
                {
                    TurnOffAllSelectors();
                    targetCharacterSelection = true;
                    cState = ChooseState.SelectCharacter;
                    NavigateThroughCharacterPanels();
                    GoToEquipment();
                }
                break;
            case Selected.Jobs:
                TurnOffAllSelectors();
                buttons[2].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.LineUp:
                TurnOffAllSelectors();
                buttons[3].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.Skills:
                TurnOffAllSelectors();
                buttons[4].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.Status:
                TurnOffAllSelectors();
                buttons[5].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.Misc:
                TurnOffAllSelectors();
                buttons[6].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.QuickSave:
                TurnOffAllSelectors();
                buttons[7].transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    private void Awake()
    {
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
    }

    public void TurnOffAllSelectors()
    {
        foreach (GameObject i in buttons)
        {
            i.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void GoToInventory()
    {
        Debug.Log("Inventory");
        GameObject.Find("MenuInterface").GetComponent<MenuInterface>().menuSelection = Menu.Inventory;
        this.gameObject.SetActive(false);
    }

    public void GoToEquipment()
    {
        Debug.Log("Equipment");

        GameObject.Find("MenuInterface").GetComponent<MenuInterface>().menuSelection = Menu.Equipment;
        this.gameObject.SetActive(false);
    }

    public void GoToJobs(GameObject theSelection)
    {
        Debug.Log("Jobs");
        GameObject.Find("MenuInterface").GetComponent<MenuInterface>().menuSelection = Menu.Jobs;
        this.gameObject.SetActive(false);
    }

    public void GoToSkills()
    {
        Debug.Log("Skills");
    }

    public void GoToStatus()
    {
        Debug.Log("Status");
    }

    public void GoToLineUp()
    {
        Debug.Log("Line-Up");
    }

    public void GoToMisc()
    {
        Debug.Log("Misc.");
    }

    public void GoToQuickSave()
    {
        Debug.Log("Quick Save");
    }

    public void PopulateTheCharacterPanels()
    {
        GameObject partyObject = gMaschine.PlayerParty;
        foreach (Transform i in partyObject.transform)
        {
            GameObject newPanel = Instantiate(MainCharPanelPrefab, MainCharPanelContent);
            newPanel.GetComponent<MainCharacterPanel>().Initialize(i.gameObject);
        }
    }

    public void DestroyTheCharacterPanels()
    {
        foreach (Transform i in MainCharPanelContent)
        {
            Destroy(i.gameObject);
        }
    }

    public void NavigateThroughCharacterPanels()
    {
        if (targetCharacterSelection)
        {
            if (Input.GetKeyDown(KeyCode.W) && (selectedCharacterIndex != 0 || selectedCharacterIndex != 3))
            {
                --selectedCharacterIndex;
            }
            if (Input.GetKeyDown(KeyCode.A) && selectedCharacterIndex > 2 && selectedCharacterIndex < 6)
            {
                selectedCharacterIndex -= 2;
            }
            if (Input.GetKeyDown(KeyCode.S) && (selectedCharacterIndex != 2 || selectedCharacterIndex != 5))
            {
                ++selectedCharacterIndex;
            }
            if (Input.GetKeyDown(KeyCode.D) && (selectedCharacterIndex > 0 || selectedCharacterIndex < 3))
            {
                selectedCharacterIndex += 2;
            }
            targetCharacterSelection = false;
        }

    }

}


