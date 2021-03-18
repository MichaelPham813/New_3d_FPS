using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingRope : MonoBehaviour
{
    private Spring spring;
    private Vector3 currentGrapplePosition;
    private LineRenderer lr;
    public Grappling grapplingGun;
    public int quality ;//quality 1 = worst ; 3 = best
    public float damper;
    public float strength;
    public float velocity;
    public float waveCount;
    public float waveHeight;
    public AnimationCurve affectCurve;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        spring = new Spring();
        spring.SetTarget(0);
    }

    //Vẽ dây cho mọi frame 
    void LateUpdate()
    {
        DrawRope();

    }

    //vẽ dây
    void DrawRope()
    {
        if (!grapplingGun.IsGrappling())
        {
            currentGrapplePosition = grapplingGun.lineTip.position;
            spring.Reset();
            if(lr.positionCount>0)
            {
                lr.positionCount = 0;
            }
            return;
        }
        if(lr.positionCount==0)
        {
            spring.SetVelocity (velocity);
            lr.positionCount = quality + 1;
        }
        spring.SetDamper (damper);
        spring.SetStrength(strength);
        spring.Update(Time.deltaTime);

        var grapplePoint = grapplingGun.GetGrapplePoint();
        var gunTipPosition = grapplingGun.lineTip.position;
        var up = Quaternion.LookRotation((grapplePoint - gunTipPosition).normalized)*Vector3.up;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 12f);

        for(int i = 0;i<quality+1;i++)
        {
            var delta = i/(float)quality;
            var offset = up * waveHeight*Mathf.Sin(delta*waveCount*Mathf.PI*spring.Value*affectCurve.Evaluate(delta));
            lr.SetPosition(i,Vector3.Lerp(gunTipPosition,currentGrapplePosition,delta)+offset);

        }

    }
}
