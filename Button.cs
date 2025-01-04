using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Button : MonoBehaviour
{
    public delegate void OnPress();
    public OnPress presser;
    public void foo()
    {
        Debug.Log("foo");
    }
}
