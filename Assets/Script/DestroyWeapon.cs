using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
    public TakeDamage takeDamage;

    void Awake()
    {
        takeDamage = GetComponent<TakeDamage>();
    }
    // Update is called once per frame
    void Update()
    {
        if(takeDamage.health <=0)
        {
            
        }
    }
}
