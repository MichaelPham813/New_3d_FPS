using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject player;    

    private IPortal portalStuff;
    private Rigidbody rb;
    private void Awake(){
        portalStuff = portal.GetComponent<IPortal>();
        rb=player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Rigidbody>()!=null)
        {
            portalStuff.OpenPortal();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<Rigidbody>()!=null)
        {
            portalStuff.ClosePortal();
        }
    }
}
