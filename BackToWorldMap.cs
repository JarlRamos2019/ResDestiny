using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToWorldMap : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            SceneManager.LoadScene("WorldMap", LoadSceneMode.Single);
            Debug.Log("back to world map");
        }
    }
}
