using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private NavMeshAgent Mob;

    public GameObject Player;

    private GameObject[] enemies;

    public Transform closestEnemy;

    public float MobDistance = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        closestEnemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Target");

        closestEnemy = getClosestEnemy();

        float distance = Vector3.Distance(transform.position, closestEnemy.transform.position);

        if(distance < MobDistance)
        {
            transform.LookAt(closestEnemy.transform);

            Mob.SetDestination(Player.transform.position);
        }

        else
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            Mob.SetDestination(newPos);
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
