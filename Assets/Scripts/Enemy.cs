using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;
    public string WaypointTag = "Waypoint";

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
        // Ignore y direction
        direction.Scale(new Vector3(1, 0, 1));
        transform.Translate(direction.normalized * (Speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != WaypointTag)
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
