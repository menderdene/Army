using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraFollow : MonoBehaviour
{
    private GameObject[] targets;

    public Vector3 offset;

    public Camera cam;

    private void LateUpdate()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");

        int numberOfTargets = targets.Length;

        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 40f + Mathf.Log(numberOfTargets,1.2f), Time.deltaTime);
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
