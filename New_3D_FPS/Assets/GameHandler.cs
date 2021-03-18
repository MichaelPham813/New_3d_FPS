using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public TakeDamage takeDamage;
    public GameObject Player;


    private void Awake()
    {
        //takeDamage = GetComponent<TakeDamage>();
    }

    private void LateUpdate()
    {
        if(takeDamage.health < 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Destroy(Player);
    }
   




}
