using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[wavepointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Waypoint")
        {
            return;
        }

        IncrementWaypointTarget();
    }

    void IncrementWaypointTarget()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex += 1;
        target = Waypoints.points[wavepointIndex];
    }
}
