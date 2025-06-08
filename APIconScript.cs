using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APIconScript : MonoBehaviour
{
    public readonly float SIDE_LENGTH = 70f;

    public void Initialize(Image img)
    {
        this.gameObject.GetComponent<Image>().sprite = img.sprite;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(SIDE_LENGTH, SIDE_LENGTH);
    }
}
