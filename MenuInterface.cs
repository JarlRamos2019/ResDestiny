using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInterface : MonoBehaviour
{
    public Menu menuSelection;
    public GameObject MainMenu;
    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    public GameObject JobMenu;
    public GameObject SkillMenu;
    public GameObject StatusMenu;
    public GameObject LineUpMenu;
    public GameObject MiscMenu;
    public GameObject QuickSave;

    // Start is called before the first frame update
    void Start()
    {
        menuSelection = Menu.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (menuSelection)
        {
           
            case (Menu.MainMenu):
                DisableAllMenuItems();
                MainMenu.SetActive(true);
                if (Input.GetKeyDown(KeyCode.J))
                {
                    Debug.Log("Exiting the main menu...");
                    GameObject.Find("GameManager").GetComponent<GameStateMaschine>().gState = GameStateMaschine.GameState.Map;
                    this.gameObject.SetActive(false);
                }
                break;
            case (Menu.Inventory):
                DisableAllMenuItems();
                /*
                if (Input.GetKeyDown(KeyCode.J))
                {
                    Debug.Log("Exiting inventory...");
                }
                */
                InventoryMenu.SetActive(true);
                break;
            case (Menu.Equipment):
                DisableAllMenuItems();
                EquipmentMenu.SetActive(true);
                break;
            case (Menu.Jobs):
                DisableAllMenuItems();
                JobMenu.SetActive(true);
                break;
            case (Menu.Skills):
                DisableAllMenuItems();
                SkillMenu.SetActive(true);
                break;
            case (Menu.Status):
                DisableAllMenuItems();
                StatusMenu.SetActive(true);
                break;
            // case (Menu.Journal):
            //    break;
            case (Menu.LineUp):
                DisableAllMenuItems();
                LineUpMenu.SetActive(true);
                break;
            case (Menu.Misc):
                DisableAllMenuItems();
                MiscMenu.SetActive(true);
                break;
            case (Menu.QuickSave):
                DisableAllMenuItems();
                QuickSave.SetActive(true);
                break;
        }

    }

    public void DisableAllMenuItems()
    {

    }
}

