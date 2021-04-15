using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImeTrigger : MonoBehaviour
{
    public TimeStop timeStop;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            timeStop.StopTime();
            Destroy(gameObject);
        }
    }
}
