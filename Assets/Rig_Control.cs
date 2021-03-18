using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations.Rigging;
using UnityEngine;

public class Rig_Control : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    float rig_Weight;
    [SerializeField] Rig rig = null;
    private void Awake() {
        anim = gameObject.GetComponentInParent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("IsSleep") || anim.GetBool("Defend")){
            rig_Weight=0;
        }
        else rig_Weight=1;

        rig.weight = rig_Weight;
    }
}
