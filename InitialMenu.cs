using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMenu : MonoBehaviour
{
    public InitialSelected iSelected;
    public GameObject[] selections;
    public BattleStateMaschine bMaschine;

    // Start is called before the first frame update
    void Start()
    {
        bMaschine = GameObject.Find("BattleManager").GetComponent<BattleStateMaschine>();
        iSelected = InitialSelected.Engage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && iSelected != InitialSelected.Engage)
        {
            --iSelected;
            Debug.Log("W: " + iSelected);
        }
        if (Input.GetKeyDown(KeyCode.S) && iSelected != InitialSelected.Retreat)
        {
            ++iSelected;
            Debug.Log("S: " + iSelected);
        }

        switch (iSelected)
        {
            case InitialSelected.Engage:
                TurnOffAllSelectors();
                selections[0].transform.Find("selector").gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.K))
                {
                    bMaschine.bState = BattleStateMaschine.Act.WaitForInput;
                    bMaschine.actorInput = BattleStateMaschine.PlayerGUI.Setup;
                    gameObject.SetActive(false);
                }
                break;
            case InitialSelected.LineUp:
                TurnOffAllSelectors();
                selections[1].transform.Find("selector").gameObject.SetActive(true);
                break;
            case InitialSelected.Brawl:
                TurnOffAllSelectors();
                selections[2].transform.Find("selector").gameObject.SetActive(true);
                break;
            case InitialSelected.Retreat:
                TurnOffAllSelectors();
                selections[3].transform.Find("selector").gameObject.SetActive(true);
                break;
        }
    }

    public void TurnOffAllSelectors()
    {
        foreach (GameObject i in selections)
        {
            i.transform.Find("selector").gameObject.SetActive(false);
        }
    }
}

public enum InitialSelected
{
    Engage,
    LineUp,
    Brawl,
    Retreat
}
