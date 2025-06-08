// =============================================================================
// FILE: BaseRPGClass.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the code for jobs in the game.
// Subclass this class for each job that will be featured.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The BaseRPGClass class.
/// Represents a job in the game
/// </summary>
public class BaseRPGClass : MonoBehaviour
{
    /// <summary>
    /// Represents the affinity to each statistic the job has.
    /// Highest affinity = SS;
    /// lowest affinity = E.
    /// Higher affinity means that the bonus will be bigger and the ally will
    /// receive more points towards that statistic when the party levels up
    /// </summary>
    public enum RPGStatTier
    {
        SS,
        S,
        A,
        B,
        C,
        D,
        E
    }

    /// <summary>
    /// The type of job each job will have.
    /// Pugilists specialize in fighting,
    /// arcanists specialize in magic,
    /// and specialists specialize in extra tasks.
    /// Can be combined
    /// </summary>
    public enum RPGClassType
    {
        Pugilist,
        Specialist,
        Arcanist,
        PugSpe,
        PugArc,
        SpeArc,
        PugSpeArc
    }

    /// <summary>
    /// The name of the job
    /// </summary>
    public string RPGClassName;
    /// <summary>
    /// The job type of the job
    /// </summary>
    public RPGClassType rpgClassType;
    /// <summary>
    /// The job's affinity to the Strength statistic
    /// </summary>
    public RPGStatTier stTier;
    /// <summary>
    /// The job's affinity to the Agility statistic
    /// </summary>
    public RPGStatTier agTier;
    /// <summary>
    /// The job's affinity to the Vitality statistic
    /// </summary>
    public RPGStatTier viTier;
    /// <summary>
    /// The job's affinity to the Endurance statistic
    /// </summary>
    public RPGStatTier enTier;
    /// <summary>
    /// The job's affinity to the Devotion statistic
    /// </summary>
    public RPGStatTier deTier;
    /// <summary>
    /// The job's affinity to the Charisma statistic
    /// </summary>
    public RPGStatTier chTier;
    /// <summary>
    /// The job's affinity to the Luck statistic
    /// </summary>
    public RPGStatTier luTier;
    /// <summary>
    /// The job's affinity to the Intelligence statistic
    /// </summary>
    public RPGStatTier inTier;
    /// <summary>
    /// The job's affinity to the Perception statistic
    /// </summary>
    public RPGStatTier peTier;
    /// <summary>
    /// The job's equipment proficiencies
    /// </summary>
    public List<GameObject> EqProficiencies = new List<GameObject>();
    /// <summary>
    /// The job's rank 1 skills
    /// </summary>
    public List<GameObject> rank1JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 2 skills
    /// </summary>
    public List<GameObject> rank2JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 3 skills
    /// </summary>
    public List<GameObject> rank3JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 4 skills
    /// </summary>
    public List<GameObject> rank4JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 5 skills
    /// </summary>
    public List<GameObject> rank5JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 6 skills
    /// </summary>
    public List<GameObject> rank6JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 7 skills
    /// </summary>
    public List<GameObject> rank7JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 8 skills
    /// </summary>
    public List<GameObject> rank8JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 9 skills
    /// </summary>
    public List<GameObject> rank9JobSkills = new List<GameObject>();
    /// <summary>
    /// The job's rank 10 skills
    /// </summary>
    public List<GameObject> rank10JobSkills = new List<GameObject>();
    /// <summary>
    /// The image representing the job's icon
    /// </summary>
    public Image RPGClassIcon;

