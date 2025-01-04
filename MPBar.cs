using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPBar : MonoBehaviour
{
    public int maxMP;
    public int currentMP;
    public Image blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blue.fillAmount = (float)currentMP / (float)maxMP;
    }
}
