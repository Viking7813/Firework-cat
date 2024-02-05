using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent meshAgent;

    public List<GameObject> waypoints;

    public GameObject player;

    public float velocity, index, distance;

    private Vector3 next_pos, destination;

    public bool chasing = false;
    private bool R = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (R == false)
        {
            meshAgent.ResetPath();
            R = true;
        }
        if (chasing == false)
        {
                destination = waypoints[(int)index].transform.position;
                next_pos = Vector3.MoveTowards(transform.position, destination, velocity * Time.deltaTime);
                transform.position = next_pos;

                distance = Vector3.Distance(transform.position, destination);
                if (distance <= 0.05)
                {
                    if (index < waypoints.Count - 1)
                        index++;
                    else
                        index = 0;
                }
        }
        if (chasing == true)
        {
            meshAgent.SetDestination(player.transform.position);
            R = false;
        }
    }
}