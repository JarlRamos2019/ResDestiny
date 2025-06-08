using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainCharacterPanel : MonoBehaviour
{
    public TextMeshProUGUI allyName;
    public TextMeshProUGUI allyRank;
    public TextMeshProUGUI allyJob;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    public GameObject healthBar;
    public GameObject mpBar;
    public GameObject ally;
    public Image allyImage;
    

    public void Initialize(GameObject actor)
    {
        ally = actor;
        Ally a = actor.GetComponent<Ally>();
        allyName.text = a.GetName();
        allyRank.text = "Rank " + a.activeJob.rank.GetVal().ToString();
        allyJob.text = a.activeJob.GetComponent<BaseRPGClass>().RPGClassName;
        hpText.text = a.CurHP.GetVal().ToString() + "/" + a.MaxHP.GetVal().ToString();
        mpText.text = a.CurMP.GetVal().ToString() + "/" + a.MaxMP.GetVal().ToString();
        allyImage.sprite = a.actorIcon.sprite;
        healthBar.GetComponent<HealthBar>().currentHP = a.CurHP.GetVal();
        mpBar.GetComponent<MPBar>().currentMP = a.CurMP.GetVal();
        healthBar.GetComponent<HealthBar>().maxHP = a.MaxHP.GetVal();
        mpBar.GetComponent<MPBar>().maxMP = a.MaxMP.GetVal();
    }
}
