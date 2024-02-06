using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour
{
    public NavMeshAgent meshAgent;

    public List<GameObject> waypoints;

    public GameObject player;

    public float velocity, index, distance, radius, angle;

    public Vector3 next_pos, destination;

    public bool chasing = false;
    public bool onpath = true;
    private bool canSeePlayer = false;

    public LayerMask targetMask, obstructionMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing == false)
        {
            if (onpath == false)
            {
                //(Kanske göra så att den sätte destination till närmaste punkten.)

                meshAgent.SetDestination(destination);
                if (transform.position.x == destination.x && transform.position.z == destination.z)
                {
                    onpath = true;
                }    
            }
            else if (onpath == true)
            {
                meshAgent.ResetPath();
                destination = waypoints[(int)index].transform.position;
                next_pos = Vector3.MoveTowards(transform.position, destination, velocity * Time.deltaTime);
                transform.position = next_pos;

                distance = Vector3.Distance(transform.position, destination);
                if (distance <= 0.5)
                {
                    if (index < waypoints.Count - 1)
                        index++;

                    else
                        index = 0;
                }
            }
        }
        else if (chasing == true)
        {
            meshAgent.SetDestination(player.transform.position);
            onpath = false;
        }
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }

        if (canSeePlayer == true)
            chasing = true;
        else
            chasing = false;
    }
}