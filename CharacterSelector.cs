using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject characterItemPrefab;
    public GameStateMaschine gMaschine;
    public List<GameObject> party;
    public Transform content;
    public bool isActive;
    public GameObject inventoryMenu;
    public void PopulateSelector()
    {
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
        foreach (Transform i in gMaschine.PlayerParty.transform)
        {
            GameObject newSelect = Instantiate(characterItemPrefab, content);
            newSelect.GetComponent<CharacterItem>().Initialize(i.gameObject);
            //inventoryMenu.GetComponent<InvMenu>().inventoryButtons.Add(newSelect);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();
        foreach (Transform i in gMaschine.PlayerParty.transform)
        {
            party.Add(i.gameObject);
        }
        // PopulateSelector();
        */
    }

    private void OnEnable()
    {
        // PopulateSelector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
