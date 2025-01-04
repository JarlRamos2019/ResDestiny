using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler
{
    public string whoseTurn;
    public GameObject ActorGameObject;
    public int actorsAP;
    public List<SetAction> ActorsActions = new List<SetAction>();
    public bool validated = false;
}
