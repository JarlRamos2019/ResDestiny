using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPanel : MonoBehaviour
{
    public enum Selection
    {
        Head,
        Upper,
        Lower,
        Trinket
    }

    private bool freezed;
    public Selection selection;
    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        freezed = false;
        selection = Selection.Head;
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezed)
        {
            if (Input.GetKeyDown(KeyCode.W) && selection != Selection.Head)
            {
                --selection;
            }
            if (Input.GetKeyDown(KeyCode.S) && selection != Selection.Trinket)
            {
                ++selection;
            }
            switch (selection)
            {
                case Selection.Head:
                    TurnOffAllSelectors();
                    buttons[0].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.Upper:
                    TurnOffAllSelectors();
                    buttons[1].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.Lower:
                    TurnOffAllSelectors();
                    buttons[2].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case Selection.Trinket:
                    TurnOffAllSelectors();
                    buttons[3].transform.Find("selector").gameObject.SetActive(true);
                    break;
            }
        }    
    }

    public void Activate()
    {
        freezed = false;
        selection = Selection.Head;
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
