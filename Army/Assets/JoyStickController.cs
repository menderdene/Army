using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JoyStickController : MonoBehaviour
{
    public FloatingJoystick moveJoystick;

    private NavMeshAgent Mob;

    public GameObject Player;

    private GameObject[] enemies;

    public Transform closestEnemy;

    public float MobDistance = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        closestEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;

        Player = GameObject.Find("Target");

        closestEnemy = getClosestEnemy();

        float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);

        if (distance < MobDistance)
        {
            transform.LookAt(closestEnemy.transform);

            Vector3 direction = new Vector3(hoz, 0, ver).normalized;
            transform.Translate(direction * 0.08f, Space.World);
        }

        else
        {
            Vector3 direction = new Vector3(hoz, 0, ver).normalized;
            transform.Translate(direction * 0.08f, Space.World);
            Vector3 lookAtPosition = transform.position + direction;
            transform.LookAt(lookAtPosition);
        }
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
