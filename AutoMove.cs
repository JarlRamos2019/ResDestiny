using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool MoveTo(Vector3 tar, float animSpeed)
    {
        return tar != (transform.position = Vector3.MoveTowards(transform.position, tar,
                       animSpeed * Time.deltaTime));
    }

    public bool MoveTo(GameObject g, float animSpeed)
    {
        Vector3 tar = g.transform.position;
        return tar != (transform.position = Vector3.MoveTowards(transform.position, tar,
                       animSpeed * Time.deltaTime));
    }

}
