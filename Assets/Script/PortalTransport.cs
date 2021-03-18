using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{
    [SerializeField] private Transform telepoint;
    [SerializeField] private Transform player;
    private Rigidbody rb;
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = telepoint.transform.position;
        }
    }
}
