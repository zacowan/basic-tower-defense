using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float Range = 15f;
    public float AttackSpeed = 1f;
    public int Damage = 1;
    public float TurnSpeed = 10f;
    [Header("Unity References")]
    public string EnemyTag = "Enemy";
    public Transform RotatePart;

    private Transform target;
    private float targetUpdateDeltaTimeSeconds = 0.1f;
    private float attackCountdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, targetUpdateDeltaTimeSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        RotateTowardTarget();

        if (attackCountdown <= 0f)
        {
            AttackTarget();
            attackCountdown = 1f * AttackSpeed;
        }

        attackCountdown -= Time.deltaTime;
    }

    private void AttackTarget()
    {
        var enemyObject = target.gameObject;
        Enemy enemy = enemyObject.GetComponent<Enemy>();

        enemy.ApplyDamage(Damage);
    }

    private void RotateTowardTarget()
    {
        // Find vector that points in direction of target
        var direction = target.position - transform.position;
        // Calculate the Quaternion needed to rotate in that direction
        var lookRotation = Quaternion.LookRotation(direction);
        // Get the euler angles for the Quaternion
        var rotation = Quaternion.Lerp(RotatePart.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        // Apply the rotation to the y-axis only
        RotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemyTransform = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= Range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemyTransform = enemy.transform;
                break;
            }
        }

        target = nearestEnemyTransform;
    }

    // Draws when selected in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
