using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    private GameObject[] enemies;
    public Transform closestEnemy;
    public bool enemyContact;

    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    void Update()
    {
        closestEnemy = getClosestEnemy();
        closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0.7f, 0, 1);
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
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }
}
