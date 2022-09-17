using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Idle;
        diag   = Dialogue.Off;
        menu   = Menu.Off;
    }

    // Update is called once per frame
    void Update()
    {
        // manages the game state
        switch (gState)
        {
            case (GameState.Idle):
                break;
            case (GameState.Menu):
                menu = Menu.MainMenu;
                break;
            case (GameState.Map):
                break;
            case (GameState.Battle):
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
                // SetActive(true) the dialogue box
                diag = Dialogue.On;
                break;
            case (Dialogue.On):
                break;
            case (Dialogue.Deactivate):
                // SetActive(false) the dialogue box
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
}
