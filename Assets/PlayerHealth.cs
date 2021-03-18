using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth:MonoBehaviour
{
    public TakeDamage takeDamage;
    public GameObject Player;


    public void Awake()
    {
        takeDamage = GetComponent<TakeDamage>();
    }
    
    public void KillPlayer()
    {
        Destroy(gameObject,1f);
    }

   
}