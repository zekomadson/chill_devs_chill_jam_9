using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    public Transform[] waypoints;
    private int destinationPoint;
    private float closeToWaypointDist;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destinationPoint = 0;
        closeToWaypointDist = 1f;

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("You must setup at least one waypoint for the navigation agent");
            enabled = false;
            return;
        }

        int newDestinationPoint = destinationPoint;
        while (newDestinationPoint == destinationPoint)
        {
            newDestinationPoint = Random.Range(0, waypoints.Length);
        }
        
        destinationPoint = newDestinationPoint;
        agent.destination = waypoints[destinationPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!agent.pathPending && agent.remainingDistance < closeToWaypointDist)
        {
            GoToNextPoint();
        }
        
    }
}
