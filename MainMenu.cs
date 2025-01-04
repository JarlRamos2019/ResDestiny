using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public Selected selected;
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        selected = Selected.Inventory;   
    }

    // Update is called once per frame
    void Update()
    {
        GameStateMaschine gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
        if (gMaschine.gState == GameStateMaschine.GameState.Menu)
        {
            if (Input.GetKeyDown(KeyCode.W) && selected != Selected.Inventory)
            {
                --selected;
                Debug.Log("W: " + selected);
            }
            if (Input.GetKeyDown(KeyCode.S) && selected != Selected.QuickSave)
            {
                ++selected;
                Debug.Log("S: " + selected);
            }
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
                    GoToEquipment();
                }
                break;
            case Selected.Jobs:
                TurnOffAllSelectors();
                buttons[2].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.Skills:
                TurnOffAllSelectors();
                buttons[3].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.Status:
                TurnOffAllSelectors();
                buttons[4].transform.GetChild(1).gameObject.SetActive(true);
                break;
            case Selected.LineUp:
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

    public void GoToJobs()
    {
        Debug.Log("Jobs");
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
}

public enum Selected
{
    Inventory,
    Equipment,
    Jobs,
    Skills,
    Status,
    LineUp,
    Misc,
    QuickSave
}
