using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterItem : MonoBehaviour
{
    public TextMeshProUGUI chText;
    public TextMeshProUGUI hpNum;
    public TextMeshProUGUI mpNum;
    public Image chIcon;
    public GameObject character;
    public GameObject healthBar;
    public GameObject mpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(GameObject targetCh)
    {
        chText.text = targetCh.GetComponent<Ally>().GetName();
        chIcon.sprite = targetCh.GetComponent<Ally>().actorIcon.sprite;
        character = targetCh;
        hpNum.text = targetCh.GetComponent<Ally>().CurHP.GetVal().ToString();
        mpNum.text = targetCh.GetComponent<Ally>().CurMP.GetVal().ToString();
        healthBar.GetComponent<HealthBar>().currentHP = targetCh.GetComponent<Ally>().CurHP.GetVal();
        mpBar.GetComponent<MPBar>().currentMP = targetCh.GetComponent<Ally>().CurMP.GetVal();
        healthBar.GetComponent<HealthBar>().maxHP = targetCh.GetComponent<Ally>().MaxHP.GetVal();
        mpBar.GetComponent<MPBar>().maxMP = targetCh.GetComponent<Ally>().MaxMP.GetVal();
    }


}
