// =============================================================================
// FILE: NonPlayerCharacter.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the logic for non-player characters in the game.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : Actor
{
    /// <summary>
    /// The radius where if the player is within it, they can engage in conversation
    /// with the NPC
    /// </summary>
    public float npcRadius;
    /// <summary>
    /// Signifies if the player is within the NPC's radius
    /// </summary>
    public bool isPlayerWithinRadius;
    /// <summary>
    /// Signifies if the NPC can participate in battle
    /// </summary>
    public bool isCombatant;
    /// <summary>
    /// The NPC's dialogue
    /// </summary>
    public List<string> lines = new List<string>();
    /// <summary>
    /// The NPC's disposition towards the player
    /// </summary>
    public Statistic disposition;
    /// <summary>
    /// Reference to the game state maschine
    /// </summary>
    public GameStateMaschine gMaschine;
    /// <summary>
    /// The NPC's lore
    /// </summary>
    public List<string> npcLore = new List<string>();

    /// <summary>
    /// The Start method
    /// </summary>
    private void Start()
    {
        isPlayerWithinRadius = false;
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
    }

    /// <summary>
    /// The Update method
    /// </summary>
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(this.gameObject.transform.position, npcRadius);
        foreach (Collider i in colliders)
        {
            isPlayerWithinRadius = i.CompareTag("Ally");
        }
        TriggerDialogue();
    }

    /// <summary>
    /// Triggers a conversation between the player and the NPC
    /// </summary>
    void TriggerDialogue()
    {
        if (isPlayerWithinRadius && Input.GetKeyDown(KeyCode.K) && !gMaschine.dialogueBox.gameObject.activeSelf)
        {
            Debug.Log("hellou");
            gMaschine.EnterDialogue(lines, actorName, actorIcon);
        }
    }
}
