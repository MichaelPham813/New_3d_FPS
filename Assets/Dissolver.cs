using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    [SerializeField] private Material mat;
    private float dissolveSpeed = 1f;
    private bool isDissolving=false;

    private void Update()
    {
       if(isDissolving)
        {
            mat.SetFloat("_NoiseRate", Mathf.MoveTowards(mat.GetFloat("_NoiseRate"),1.25f,dissolveSpeed*Time.deltaTime));
        }
        else
        {
            mat.SetFloat("_NoiseRate", Mathf.MoveTowards(mat.GetFloat("_NoiseRate"), -1.25f, dissolveSpeed * Time.deltaTime));
        }

    }
    public void StartDissolve(float dissolveSpeed)
    {
        isDissolving = true;
        this.dissolveSpeed = dissolveSpeed;
    }
    public void StopDissolve(float dissolveSpeed)
    {
        isDissolving = false;
        this.dissolveSpeed = dissolveSpeed;
    }

}
