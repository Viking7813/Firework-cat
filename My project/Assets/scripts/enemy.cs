using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody body;

    public GameObject point1, point2, point3, point4;

    public float velocity;

    private Vector3 next_pos, targetdir, currentpos;
    //Vector3 targetpos = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        next_pos = point2.transform.position;
        //transform.position = currentpos;
        //Vector3 targetpos = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.normalized == next_pos.normalized)
        {
            next_pos = point3.transform.position;
        }

        if (transform.position.normalized == next_pos.normalized)
        {
            next_pos = point4.transform.position;
        }

        if (transform.position.normalized == next_pos.normalized)
        {
            next_pos = point1.transform.position;
        }

        targetdir = (transform.position - next_pos).normalized;

        body.MovePosition(transform.position - targetdir * Time.deltaTime * velocity);

    }
}
