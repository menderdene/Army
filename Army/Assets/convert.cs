using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convert : MonoBehaviour
{
    public GameObject ghost;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameObject e = Instantiate(ghost) as GameObject;
            e.transform.position = transform.position;
        }

        if(other.gameObject.name == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
