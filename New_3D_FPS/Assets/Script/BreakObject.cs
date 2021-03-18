using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public GameObject breakable;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(breakable, transform.position, breakable.transform.rotation);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(breakable, transform.position, breakable.transform.rotation);
        Destroy(this.gameObject);
    }
}
