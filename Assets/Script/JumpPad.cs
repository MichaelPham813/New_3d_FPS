using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Rigidbody rb;
    public float multiplier;
    public float forceJump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("JumpTag"))
        {
            rb.AddForce(Vector3.up*forceJump);
        }
    }
}
