using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Jarl Ramos (Geoffrey De Palme)
// Resonant Destiny Computer Entertainment Laboratory
// Inventory.cs
// 8 September 2022
//

public class Inventory : MonoBehaviour
{
    private List<Item> ItemList = new List<Item>();

    public void AddItem(Item item)
    {
        ItemList.Add(item);
    }

    public void SubtractItem(Item item)
    {
        foreach (Item i in ItemList)
        {
            string targetName   = item.GetItemName();
            string iteratedName = i.GetItemName();
            if (targetName == iteratedName)
            {
                ItemList.Remove(i);
                break;
            }
        }
    }

    public string ListItemNames(int index)
    {
        return ItemList[index].GetItemName();
    }

    public int GetItemQuantity(Item item)
    {
        int numberOfItems = 0;

        foreach(Item i in ItemList)
        {
            string targetName   = item.GetItemName();
            string iteratedName = i.GetItemName();
            if (targetName == iteratedName)
            {
                ++numberOfItems;
            }
        }
        return numberOfItems;
    }

}
