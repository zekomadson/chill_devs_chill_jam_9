using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    private Transform[] waypoints;
    private int destinationPoint;
    private float closeToWaypointDist;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destinationPoint = 0;
        closeToWaypointDist = 4f;
        string tag = gameObject.tag;
        waypoints = GetWaypoints(tag);

        if (waypoints != null && waypoints.Length > 0)
        {
            GoToNextPoint();
        }
        else
        {
            Debug.LogError("No waypoints found. Make sure there are game objects tagged with '" + tag + "_waypoint'.");
        }
    }

    private Transform[] GetWaypoints(string tag)
    {
        string waypointTag = tag + "_waypoint";
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        Transform[] beacons = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            beacons[i] = waypointObjects[i].transform;
        }

        return beacons;
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
