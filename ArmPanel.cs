using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPanel : MonoBehaviour
{
    public enum Selection
    {
        MainLeftHand,
        MainRightHand,
        SideLeftHand,
        SideRightHand
    }

    private bool freezed;
    public Selection selection;
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        freezed = true;
        selection = Selection.MainLeftHand;
        TurnOffAllSelectors();
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezed)
        {
            if (Input.GetKeyUp(KeyCode.W) && selection != Selection.MainLeftHand)
            {
                --selection;
            }
            if (Input.GetKeyUp(KeyCode.S) && selection != Selection.SideRightHand)
            {
                ++selection;
            }
            switch (selection)
            {
                case Selection.MainLeftHand:
                    TurnOffAllSelectors();
                    buttons[0].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.MainRightHand:
                    TurnOffAllSelectors();
                    buttons[1].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.SideLeftHand:
                    TurnOffAllSelectors();
                    buttons[2].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.SideRightHand:
                    TurnOffAllSelectors();
                    buttons[3].transform.Find("selector").gameObject.SetActive(true);
                    break;
            }
        }
    }

    public void Activate()
    {
        freezed = false;
        selection = Selection.MainLeftHand;
    }

    public void Deactivate()
    {
        TurnOffAllSelectors();
        freezed = true;
    }

    public void TurnOffAllSelectors()
    {
        foreach (GameObject i in buttons)
        {
            i.transform.Find("selector").gameObject.SetActive(false);
        }
    }
}
