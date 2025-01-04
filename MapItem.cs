using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapItem : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private string itemName;

    public int GetIndex() { return index; }
    public string GetName() { return itemName; }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            SceneManager.LoadScene(itemName, LoadSceneMode.Single);
            Debug.Log("collided");
        }
    }
}
