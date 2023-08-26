using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private int CurrentWaypointIndex = 0;
    private void Update()
    {
        if (Vector2.Distance(waypoints[CurrentWaypointIndex].transform.position, transform.position) < .1f)
        {
            CurrentWaypointIndex++;
            if (CurrentWaypointIndex >= waypoints.Length)
            {
                CurrentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
