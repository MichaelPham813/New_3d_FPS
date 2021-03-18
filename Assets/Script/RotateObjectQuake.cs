using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectQuake : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.PingPong(Time.time,1);
        Vector3 axis = new Vector3(0,y,0);
        transform.Rotate(axis,1f);
    }
}
