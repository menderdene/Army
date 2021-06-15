using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class convert1 : MonoBehaviour
{
    private GameObject[] enemies;

    public Transform closestEnemy;

    public GameObject Player;

    public float mSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = getClosestEnemy();

        transform.LookAt(closestEnemy.position);
        transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
    }
    public Transform getClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject e = Instantiate(Player) as GameObject;
            e.transform.position = transform.position;
        }
    }
}
