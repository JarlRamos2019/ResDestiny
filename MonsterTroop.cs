using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterTroop : MonoBehaviour
{
    public static MonsterTroop instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public GameObject monsterTroopModel;
    public List<GameObject> monsters;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            Debug.Log("entering battle");
            GameObject.Find("GameManager").GetComponent<GameStateMaschine>().EnterBattle(this.gameObject);
        }
    }
}
