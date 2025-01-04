using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetSelect : MonoBehaviour
{
    public void Initialize(GameObject theTarget)
    {
        target = theTarget;
        targetName.text = theTarget.GetComponent<Actor>().GetName();
        targetIcon = theTarget.GetComponent<Actor>().actorIcon;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public TextMeshProUGUI targetName;
    public Image targetIcon;
    public GameObject target;
    public GameObject selector;
}
