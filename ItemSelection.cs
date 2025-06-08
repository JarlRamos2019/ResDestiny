using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSelection : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemQuantity;
    public Image itemImage;
    public Image Selector;
    public List<GameObject> availableItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(List<GameObject> theItems)
    {
        itemName.text = theItems[0].GetComponent<Item>().itemName;
       
        itemImage.sprite = theItems[0].GetComponent<Item>().itemIcon.sprite;
        itemQuantity.text = theItems.Count.ToString();
        availableItems = theItems;
    }
}
