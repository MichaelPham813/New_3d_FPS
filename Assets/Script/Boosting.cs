using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosting : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Transform orientation;
    [SerializeField] private float boostingForce = 65f;
    private Rigidbody rb;
    public float multiplier = 1.5f;
    private PlayerMovement move;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
        move = movement.GetComponent<PlayerMovement>();
        
    }


    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Rigidbody>()!=null)
        {
            rb.AddForce(Vector3.down*2000f*multiplier);
            rb.AddForce(orientation.forward*boostingForce*move.slidingForce*multiplier*Time.deltaTime);
        }
    }
}
