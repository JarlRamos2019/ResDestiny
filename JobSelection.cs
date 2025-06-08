using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobSelection : MonoBehaviour
{
    public Image jobIcon;
    public TextMeshProUGUI jobTitle;
    public GameObject job;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(GameObject targetJob)
    {
        job = targetJob;
        BaseRPGClass jobObject = targetJob.GetComponent<BaseRPGClass>();
        jobIcon.sprite = jobObject.RPGClassIcon.sprite;
        jobTitle.text = jobObject.RPGClassName;
    }
}
