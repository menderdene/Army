using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    private GameObject[] enemies;

    public Transform closestEnemy;

    public float MobDistance = 12.0f;

    public FloatingJoystick moveJoystick;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = 15.0f;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= MobDistance)
        {
            closestEnemy = nearestEnemy.transform;
        }
        else
        {
            closestEnemy = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;

        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        transform.Translate(direction * 0.08f, Space.World);

        Vector3 lookAtPosition = transform.position + direction;

        transform.LookAt(lookAtPosition);

        if (closestEnemy == null)
            return;

        transform.LookAt(closestEnemy);
    }
}