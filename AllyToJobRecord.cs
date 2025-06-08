// =============================================================================
// FILE: AllyToJobRecord.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the code for the record that each ally will have in regards to their
// learned jobs.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The AllyToJobRecord class.
/// This provides data regarding the ally's progress towards a certain job
/// </summary>
public class AllyToJobRecord : MonoBehaviour
{
    /// <summary>
    /// The job that the ally is pursuing
    /// </summary>
    public BaseRPGClass job;
    /// <summary>
    /// The ally
    /// </summary>
    public Ally ally;
    /// <summary>
    /// The ally's skills they learned while using the job
    /// </summary>
    public List<BaseSkill> learnedSkills = new List<BaseSkill>();
    /// <summary>
    /// The ally's job rank
    /// </summary>
    public Statistic rank;
    /// <summary>
    /// The party's level
    /// </summary>
    public Statistic partyLevel;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="targetJob">The job that will be inserted into the new record</param>
    /// <param name="targetAlly">The ally using the job</param>
    /// <param name="pLevel">The party level</param>
    public AllyToJobRecord(BaseRPGClass targetJob, Ally targetAlly, int pLevel)
    {
        job = targetJob;
        ally = targetAlly;
        learnedSkills.Clear();
        rank.SetVal(1);
        partyLevel.SetVal(pLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This will be called when the ally equips the job
    /// </summary>
    public void OnAllyJobEquipped()
    {
        job.OnEquipThisJob(ally, rank.GetVal(), partyLevel.GetVal());
    }

    /// <summary>
    /// This will be called when the ally unequips the job
    /// </summary>
    public void OnAllyJobUnequipped()
    {
        job.OnUnequipThisJob(ally, rank.GetVal(), partyLevel.GetVal());
    }

    /// <summary>
    /// Determines if the ally has learned the skill associated with the job
    /// </summary>
    /// <param name="skill">The skill being compared</param>
    /// <returns>A result that signifies whether the ally has learned the job</returns>
    public bool DidTheAllyLearnTheSkill(GameObject skillObject)
    {
        BaseSkill skill = skillObject.GetComponent<BaseSkill>();
        if (learnedSkills.Find(theSkill => theSkill == skill) != null)
        {
            return true;
        }

        return false;
    }
}
