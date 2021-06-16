using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject Ground;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
