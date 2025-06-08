using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

// =========================================================
// NAME: Jarl Ramos/Geoffrey De Palme
// GAME: Project R.D./Resonant Destiny
// FILE: Inventory.cs
// ORGN: Unity - RD Prototype I
// DATE: 8 September 2022
// =========================================================

public class Inventory : MonoBehaviour, INotifyPropertyChanged
{
    //public List<GameObject> iList = new List<GameObject>();
    //public List<ItemRecord> fullItemList = new List<ItemRecord>();
    public List<GameObject> fullItemList = new List<GameObject>();
    public event PropertyChangedEventHandler PropertyChanged;
    public GameObject angelLeafPrefab;

    public List<GameObject> FullItemList
    {
        get
        {
            return fullItemList;
        }
        set
        {
            if (fullItemList != value)
            {
                fullItemList = value;
                OnPropertyChanged(nameof(FullItemList));
                // add method here
            }
           
        }
    }

    public void Start()
    {
        //angelLeafPrefab = new GameObject();
        GameObject someItem = Instantiate(angelLeafPrefab);
        fullItemList.Add(someItem);    
    }
    public void AddItem(GameObject item)
    {
        /*
        Item item1 = item.GetComponent<Item>();
        if (!fullItemList.Exists(x => x.item == item1))
        {
            ItemRecord addedItem = new ItemRecord();
            addedItem.item = item1;
            addedItem.itemObjects.Add(item);
            FullItemList.Add(addedItem);
        }
        else
        {
            FullItemList.Find(x => x.item == item1).itemObjects.Add(item);
        }
        */

        FullItemList.Add(item);
    }

    public GameObject GetItem(string itemName)
    {
        return fullItemList.Find(x => x.GetComponent<Item>().itemName == itemName);
    }

    public void SubtractItem(GameObject item)
    {/*
        foreach (GameObject i in fullItemList)
        {
            Item item1 = item.GetComponent<Item>();
            string targetName   = item1.itemName;
            string iteratedName = i.GetComponent<Item>().itemName;
            if (targetName == iteratedName)
            {
                FullItemList.Remove(i);
                
                i.itemObjects.RemoveAt(0);
                if (i.itemObjects.Count == 0)
                {
                    FullItemList.Remove(i);
                }
                break;
            }
        }
*/
        Debug.Log("sub item");
        FullItemList.Remove(item);
    }

    public void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

public struct ItemRecord
{
    public Item item;
    public List<GameObject> itemObjects;
}
