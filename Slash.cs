using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : BattleSkill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Effects()
    {
        base.Effects();
    }

    public override void OnEffectEnd()
    {
        base.OnEffectEnd();
    }

    public override IEnumerator Sequence(GameObject src, GameObject[] targets)
    {
        if (targets[0] == null)
        {
            yield break;
        }

        Vector3 targetPosition = new Vector3(targets[0].transform.position.x,
                                            targets[0].transform.position.y,
                                            targets[0].transform.position.z - 1.0f);
        StartCoroutine(src.GetComponent<FighterStateMaschine>().RotateTowardsLocation(targetPosition));

        while (src.GetComponent<FighterStateMaschine>().MoveToLocation(targetPosition))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        // exchange hits and do damage
        string n = "";
        if (src.CompareTag("Ally"))
        {
            n = src.GetComponent<FighterStateMaschine>().BaseAlly.GetName();
        }
        else if (src.CompareTag("Enemy"))
        {
            n = src.GetComponent<FighterStateMaschine>().BaseEnemy.GetName();
        }
        int dmg = src.GetComponent<FighterStateMaschine>().DealDamage();
        Debug.Log(n + " attacks! " + dmg + " dmg!");
        targets[0].GetComponent<FighterStateMaschine>().TakeDamage(dmg);
        yield return new WaitForSeconds(0.05f);
    }
}
