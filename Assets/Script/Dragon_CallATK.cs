using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_CallATK : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Jaw;
    public GameObject Tail;

    public GameObject SpawnPoint;
    public GameObject player;
    public GameObject Spell;

    public GameObject Shield;
    GameObject appearPoint;
    
    public void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void activateAtk()
    {
        Jaw.GetComponent<SphereCollider>().enabled = true;
        Tail.GetComponent<BoxCollider>().enabled = true;
    }

    public void deactivateAtk()
    {
        Jaw.GetComponent<SphereCollider>().enabled = false;
        Tail.GetComponent<BoxCollider>().enabled = false;
    
    }
    public float speed=10;
    public void FireBallShoot()
    {
        Vector3 v3 = (player.transform.position - SpawnPoint.transform.position);
        Rigidbody rb = Instantiate(Spell,SpawnPoint.transform.position,Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(v3*speed,ForceMode.Impulse);
    }

    public void activateShield(){
        Shield.SetActive(true);
    }

    public void deactivateShield(){
        Shield.SetActive(false);
    }
}
