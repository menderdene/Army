using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convert : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            GameObject e = Instantiate(Player) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if(other.gameObject.name == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
