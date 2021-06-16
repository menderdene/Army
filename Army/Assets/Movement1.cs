using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    private GameObject[] enemies;

    public Transform closestEnemy;

    public float MobDistance = 6.0f;

    public FloatingJoystick moveJoystick;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if(closestEnemy = getClosestEnemy())
        {
            float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);

            if (distance < MobDistance)
            {
                transform.LookAt(closestEnemy.transform);
            }
        }
    }
    public Transform getClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = 10f;
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