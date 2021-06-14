using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joy : MonoBehaviour
{
    public FloatingJoystick moveJoystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        transform.Translate(direction * 0.08f, Space.World);
    }
}
