using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed = 10f;
    [Header("Unity References")]
    public string WaypointTag = "Waypoint";

    private Transform target;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        // Ignore y direction
        direction.Scale(new Vector3(1, 0, 1));
        transform.Translate(direction.normalized * (Speed * Time.deltaTime), Space.World);
    }

    public void ApplyDamage(int damage)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != WaypointTag)
        {
            return;
        }

        IncrementWaypointTarget();
    }

    private void IncrementWaypointTarget()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex += 1;
        target = Waypoints.points[waypointIndex];
    }
}
