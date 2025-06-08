using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Jarl Ramos (Geoffrey De Palme)
// Party.cs
// 8 September 2022
//

public class Party : MonoBehaviour
{
    public static Party instance;

    void Awake()
    {   
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
      
        DontDestroyOnLoad(gameObject);
        // PartyInventory = gameObject.AddComponent<Inventory>();
    }
    private List<GameObject> MainParty = new List<GameObject>();
    private List<GameObject> ReserveParty = new List<GameObject>();

    public Statistic MaxRe;
    public Statistic CurRe;
    public Statistic PartyXP;
    public Statistic gold;
    public int partyLevel;
    public Inventory PartyInventory;
    public List<GameObject> availableJobs;

    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
        {
            MainParty.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }

    public void AddToMain(GameObject NewMember)
    {
        MainParty.Add(NewMember);
    }
    public void AddToReserve(GameObject NewMember)
    {
        ReserveParty.Add(NewMember);
    }
    public void SubtractFromMain(GameObject SubMember)
    {
        foreach (GameObject i in MainParty)
        {
            Ally TargetMember   = SubMember.GetComponent<Ally>();
            Ally IteratedMember = i.GetComponent<Ally>();
            if (TargetMember.GetName() == IteratedMember.GetName())
            {
                MainParty.Remove(i);
                break;
            }
        }
    }
    public void SubtractFromReserve(GameObject SubMember)
    {
        foreach (GameObject i in ReserveParty)
        {
            Ally TargetMember   = SubMember.GetComponent<Ally>();
            Ally IteratedMember = i.GetComponent<Ally>();
            if (TargetMember.GetName() == IteratedMember.GetName())
            {
                ReserveParty.Remove(i);
                break;
            }
        }
    }
    public string PrintMainNames(int index)
    {
        Ally Member = MainParty[index].GetComponent<Ally>();
        return Member.GetName();
    }
    public string PrintReserveNames(int index)
    {
        Ally Member = ReserveParty[index].GetComponent<Ally>();
        return Member.GetName();
    }
    public List<GameObject> ReleasePartyMembers()
    {
        return MainParty;
    }

    public void LevelUp()
    {
        // this is where the party gains a level after gaining enough experience
        // this will also distribute SP for each party member
    }
}
