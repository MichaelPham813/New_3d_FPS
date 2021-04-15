using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public float TimeBeforeAffected;
    public TimeStop ts;
    private Rigidbody rb;
    private Vector3 recordedVelocity;
    private float recordedMagnitude;

    private float TimeBeforeAffectedTimer;
    private bool CanBeAffected;
    private bool IsStopped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
       
        TimeBeforeAffectedTimer = TimeBeforeAffected;
    }

    private void Update()
    {
        TimeBeforeAffectedTimer -= Time.deltaTime;
        if(TimeBeforeAffectedTimer<=0)
        {
            CanBeAffected = true;
        }

        if(CanBeAffected && ts.TimeStopped && !IsStopped)
        {
            if (rb.velocity.magnitude >= 0f)
            {
                recordedVelocity = rb.velocity.normalized;
                recordedMagnitude = rb.velocity.magnitude;

                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                IsStopped = true;
            }
        }
    }

    public void ContinueTime()
    {
        rb.isKinematic = false;
        IsStopped = false;
        rb.velocity = recordedVelocity * recordedMagnitude;
    }
}
