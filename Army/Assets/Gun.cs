using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public Rigidbody projectileprefab;
    public float launchforce = 1000f;
    private GameObject[] enemies;
    public Transform closestEnemy;
    public float MobDistance = 12.0f;
    public float fireRate = 1f;

    public float nextTimeToFire = 1f;

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
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= MobDistance)
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
        if(closestEnemy != null)
        {
            float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);

            if (distance < MobDistance && nextTimeToFire <= 0f)
            {
                nextTimeToFire = 1.0f;
                nextTimeToFire = 1f / fireRate;
                LaunchProjectile();
            }

            nextTimeToFire -= Time.deltaTime;
        }
    }

    private void LaunchProjectile()
    {
        var ProjectileInstances = Instantiate(projectileprefab, firepoint.position, firepoint.rotation);

        ProjectileInstances.AddForce(firepoint.forward * launchforce);
    }
}