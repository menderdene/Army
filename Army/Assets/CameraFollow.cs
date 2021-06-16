using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject[] targets;

    public Transform closestTarget;

    public Vector3 offset;

    public Camera cam;

    private void LateUpdate()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");

        int numberOfTargets = targets.Length;

        transform.position = closestTarget.position + offset;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 40f + Mathf.Log(numberOfTargets,1.2f), Time.deltaTime);
    }
}
