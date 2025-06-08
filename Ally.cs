// =============================================================================
// FILE: Ally.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the logic for ally characters in the game.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The ally class
/// </summary>
[System.Serializable]
public class Ally : Actor
{
    /// <summary>
    /// The enum for the first and second sub jobs
    /// </summary>
    public enum SubJobSlot
    {
        First,
        Second
    }

    /// <summary>
    /// Boolean signifying if the ally is left-handed
    /// </summary>
    public bool isLeftHanded;
    /// <summary>
    /// The record representing the ally's active job and their data regarding
    /// their job status
    /// </summary>
    public AllyToJobRecord activeJob;
    /// <summary>
    /// List of all of the skills the ally has learned
    /// </summary>
    public List<GameObject> allAllysSkills = new List<GameObject>();
    /// <summary>
    /// The record list representing the data for the ally's sub jobs
    /// </summary>
    public List<AllyToJobRecord> activeSubJob = new List<AllyToJobRecord>();
    /// <summary>
    /// Records of all jobs the ally has experience in
    /// </summary>
    public List<AllyToJobRecord> allysJobList = new List<AllyToJobRecord>();
    /// <summary>
    /// The level of the party the ally is in
    /// </summary>
    public Statistic allysPartyLevel;
    /// <summary>
    /// The piece of equipment on the ally's head
    /// </summary>
    public Equipment headArmor;
    /// <summary>
    /// The piece of armor on the ally's upper body
    /// </summary>
    public Equipment upperArmor;
    /// <summary>
    /// The piece of armor on the ally's lower body
    /// </summary>
    public Equipment lowerArmor;
    /// <summary>
    /// The weapon in the ally's left hand
    /// </summary>
    public Equipment leftHandWeapon;
    /// <summary>
    /// The weapon in the ally's right hand
    /// </summary>
    public Equipment rightHandWeapon;

    /// <summary>
    /// Finds a job record associated with an ally's job
    /// </summary>
    /// <param name="jobName">The name of the job</param>
    /// <returns>A job record corresponding to the given job name</returns>
    public AllyToJobRecord CheckoutJobRecord(string jobName)
    {
        foreach (AllyToJobRecord i in allysJobList)
        {
            if (i.job.RPGClassName == jobName)
            {
                return i;
            }
        }
        return null;
    }

    /// <summary>
    /// Equips a set of equippables to the actor
    /// </summary>
    /// <param name="equippables">The list of equippables the ally has</param>
    public void Equip(List<GameObject> equippables)
    {
        foreach (GameObject i in equippables)
        {
            Equipment targetEquip = i.GetComponent<Equipment>();
            switch (targetEquip.equipRegion)
            {
                case EquipRegion.Head:
                    headArmor = targetEquip;
                    break;
                case EquipRegion.UpperArmor:
                    upperArmor = targetEquip;
                    break;
                case EquipRegion.LowerArmor:
                    lowerArmor = targetEquip;
                    break;
                case EquipRegion.LeftHand:
                    leftHandWeapon = targetEquip;
                    break;
                case EquipRegion.RightHand:
                    rightHandWeapon = targetEquip;
                    break;
                case EquipRegion.Trinket:
                    trinket = targetEquip;
                    break;
                default:
                    Debug.LogError("Equip() - Error: invalid equip region");
                    break;
            }
            targetEquip.OnEquip(this.gameObject);
        }
    }

    /// <summary>
    /// Unequips a piece of equipment from the ally
    /// </summary>
    /// <param name="targetRegion">The target armor region</param>
    public void Unequip(EquipRegion targetRegion)
    {
        switch (targetRegion)
        {
            case EquipRegion.Head:
                headArmor.OnUnequip(this.gameObject);
                headArmor = null;
                break;
            case EquipRegion.UpperArmor:
                upperArmor.OnUnequip(this.gameObject);
                break;
            case EquipRegion.LowerArmor:
                lowerArmor.OnUnequip(this.gameObject);
                break;
            case EquipRegion.LeftHand:
                leftHandWeapon.OnUnequip(this.gameObject);
                break;
            case EquipRegion.RightHand:
                rightHandWeapon.OnUnequip(this.gameObject);
                break;
            case EquipRegion.Trinket:
                trinket.OnUnequip(this.gameObject);
                break;
            default:
                Debug.LogError("Unequip() - Error: invalid equip region");
                break;
        }
    }

    /// <summary>
    /// Swaps a piece of equipment for another; takes a list of equipment pieces
    /// </summary>
    /// <param name="equippables">The list of equipment pieces</param>
    public void SwapEquipment(List<GameObject> equippables)
    {
        foreach (GameObject i in equippables)
        {
            Equipment targetEquip = i.GetComponent<Equipment>();
            Unequip(targetEquip.equipRegion);
        }
        Equip(equippables);
    }

    /// <summary>
    /// Allows the ally to switch their main job
    /// </summary>
    /// <param name="targetJob">The job they want to switch to</param>
    public void SwitchMainJob(BaseRPGClass targetJob)
    {
        AllyToJobRecord jobRecord = CheckoutJobRecord(targetJob.RPGClassName);
        if (jobRecord == null)
        {
            AllyToJobRecord newRecord = new AllyToJobRecord(targetJob, this, allysPartyLevel.GetVal());
            allysJobList.Add(newRecord);
            activeJob = newRecord;  
        }
        else
        {
            activeJob = jobRecord;
        }
        activeJob.OnAllyJobEquipped();
    }

    /// <summary>
    /// Allows the ally to switch their sub jobs
    /// </summary>
    /// <param name="targetJob">The job they want to switch to</param>
    /// <param name="slot">Designates either first or second sub job</param>
    public void SwitchSubJobs(BaseRPGClass targetJob, SubJobSlot slot)
    {
        switch (slot)
        {
            case SubJobSlot.First:
                activeSubJob[0].OnAllyJobUnequipped();
                AllyToJobRecord jobRecord = CheckoutJobRecord(targetJob.RPGClassName);
                if (jobRecord == null)
                {
                    AllyToJobRecord newRecord = new AllyToJobRecord(targetJob, this, allysPartyLevel.GetVal());
                    allysJobList.Add(newRecord);
                    activeSubJob[0] = newRecord;
                }
                else
                {
                    activeSubJob[0] = jobRecord;
                }
                activeSubJob[0].OnAllyJobEquipped();
                break;
            case SubJobSlot.Second:
                activeSubJob[1].OnAllyJobUnequipped();
                jobRecord = CheckoutJobRecord(targetJob.RPGClassName);
                if (jobRecord == null)
                {
                    AllyToJobRecord newRecord = new AllyToJobRecord(targetJob, this, allysPartyLevel.GetVal());
                    allysJobList.Add(newRecord);
                    activeSubJob[1] = newRecord;
                }
                else
                {
                    activeSubJob[1] = jobRecord;
                }
                activeSubJob[1].OnAllyJobEquipped();
                break;
            default:
                Debug.LogError("SwitchSubJobs() - Error: invalid sub job slot");
                break;
        }

    }

    public void AddToPreparedSkillList(string skillName)
    {
        //TODO: AddToPreparedSkillList()
    }

    public void RemoveFromPreparedSkillList(string skillName)
    {
        //TODO: RemoveFromPreparedSkillList()
    }
}

