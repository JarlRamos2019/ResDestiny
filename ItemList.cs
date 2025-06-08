using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public Transform listContent;
    public GameObject itemSelectionPrefab;
    public int itemListIndex;
    public Inventory targetInventory;
    public GameObject inventoryMenu;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        // targetInventory.PropertyChanged += OnInventoryChanged;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //targetInventory.PropertyChanged += OnInventoryChanged;
        //PopulateList();
    }

    public void ClearContent()
    {
        foreach (Transform i in listContent)
        {
            Destroy(i.gameObject);
        }
    }
    /*
    public void PopulateList()
    {
        ClearContent();
        Dictionary<string, List<GameObject>> itemRecord = new Dictionary<string, List<GameObject>>();

        if (targetInventory.fullItemList.Count > 0)
        {
            foreach (GameObject i in targetInventory.fullItemList)
            {
                string itemName = i.GetComponent<Item>().itemName;
                if (itemRecord.ContainsKey(itemName))
                {
                    itemRecord[itemName].Add(i);
                }
                else
                {
                    List<GameObject> newList = new List<GameObject>();
                    newList.Add(i);
                    itemRecord.Add(itemName, newList);
                }
            }

            foreach (KeyValuePair<string, List<GameObject>> i in itemRecord)
            {
                GameObject irec = Instantiate(itemSelectionPrefab, listContent);
                irec.GetComponent<ItemSelection>().Initialize(i.Value);
                //inventoryMenu.GetComponent<InvMenu>().inventoryButtons.Add(irec);
            }
        }
    }
    */

    public void OnInventoryChanged(object sender, PropertyChangedEventArgs e)
    {
        // PopulateList();
    }

    public void NavigateThroughList()
    {
        //TODO: Something...
    }


}
