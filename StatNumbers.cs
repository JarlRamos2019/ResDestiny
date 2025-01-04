using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatNumbers : MonoBehaviour
{
    public TextMeshProUGUI hpDisplay;
    public TextMeshProUGUI mpDisplay;
    public TextMeshProUGUI acDisplay;
    public TextMeshProUGUI allyName;
    public GameObject hpCounter;
    public GameObject mpCounter;
    public GameObject acCounter;
    public GameObject ally;
    
    // Start is called before the first frame update
    void Start()
    {
        //hpDisplay = new TextMeshProUGUI();
        //mpDisplay = new TextMeshProUGUI();
        //acDisplay = new TextMeshProUGUI();
    }

    // Update is called once per frame
    void Update()
    {
        hpCounter.GetComponent<HealthBar>().currentHP = ally.GetComponent<Ally>().CurHP.GetVal();
        hpCounter.GetComponent<HealthBar>().maxHP = ally.GetComponent<Ally>().MaxHP.GetVal();
        mpCounter.GetComponent<MPBar>().currentMP = ally.GetComponent<Ally>().CurMP.GetVal();
        mpCounter.GetComponent<MPBar>().maxMP = ally.GetComponent<Ally>().MaxMP.GetVal();
        hpDisplay.SetText(ally.GetComponent<Ally>().CurHP.GetVal().ToString());
        mpDisplay.SetText(ally.GetComponent<Ally>().CurMP.GetVal().ToString());
        acDisplay.SetText(ally.GetComponent<Ally>().CurAC.GetVal().ToString());
        allyName.SetText(ally.GetComponent<Ally>().GetName());
    }
}
