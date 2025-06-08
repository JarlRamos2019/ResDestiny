using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvMenu : MonoBehaviour
{
    public enum InvMenuMode
    {
        Choose,
        Target,
    }

    public enum UseOrTransfer
    {
        Use,
        Transfer
    }

    public InvMenuMode mode;
    public UseOrTransfer useOrTransfer;
    public List<GameObject> inventoryButtons = new List<GameObject>();
    public GameObject itemList;
    public GameObject characterSelector;
    public int currentSelection;
    public int selectedCharacterIndex;
    public int selected;
    public GameStateMaschine gMaschine;
    public Inventory targetInventory;
    public GameObject bagOfCarrying;
    public GameObject itemSelectionPrefab;
    public GameObject characterSelectionPrefab;
    public Transform characterSelectorContent;
    public Transform itemListContent;
    public GameObject targetItem;
    public GameObject selectedCharacter;
    public GameObject targetCharacter;
    public Image bigItemImage;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI notesText;
    public TextMeshProUGUI itemType;
    public Transform compContent;
    public TextMeshProUGUI topBarText;
    public GameObject useCheckbox;
    public GameObject transferCheckbox;

    public int chCount;
    public int itCount;

    public Inventory TargetInventory
    {
        get
        {
            return targetInventory;
        }
        set
        {
            if (targetInventory != value)
            {
                targetInventory = value;
                // PopulateItemList();
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
        selectedCharacterIndex = 0;
        GameObject bag = Instantiate(bagOfCarrying, characterSelector.GetComponent<CharacterSelector>().content);
        inventoryButtons.Add(bag);
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
        TargetInventory = gMaschine.PlayerParty.GetComponent<Party>().PartyInventory;
        PopulateCharacterSelector();
        PopulateItemList();
        inventoryButtons.Add(useCheckbox);
        inventoryButtons.Add(transferCheckbox);
        mode = InvMenuMode.Choose;

        selectedCharacter = inventoryButtons[selected];
        useCheckbox.transform.Find("UseEmpty").gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
    }

    // Update is called once per frame
    void Update()
    {
        chCount = characterSelectorContent.transform.childCount;
        itCount = itemListContent.transform.childCount;
        TurnOffAllSelectors();
        topBarText.text = SetTopBarText();
        if (inventoryButtons[selected] != null)
        {
            inventoryButtons[selected].transform.Find("selector").gameObject.SetActive(true);
        }

        if (selected >= chCount && selected < chCount + itCount)
        {
            bigItemImage.sprite = inventoryButtons[selected].GetComponent<ItemSelection>().itemImage.sprite;
            itemType.text = inventoryButtons[selected].GetComponent<ItemSelection>().availableItems[0].GetComponent<Item>().type.ToString();
            infoText.text = inventoryButtons[selected].GetComponent<ItemSelection>().availableItems[0].GetComponent<Item>().itemDescription;
            notesText.text = inventoryButtons[selected].GetComponent<ItemSelection>().availableItems[0].GetComponent<Item>().itemNotes;
        }

        switch (mode)
        {
            case InvMenuMode.Choose:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (selected < chCount && selected > 0)
                    {
                        --selected;
                        selectedCharacter = inventoryButtons[selected].GetComponent<CharacterItem>().character;
                        --selectedCharacterIndex;
                        OnItemListChanged(chCount);
                    }
                    else if (selected > chCount && selected <= chCount + itCount - 1)
                    {
                        --selected;
                        // selectedCharacter = inventoryButtons[selected].GetComponent<CharacterItem>().character;
                    }
                    else if (selected == chCount)
                    {
                        selected = chCount + itCount;
                    }
                    else if (selected == 0)
                    {
                        selected = chCount + itCount;
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (selected >= chCount && selected <= chCount + itCount - 1)
                    {
                        selected = selectedCharacterIndex;
                        selectedCharacter = inventoryButtons[selected].GetComponent<CharacterItem>().character;
                        OnItemListChanged(chCount);
                    }
                    else if (selected == chCount + itCount)
                    {
                        selected = 0;
                        selectedCharacterIndex = 0;
                    }
                    else if (selected == chCount + itCount + 1)
                    {
                        --selected;
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (selected < chCount - 1)
                    {
                        ++selectedCharacterIndex;
                        ++selected;
                        selectedCharacter = inventoryButtons[selected].GetComponent<CharacterItem>().character;
                        OnItemListChanged(chCount);

                    }
                    else if (selected >= chCount && selected < chCount + itCount - 1)
                    {
                        ++selected;
                    }
                    else if (selected == chCount + itCount || selected == chCount + itCount + 1)
                    {
                        selected = 0;
                        selectedCharacterIndex = 0;
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (selected < chCount && selected >= 0)
                    {
                        selected = chCount;
                    }
                    else if (selected == chCount + itCount)
                    {
                        ++selected;
                    }
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    if (selected > chCount - 1 && selected < chCount + itCount)
                    {
                        Debug.Log("Item chosen");
                        ChooseTargetItem();
                        selected = 1;
                        selectedCharacterIndex = 1;
                        mode = InvMenuMode.Target;
                    }
                    else if (selected == chCount + itCount)
                    {
                        GameObject useCheckBox = useCheckbox.transform.Find("UseEmpty").gameObject;
                        GameObject transferCheckBox = transferCheckbox.transform.Find("TransferEmpty").gameObject;
                        if (useCheckBox != null && transferCheckBox != null)
                        {
                            useCheckBox.SetActive(false);
                            transferCheckBox.SetActive(true);
                            useOrTransfer = UseOrTransfer.Use;
                        }
                    }
                    else if (selected == chCount + itCount + 1)
                    {
                        GameObject transferCheckBox = transferCheckbox.transform.Find("TransferEmpty").gameObject;
                        GameObject useCheckBox = useCheckbox.transform.Find("UseEmpty").gameObject;
                        if (transferCheckBox != null && useCheckBox != null)
                        {
                            transferCheckBox.SetActive(false);
                            useCheckBox.SetActive(true);
                            useOrTransfer = UseOrTransfer.Transfer;
                        }
                    }
                }
                break;
            case InvMenuMode.Target:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (selected < chCount && selected > 1)
                    {
                        --selected;
                        targetCharacter = inventoryButtons[selected].GetComponent<CharacterItem>().character;
                        --selectedCharacterIndex;
                    }

                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (selected < chCount - 1)
                    {
                        ++selectedCharacterIndex;
                        ++selected;
                        targetCharacter = inventoryButtons[selected].GetComponent<CharacterItem>().character;

                    }
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    if (useOrTransfer == UseOrTransfer.Use)
                    {
                        Debug.Log("Using item: " + targetItem.GetComponent<Item>().itemName);
                        AdministerItem();
                    }
                    else
                    {
                        Debug.Log("Transferring item: " + targetItem.GetComponent<Item>().itemName);
                        TransferItem();
                    }
                    
                }
                break;
        }

    }  

    public void TurnOffAllSelectors()
    {
        foreach (GameObject i in inventoryButtons)
        {
            if (i != null)
            {
                i.transform.Find("selector").gameObject.SetActive(false);
            }       
        }
    }

    public void PopulateItemList()
    {
        // ClearContent(characterSelectorContent);
        Dictionary<string, List<GameObject>> itemRecord = new Dictionary<string, List<GameObject>>();

        if (targetInventory.fullItemList.Count > 0)
        {
            foreach (GameObject i in targetInventory.fullItemList)
            {
                Debug.Log(i.GetComponent<Item>().itemName);
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
                Debug.Log("Adding item");
                GameObject irec = Instantiate(itemSelectionPrefab, itemListContent);
                irec.GetComponent<ItemSelection>().Initialize(i.Value);
                inventoryButtons.Add(irec);
            }

        }
    }

    public void PopulateCharacterSelector()
    {
        // ClearContent(itemListContent);
        foreach (Transform i in gMaschine.PlayerParty.transform)
        {
            Debug.Log("Adding character");
            GameObject newSelect = Instantiate(characterSelectionPrefab, characterSelectorContent);
            newSelect.GetComponent<CharacterItem>().Initialize(i.gameObject);
            inventoryButtons.Add(newSelect);
        }
    }

    public void ClearContent(Transform content)
    {
        foreach (Transform i in content)
        {
            inventoryButtons.Remove(i.gameObject);
            Destroy(i.gameObject);
        }
    }

    public void ChooseTargetItem()
    {
        int chCount = characterSelectorContent.transform.childCount;
        if (selected >= chCount)
        {
            targetItem = inventoryButtons[selected].GetComponent<ItemSelection>().availableItems[0];
        }
    }

    public void AdministerItem()
    {
        selectedCharacter.GetComponent<Inventory>().SubtractItem(targetItem);
        targetCharacter.GetComponent<Ally>().UseItem(targetItem, null);

        foreach (GameObject i in inventoryButtons)
        {
            ItemSelection itemSelection = i.GetComponent<ItemSelection>();
            if (itemSelection != null)
            {
                if (targetItem.GetComponent<Item>().itemName == itemSelection.availableItems[0].GetComponent<Item>().itemName)
                {
                    int num = int.Parse(i.GetComponent<ItemSelection>().itemQuantity.text);
                    --num;
                    if (num == 0)
                    {
                        inventoryButtons.Remove(i);
                        OnItemListChanged(chCount);
                    }
                    i.GetComponent<ItemSelection>().itemQuantity.text = num.ToString();
                    break;
                }
            }
            
        }
        mode = InvMenuMode.Choose;
    }

    public void TransferItem()
    {
        selectedCharacter.GetComponent<Inventory>().SubtractItem(targetItem);
        targetCharacter.GetComponent<Inventory>().AddItem(targetItem);
        foreach (GameObject i in inventoryButtons)
        {
            ItemSelection itemSelection = i.GetComponent<ItemSelection>();
            if (itemSelection != null)
            {
                if (targetItem.GetComponent<Item>().itemName == itemSelection.availableItems[0].GetComponent<Item>().itemName)
                {
                    int num = int.Parse(i.GetComponent<ItemSelection>().itemQuantity.text);
                    --num;
                    if (num == 0)
                    {
                        inventoryButtons.Remove(i);
                        OnItemListChanged(chCount);
                    }
                    i.GetComponent<ItemSelection>().itemQuantity.text = num.ToString();
                    break;
                }
            }
        }
        mode = InvMenuMode.Choose;
    }

    public string SetTopBarText()
    {
        int chCount = characterSelectorContent.transform.childCount;
        if (inventoryButtons[selectedCharacterIndex].GetComponent<CharacterItem>().chText.text == "Bag of Carrying")
        {
            return "Bag of Carrying";
        }
        else
        {
            string actorName = inventoryButtons[selectedCharacterIndex].GetComponent<CharacterItem>().chText.text;
            if (actorName[actorName.Length - 1] == 's')
            {
                return actorName + "' Bag";
            }
            else
            {
                return actorName + "'s Bag";
            }
        }
    }

    public void OnItemListChanged(int chCount)
    {
        if (inventoryButtons[selectedCharacterIndex].GetComponent<CharacterItem>().chText.text == "Bag of Carrying")
        {
            inventoryButtons.RemoveAt(inventoryButtons.Count - 1);
            inventoryButtons.RemoveAt(inventoryButtons.Count - 1);
            targetInventory = gMaschine.PlayerParty.GetComponent<Party>().PartyInventory;
            ClearContent(itemListContent);
            PopulateItemList();
            inventoryButtons.Add(useCheckbox);
            inventoryButtons.Add(transferCheckbox);
        }
        else
        {
            inventoryButtons.RemoveAt(inventoryButtons.Count - 1);
            inventoryButtons.RemoveAt(inventoryButtons.Count - 1);
            targetInventory = selectedCharacter.GetComponent<Ally>().ActorInventory;
            ClearContent(itemListContent);
            PopulateItemList();
            inventoryButtons.Add(useCheckbox);
            inventoryButtons.Add(transferCheckbox);
        }

    }

    public void OnItemSelectionChanged()
    {

    }
}
