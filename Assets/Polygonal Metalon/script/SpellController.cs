using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public float lifeTime;
    public GameObject explosion;
    public float damage;
    private void Awake() {
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime>0){
            lifeTime-=Time.deltaTime;
        }
        else{
            enabled=false;
            Destroy(gameObject,0.5f);    
        }
    }
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject,0.1f);
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<TakeDamage>().TakeDamages(damage);
            Explosion();
        }
        else if(other.gameObject.name == "Ground")
        {
            Explosion();
        }
    }
    private void Explosion(){
        Instantiate(explosion,transform.position,Quaternion.identity);
    }
}
