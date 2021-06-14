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
    public bool enemyContact;
    public float MobDistance = 4.0f;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = getClosestEnemy();

        float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);

        if (distance < MobDistance && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            LaunchProjectile();
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
        float closestDistance = Mathf.Infinity;
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
