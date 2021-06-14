using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public Rigidbody projectileprefab;
    public float launchforce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LaunchProjectile();
        }
    }

    private void LaunchProjectile()
    {
        var ProjectileInstances = Instantiate(projectileprefab, firepoint.position, firepoint.rotation);

        ProjectileInstances.AddForce(firepoint.forward * launchforce);
    }
}
