// =============================================================================
// FILE: JobMenu.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Provides the code for navigating the job menu from the main menu.
// Contains methods for loading data to each view in the job menu.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// follow this code philosophy:
// "LoadUp" methods load the data from the model
// "Populate" methods update the UI with the new data
// "On" methods respond to player input and make the appropriate changes

/// <summary>
/// The Job Menu class that handles navigation through the job menu
/// </summary>
public class JobMenu : MonoBehaviour
{
    /// <summary>
    /// The side job type enum denoting first or second side job
    /// </summary>
    public enum SideJobType
    {
        First,
        Second
    }
    /// <summary>
    /// The job menu mode enum containing the states the player will be in
    /// when using this menu
    /// </summary>
    public enum JobMenuMode
    {
        SelectJob,
        AssignJob,
        SelectJobSkill
    }
    /// <summary>
    /// The current selected item in the list
    /// </summary>
    public int selected;
    /// <summary>
    /// The current selected item in the job list
    /// </summary>
    public int selectedJobIndex;
    /// <summary>
    /// The number of jobs in the list
    /// </summary>
    public int jobCount;
    /// <summary>
    /// The number of job skills in the list
    /// </summary>
    public int jobSkillCount;
    /// <summary>
    /// The target character's main job
    /// </summary>
    public GameObject allyFirstJob;
    /// <summary>
    /// The target character's first secondary job
    /// </summary>
    public GameObject allySecondJob;
    /// <summary>
    /// The target character's second secondary job
    /// </summary>
    public GameObject allyThirdJob;
    /// <summary>
    /// The target character
    /// </summary>
    public GameObject targetAlly;
    /// <summary>
    /// The job currently selected
    /// </summary>
    public GameObject selectedJob;
    /// <summary>
    /// The list containing all the party's jobs for a character to select
    /// </summary>
    public List<GameObject> partyJobList;
    /// <summary>
    /// The list containing the skills associated with the job rank
    /// </summary>
    public List<GameObject> jobRankSkillList;
    /// <summary>
    /// The list containing the equipment proficiencies relating to the job
    /// </summary>
    public List<EquipType> equipProficiencyList;

    public List<GameObject> allysPoolOfJobs;
    public List<GameObject> jobButtons;
    public Transform jobListContent;
    public Transform jobSkillListContent;
    public TextMeshProUGUI mainJobText;
    public TextMeshProUGUI secondJobText;
    public TextMeshProUGUI thirdJobText;
    public TextMeshProUGUI mainJobRankText;
    public TextMeshProUGUI secondJobRankText;
    public TextMeshProUGUI thirdJobRankText;
    public TextMeshProUGUI stAffSymbol;
    public TextMeshProUGUI agAffSymbol;
    public TextMeshProUGUI viAffSymbol;
    public TextMeshProUGUI enAffSymbol;
    public TextMeshProUGUI deAffSymbol;
    public TextMeshProUGUI chAffSymbol;
    public TextMeshProUGUI luAffSymbol;
    public TextMeshProUGUI inAffSymbol;
    public TextMeshProUGUI peAffSymbol;
    public GameStateMaschine gMaschine;

    public GameObject jobSelectionPrefab;
    public GameObject jobSkillSelectionPrefab;

