using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    //Assignable
    [Header("Assignable")]
    public IdentifyHook identifyHook;
    private Vector3 GrapplePoint;
    public LayerMask whatIsGrappleable;

    [Header("Assignable")]
    public Transform lineTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    private float Radius = 3f;
    


    public bool isGrappling=false;


    // Update input để đu dây
    void Update()
    {
       if(Input.GetMouseButtonDown(1))
       {
           if(identifyHook.found)
            {
                StartGrapple();
            }
       } 
       else if(Input.GetMouseButtonUp(1))
       {
                Destroy(player.gameObject.GetComponent<SpringJoint>());//thêm vào vì đôi khi tap con chuột thay vì giữ sẽ tạo thêm spring joint note:tap lại nhiều lần để xóa spring joint thừa
                StopGrapple();
            
       }
        else if(Input.GetMouseButton(1)){
            if(!joint) return;
            float distanceFromPoint = Vector3.Distance(player.position,GrapplePoint);
            

            joint.maxDistance = distanceFromPoint*0.7f;
            joint.minDistance= distanceFromPoint*0.1f;

        }
       
    }




    //Vẽ dây và đồng thời cho nhân vật đu dây dc nhờ spring joint
   public void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.SphereCast(camera.position,Radius,camera.forward,out hit,maxDistance,whatIsGrappleable))
        {
            GrapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = GrapplePoint;
            float distanceFromPoint = Vector3.Distance(player.position,GrapplePoint);

            joint.maxDistance = distanceFromPoint*0.8f;
            joint.minDistance= distanceFromPoint*0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;


        }
        GrapplePoint = identifyHook.attachPoint;
        isGrappling= true;
        
    }

    //ngưng đu dây xóa spring joint và điểm của line renderer
    public void StopGrapple()
    {
            Destroy(joint);
            isGrappling = false;
    }



    //điều kiện đang đu dây
    public bool IsGrappling()
    {
        return joint != null;
    }


    //lấy điểm để có đu được
    public Vector3 GetGrapplePoint()
    {
        return GrapplePoint;
    }

    

}
