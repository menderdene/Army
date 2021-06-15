using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private Vector3 offset;
    public GameObject master;
    public GameObject myTransform;


    // Start is called before the first frame update
    void Start()
    {
        offset = master.transform.position - myTransform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.transform.position = master.transform.position - offset;
    }
}
