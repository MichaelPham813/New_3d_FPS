using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentifyHook : MonoBehaviour
{
    //Assignable
    [Header("Assignable")]
    GameObject player;

    RaycastHit sphereCastInfo;
    [HideInInspector] public bool found;
    [Header("Distance")]
    public float maxDistance = 80f;

    [HideInInspector] public Vector3 attachPoint;

    [Header("Assignable")]
    public Image attachPointCrosshair;
    public RectTransform canvasRect;
    public GameObject Grappler; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player = GameObject.FindWithTag("Player");
        attachPointCrosshair.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sphereCastOrigin = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        bool hitSomething = Physics.SphereCast(sphereCastOrigin,4.5f,transform.forward,out sphereCastInfo,maxDistance);
        if(hitSomething && sphereCastInfo.collider.tag=="Ground" && Vector3.Distance(player.transform.position, sphereCastInfo.point) > 5f)
        {
            found = true;
            attachPointCrosshair.gameObject.SetActive(true);
            attachPoint = sphereCastInfo.point;
            attachPointCrosshair.transform.position = Camera.main.WorldToScreenPoint(attachPoint);
            if(!Grappler.GetComponent<Grappling>().isGrappling)
                Grappler.transform.LookAt(attachPoint);
        }
        else
        {
            found = false;
            attachPointCrosshair.gameObject.SetActive(false);
        }
    }
}
