using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourByThree : MonoBehaviour
{
    public int selected;
    public bool freezed;

    public GameObject[] gridSelections;
    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
        freezed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezed)
        {
            if (Input.GetKeyDown(KeyCode.W) && selected > 3)
            {
                selected -= 4;
                Debug.Log("W: " + selected);
            }
            if (Input.GetKeyDown(KeyCode.A) && selected != 0
                                            && selected != 4
                                            && selected != 8)
            {
                --selected;
                Debug.Log("A: " + selected);
            }   
            if (Input.GetKeyDown(KeyCode.S) && selected < 8)
            {
                selected += 4;
                Debug.Log("S: " + selected);
            }
            if (Input.GetKeyDown(KeyCode.D) && selected != 3
                                            && selected != 7
                                            && selected != 11)
            {
                ++selected;
                Debug.Log("D: " + selected);
            }

            switch (selected)
            {
                case 0:
                    TurnOffAllSelectors();
                    gridSelections[0].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 1:
                    TurnOffAllSelectors();
                    gridSelections[1].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 2:
                    TurnOffAllSelectors();
                    gridSelections[2].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 3:
                    TurnOffAllSelectors();
                    gridSelections[3].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 4:
                    TurnOffAllSelectors();
                    gridSelections[4].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 5:
                    TurnOffAllSelectors();
                    gridSelections[5].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 6:
                    TurnOffAllSelectors();
                    gridSelections[6].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 7:
                    TurnOffAllSelectors();
                    gridSelections[7].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 8:
                    TurnOffAllSelectors();
                    gridSelections[8].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 9:
                    TurnOffAllSelectors();
                    gridSelections[9].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 10:
                    TurnOffAllSelectors();
                    gridSelections[10].transform.Find("selector").gameObject.SetActive(true);
                    break;
                case 11:
                    TurnOffAllSelectors();
                    gridSelections[11].transform.Find("selector").gameObject.SetActive(true);
                    break;
            }
        }   
    }

    public void TurnOffAllSelectors()
    {
        foreach (GameObject i in gridSelections)
        {
            i.transform.Find("selector").gameObject.SetActive(false);
        }
    }
}
