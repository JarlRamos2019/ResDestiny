using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSelect : MonoBehaviour
{
    public void Initialize(GameObject theSkill)
    {
        skill = theSkill;
        skillName.text = theSkill.GetComponent<BaseSkill>().skillName;
        desc.text = theSkill.GetComponent<BaseSkill>().skillDescription;
        if (theSkill.GetComponent<BaseSkill>().mpCost != 0 &&
            theSkill.GetComponent<BaseSkill>().hpCost == 0)
        {
            cost.text = theSkill.GetComponent<BaseSkill>().mpCost.ToString() + " MP";
        }
        else if (theSkill.GetComponent<BaseSkill>().mpCost == 0 &&
                 theSkill.GetComponent<BaseSkill>().hpCost != 0)
        {
            cost.text = theSkill.GetComponent<BaseSkill>().hpCost.ToString() + " HP";
        }
        else
        {
            cost.text = "";
        }
        skillIcon.sprite = theSkill.GetComponent<BaseSkill>().skillIcon.sprite;
        componentIcons = theSkill.GetComponent<BaseSkill>().componentIcons;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TextMeshProUGUI skillName;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI ap;
    public Image skillIcon;
    public Image[] componentIcons;
    public GameObject skill;
    public GameObject selector;
}
