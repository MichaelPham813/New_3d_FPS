using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : MonoBehaviour
{
    // Start is called before the first frame update
    public int handgunCount,rifleCount,bomberCount;
    public GameObject handgun,rifle,bomber;

    private void Awake() {
        // handgunCount=0;
        // rifleCount=0;
        // bomberCount=0;
    }
    // Update is called once per frame
    void Update()
    {
        MyInput();
    }
    private void MyInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1) &&handgunCount>=1){
            SwitchHandgun();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) &&rifleCount>=1){
            SwitchRifle();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) &&bomberCount>=1){
            SwitchBomber();
        }
    }

    [Obsolete]
    private void SwitchBomber()
    {
        handgun.active =false;
        rifle.active = false;
        bomber.active = true;
    }
    [Obsolete]
    private void SwitchRifle()
    {
        handgun.active =false;
        rifle.active = true;
        bomber.active = false;
        
    }
    [Obsolete]
    private void SwitchHandgun()
    {
        handgun.active =true;
        rifle.active = false;
        bomber.active = false;
    }
}
