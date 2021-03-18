using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    public GameObject WinUI;
    public MeleeEnemy melee;
    public FastEnemy fast;
    public GameObject player;
    private void Awake()
    {

        melee = GetComponent<MeleeEnemy>() ;
        fast = GetComponent<FastEnemy>();
    }
    // Update is called once per frame
    void Update()
    {
        float z = Mathf.PingPong(Time.time,1f);
        Vector3 axis = new Vector3(1,1,z);
        transform.Rotate(axis,1f);
    }

    private void OnTriggerEnter()
    {

        if(player.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
        WinUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //melee.DestroyEnemy();
        //fast.DestroyEnemy();
        }
    }
}
