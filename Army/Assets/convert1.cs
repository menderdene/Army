using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class convert1 : MonoBehaviour
{
    private GameObject[] targets;

    public Transform closestEnemy;

    public GameObject Player;

    public Camera cam;

    public float mSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");

        int numberOfTargets = targets.Length;

        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint;

        transform.LookAt(newPosition);
        transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
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
    Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < 1; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }

        return bounds.center;
    }
}
