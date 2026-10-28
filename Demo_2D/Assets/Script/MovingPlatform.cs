using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb; 
    private int direction = 1; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                direction = -1; 
            }
            else if (currentWaypointIndex == 0)
            {
                direction = 1; 
            }
            currentWaypointIndex += direction; 
        }
        Vector2 targetPos = waypoints[currentWaypointIndex].transform.position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, Time.fixedDeltaTime * speed);
        rb.MovePosition(newPos);
    }
}
