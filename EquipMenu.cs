using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMenu : MonoBehaviour
{
    public enum ActivePanel
    {
        Armor,
        MainSideArms,
    }

    public ActivePanel activePanel;
    public GameObject armorPanel;
    public GameObject mainSideArms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (activePanel)
        {
            case ActivePanel.Armor:
                if (Input.GetKeyUp(KeyCode.D))
                {
                    armorPanel.GetComponent<ArmorPanel>().Deactivate();
                    mainSideArms.GetComponent<ArmPanel>().Activate();
                    activePanel = ActivePanel.MainSideArms;
                }
                break;
            case ActivePanel.MainSideArms:
                if (Input.GetKeyUp(KeyCode.A))
                {
                    mainSideArms.GetComponent<ArmPanel>().Deactivate();
                    armorPanel.GetComponent<ArmorPanel>().Activate();
                    activePanel = ActivePanel.Armor;
                }
                break;
        }
        
    }
}
