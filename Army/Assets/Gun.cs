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
    public float MobDistance = 6.0f;
    public float fireRate = 1f;

    public float nextTimeToFire = 1f;

    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(closestEnemy = getClosestEnemy())
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

    public Transform getClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = 10.0f;
        Transform trans = null;

        foreach (GameObject go in enemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }
}
