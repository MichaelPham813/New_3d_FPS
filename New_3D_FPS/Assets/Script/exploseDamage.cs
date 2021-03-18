using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploseDamage : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Enemy"){
            other.gameObject.GetComponent<TakeDamage>().TakeDamages(damage);
        }
        if(other.gameObject.tag=="Boss_Dragon"){
            other.gameObject.GetComponent<TakeDamage>().TakeDamages(damage);
        }
    }
}
