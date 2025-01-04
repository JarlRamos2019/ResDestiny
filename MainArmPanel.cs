using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainArmPanel : MonoBehaviour
{
    public enum Selection
    {
        LeftHand,
        RightHand,
    }

    private bool freezed;
    public Selection selection;
    public GameObject lHand;
    public GameObject rHand;
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        freezed = true;
        selection = Selection.LeftHand;
        TurnOffAllSelectors();
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezed)
        {
            if (Input.GetKeyUp(KeyCode.W) && selection != Selection.LeftHand)
            {
                --selection;
            }
            if (Input.GetKeyUp(KeyCode.S) && selection != Selection.RightHand)
            {
                ++selection;
            }
            switch (selection)
            {
                case Selection.LeftHand:
                    TurnOffAllSelectors();
                    buttons[0].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.RightHand:
                    TurnOffAllSelectors();
                    buttons[1].transform.Find("selector").gameObject.SetActive(true);
                    break;
            }
        } 
    }

    /*
    public void Activate(Direction direction)
    {
        freezed = false;
        switch (direction)
        {
            case Direction.Down:
                selection = Selection.RightHand;
                break;
            case Direction.Left:
                selection = Selection.LeftHand;
                break;
            default:
                selection = Selection.LeftHand;
                break;
        }
    }
    */

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
