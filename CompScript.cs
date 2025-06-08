using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompScript : MonoBehaviour
{
    public Image fireImage;

    public Image RetrieveCompImage(Comp comp)
    {
        switch (comp)
        {
            case Comp.Fire:
                return fireImage;
            default:
                return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
