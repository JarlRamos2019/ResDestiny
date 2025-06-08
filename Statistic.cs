// =============================================================================
// FILE: Statistic.cs
// GAME: Resonant Destiny
//
// DESCRIPTION:
// Definition of a statistic.
// =============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The statistic class
/// </summary>
[System.Serializable]
public class Statistic
{
    /// <summary>
    /// The value of the statistic
    /// </summary>
    [SerializeField] private int statValue;
    /// <summary>
    /// Boolean indicating if a statistic is active
    /// </summary>
    private bool active;

    /// <summary>
    /// Default constructor that instantiates an inactive Statistic object
    /// </summary>
    public Statistic()
    {
        active = false;
    }

    /// <summary>
    /// Special constructor that instantiates an active Statistic object
    /// </summary>
    /// <param name="value">The integer value used to set the Statistic</param>
    public Statistic(int value)
    {
        Init(value);
    }

    /// <summary>
    /// Modifies the integer value of the statistic through addition or subtraction
    /// </summary>
    /// <param name="value">The value being added or subtracted</param>
    public void Modify(int value)
    {
        if (!active)
        {
            Debug.LogError("Error: modification of an inactive statistic is not allowed");
            return;
        }

        statValue += value;
    }

    /// <summary>
    /// Modifies the integer value by either raising it or lowering it by a percentage
    /// </summary>
    /// <param name="op">The operation being performed ("More" or "Less")</param>
    /// <param name="value">The value used to modify the value</param>
    public void AdvModify(Operation op, float value)
    {
        if (!active)
        {
            Debug.LogError("Error: modification of an inactive statistic is not allowed");
            return;
        }

        int rawValue = (int)(statValue * value);

        if (op == Operation.More)
        {
            statValue += rawValue;
        }
        else if (op == Operation.Less)
        {
            statValue -= rawValue;
        }

    }

    /// <summary>
    /// Initializes a Statistic by activating it and setting a value
    /// </summary>
    /// <param name="value">The value that the Statistic will be set to</param>
    public void Init(int value)
    {
        if (active)
        {
            Debug.LogError("Error: this statistic is already active. Canceling initialization...");
            return;
        }
        active = true;
        statValue = value;
    }

    /// <summary>
    /// Sets a Statistic value to a specific value
    /// </summary>
    /// <param name="value">The value that the Statistic will be set to</param>
    public void SetVal(int value)
    {
        if (!active)
        {
            Debug.LogError("Error: modification of an inactive statistic is not allowed");
            return;
        }
        statValue = value;
    }

    /// <summary>
    /// Gets the integer value of the Statistic
    /// </summary>
    /// <returns>The numerical value of the Statistic</returns>
    public int GetVal()
    {
        if (!active)
        {
            Debug.LogError("Error: retrieval of an inactive statistic is not allowed. Defauting to 0...");
            return 0;
        }
        return statValue;
    }

    /// <summary>
    /// Sets the activation status of the Statistic
    /// </summary>
    /// <param name="isActive">Boolean that the active value will be set to</param>
    public void SetActive(bool isActive)
    {
        active = isActive;
    }

    /// <summary>
    /// Gets the activation status of the Statistic
    /// </summary>
    /// <returns>Boolean indicating if the Statistic is active</returns>
    public bool IsActive()
    {
        return active;
    }
}