    public Transform jobSelectionContent;
    public Transform jobSkillSelectionContent;
    public Transform jobProficienciesContent;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        selected = 0;
        selectedJobIndex = 0;
        gMaschine = GameObject.Find("GameManager").GetComponent<GameStateMaschine>();

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (selected < jobCount && selected > 0)
            {
                --selected;
                selectedJob = jobButtons[selected].GetComponent<CharacterItem>().character;
                --selectedJobIndex;
            }
            else if (selected > jobCount && selected <= jobCount + jobSkillCount - 1)
            {
                --selected;
                // selectedJob = jobButtons[selected].GetComponent<CharacterItem>().character;
            }
            else if (selected == jobCount)
            {
                selected = jobCount + jobSkillCount;
            }
            else if (selected == 0)
            {
                selected = jobCount + jobSkillCount;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (selected >= jobCount && selected <= jobCount + jobSkillCount - 1)
            {
                selected = selectedJobIndex;
                selectedJob = jobButtons[selected].GetComponent<CharacterItem>().character;
            }
            else if (selected == jobCount + jobSkillCount)
            {
                selected = 0;
                selectedJobIndex = 0;
            }
            else if (selected == jobCount + jobSkillCount + 1)
            {
                --selected;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selected < jobCount - 1)
            {
                ++selectedJobIndex;
                ++selected;
                selectedJob = jobButtons[selected].GetComponent<CharacterItem>().character;
            }
            else if (selected >= jobCount && selected < jobCount + jobSkillCount - 1)
            {
                ++selected;
            }
            else if (selected == jobCount + jobSkillCount || selected == jobCount + jobSkillCount + 1)
            {
                selected = 0;
                selectedJobIndex = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (selected < jobCount && selected >= 0)
            {
                selected = jobCount;
            }
            else if (selected == jobCount + jobSkillCount)
            {
                ++selected;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (selected > jobCount - 1 && selected < jobCount + jobSkillCount)
            {
                Debug.Log("Job chosen");
                selected = 1;
                selectedJobIndex = 1;
            }
        }

    }

    /// <summary>
    /// Loads the selected character
    /// </summary>
    /// <param name="src">The GameObject representing the target character</param>
    public void LoadUpTheCharacter(GameObject src)
    {
        targetAlly = src.GetComponent<MainCharacterPanel>().ally;
    }

    /// <summary>
    /// Loads all the jobs available to the party
    /// </summary>
    /// <param name="src">The GameObject representing the party</param>
    public void LoadUpAllThePartysAvailableJobs(GameObject src)
    {
        partyJobList = src.GetComponent<Party>().availableJobs;
    }

    /// <summary>
    /// Populates the job list in the menu with the party's available jobs
    /// </summary>
    public void PopulateJobList()
    {
        foreach (GameObject i in partyJobList)
        {
            GameObject newSelect = Instantiate(jobSelectionPrefab, jobSelectionContent);
            newSelect.GetComponent<JobSelection>().Initialize(i.gameObject);
            jobButtons.Add(newSelect);
        }
    }

    /// <summary>
    /// Populates the proficiencies and statistic affinities of the job
    /// </summary>
    public void PopulateJobProficiencyList()
    {
        BaseRPGClass targetJob = selectedJob.GetComponent<BaseRPGClass>();
        stAffSymbol.text = nameof(targetJob.stTier);
        agAffSymbol.text = nameof(targetJob.agTier);
        viAffSymbol.text = nameof(targetJob.viTier);
        enAffSymbol.text = nameof(targetJob.enTier);
        deAffSymbol.text = nameof(targetJob.deTier);
        chAffSymbol.text = nameof(targetJob.chTier);
        luAffSymbol.text = nameof(targetJob.luTier);
        inAffSymbol.text = nameof(targetJob.inTier);
        peAffSymbol.text = nameof(targetJob.peTier);
    }

    /// <summary>
    /// Populates the list of skills associated with the selected job
    /// </summary>
    /// <param name="rank"/>The selected rank</param>
    public void PopulateJobSkillList(int rank)
    {
        BaseRPGClass targetJob = selectedJob.GetComponent<BaseRPGClass>();

        switch (rank)
        {
            case 1:
                foreach (GameObject i in targetJob.rank1JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 2:
                foreach (GameObject i in targetJob.rank2JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 3:
                foreach (GameObject i in targetJob.rank3JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 4:
                foreach (GameObject i in targetJob.rank4JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 5:
                foreach (GameObject i in targetJob.rank5JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 6:
                foreach (GameObject i in targetJob.rank6JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 7:
                foreach (GameObject i in targetJob.rank7JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 8:
                foreach (GameObject i in targetJob.rank8JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 9:
                foreach (GameObject i in targetJob.rank9JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            case 10:
                foreach (GameObject i in targetJob.rank10JobSkills)
                {
                    GameObject newSelect = Instantiate(jobSkillSelectionPrefab, jobSkillSelectionContent);
                    newSelect.GetComponent<JobSelection>().Initialize(i);
                    jobButtons.Add(newSelect);
                }
                break;
            default:
                Debug.LogWarning("Warning: invalid rank");
                break;
        }
    }

    /// <summary>
    /// Activates when the menu is enabled
    /// </summary>
    private void OnEnable()
    {

    }

    /// <summary>
    /// Called whenever the player switches a job; changes the statistics
    /// and skills of one job
    /// </summary>
    public void OnJobSwitched()
    {

    }

    /// <summary>
    /// Called whenever the player switches a job rank; changes the skills
    /// associated with each job rank
    /// </summary>
    public void OnJobRankSwitched()
    {

    }

    /// <summary>
    /// Called whenever the player chooses a new main job for the character
    /// to take
    /// </summary>
    public void OnCharacterMainJobUpdated()
    {

    }

    /// <summary>
    /// Called whenever the play chooses a new side job for the character
    /// to take
    /// </summary>
    /// <param name="sideJobType">Denotes whether it is the first or second job</param>
    public void OnCharacterSideJobUpdated(SideJobType sideJobType)
    {

    }

    /// <summary>
    /// Opens the job selection dialog when a job in the job list is being selected
    /// </summary>
    public void OnJobSelectedInList()
    {

    }

    /// <summary>
    /// Updates the job selection list whenever a character learns a new skill
    /// associated with the job
    /// </summary>
    public void OnJobSkillSelectedInList()
    {

    }
}