    /// <summary>
    /// Calculates the bonus amount for a statistic;
    /// adding this to the statistic will apply the job's bonus
    /// </summary>
    /// <param name="statTier">The tier corresponding to the statistic</param>
    /// <param name="jobRank">The job rank of the ally who has the job</param>
    /// <param name="partyLevel">The party's level</param>
    /// <returns>The bonus amount to be added to the statistic</returns>
    public int CalculateBonus(RPGStatTier statTier, int jobRank, int partyLevel)
    {
        int bonus = 0;
        switch (statTier)
        {
            case (RPGStatTier.SS):
                bonus = 70 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
            case (RPGStatTier.S):
                bonus = 50 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
            case (RPGStatTier.A):
                bonus = 40 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
            case (RPGStatTier.B):
                bonus = 30 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
            case (RPGStatTier.C):
                bonus = 20 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
            case (RPGStatTier.D):
                bonus = 10 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
            case (RPGStatTier.E):
                bonus = 5 * (int)(0.25f * jobRank + 0.1f * partyLevel);
                break;
        }

        return bonus;
    }

    /// <summary>
    /// Aggregates all the job's skills into one list
    /// </summary>
    /// <returns>An aggregated job list</returns>
    public List<GameObject> AggregateAllJobSkills()
    {
        List<GameObject> allJobs = new List<GameObject>();

        // add all rank 1 jobs
        foreach (GameObject i in rank1JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 2 jobs
        foreach (GameObject i in rank2JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 3 jobs
        foreach (GameObject i in rank3JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 4 jobs
        foreach (GameObject i in rank4JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 5 jobs
        foreach (GameObject i in rank5JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 6 jobs
        foreach (GameObject i in rank6JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 7 jobs
        foreach (GameObject i in rank7JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 8 jobs
        foreach (GameObject i in rank8JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 9 jobs
        foreach (GameObject i in rank9JobSkills)
        {
            allJobs.Add(i);
        }

        // add all rank 10 jobs
        foreach (GameObject i in rank10JobSkills)
        {
            allJobs.Add(i);
        }

        return allJobs;
    }

    /// <summary>
    /// Applies job effects to the ally when equipped
    /// </summary>
    /// <param name="ally">The ally that will equip the job</param>
    /// <param name="jobRank">The ally's job rank</param>
    /// <param name="partyLevel">The party's level</param>
    public virtual void OnEquipThisJob(Ally ally, int jobRank, int partyLevel)
    {
        ally.St.Modify(CalculateBonus(stTier, jobRank, partyLevel));
        ally.Ag.Modify(CalculateBonus(agTier, jobRank, partyLevel));
        ally.Vi.Modify(CalculateBonus(viTier, jobRank, partyLevel));
        ally.En.Modify(CalculateBonus(enTier, jobRank, partyLevel));
        ally.De.Modify(CalculateBonus(deTier, jobRank, partyLevel));
        ally.Ch.Modify(CalculateBonus(chTier, jobRank, partyLevel));
        ally.Lu.Modify(CalculateBonus(luTier, jobRank, partyLevel));
        ally.In.Modify(CalculateBonus(inTier, jobRank, partyLevel));
        ally.Pe.Modify(CalculateBonus(peTier, jobRank, partyLevel));
    }

    /// <summary>
    /// Unapplies job affects from the ally when unequipped
    /// </summary>
    /// <param name="ally">The ally that will unequip the job</param>
    /// <param name="jobRank">The ally's job rank</param>
    /// <param name="partyLevel">The party's level</param>
    public virtual void OnUnequipThisJob(Ally ally, int jobRank, int partyLevel)
    {
        ally.St.Modify(-CalculateBonus(stTier, jobRank, partyLevel));
        ally.Ag.Modify(-CalculateBonus(agTier, jobRank, partyLevel));
        ally.Vi.Modify(-CalculateBonus(viTier, jobRank, partyLevel));
        ally.En.Modify(-CalculateBonus(enTier, jobRank, partyLevel));
        ally.De.Modify(-CalculateBonus(deTier, jobRank, partyLevel));
        ally.Ch.Modify(-CalculateBonus(chTier, jobRank, partyLevel));
        ally.Lu.Modify(-CalculateBonus(luTier, jobRank, partyLevel));
        ally.In.Modify(-CalculateBonus(inTier, jobRank, partyLevel));
        ally.Pe.Modify(-CalculateBonus(peTier, jobRank, partyLevel));
    }
}
