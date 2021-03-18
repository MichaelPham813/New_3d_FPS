using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(3, 100)]
	[Tooltip("After how long time should the bullet prefab be destroyed?")]
	public float destroyAfter;
	[Tooltip("If enabled the bullet destroys on impact")]
	public Transform impactPrefabs;

    public float damage;
    // Start is called before the first frame update
    private void Awake() {
        Destroy(gameObject,destroyAfter*Time.timeScale);
    }


	private void OnCollisionEnter(Collision other) {
		//Debug.Log("vvv");
		if(other.gameObject.layer == 12){
			return;
		}
		if (other.transform.tag == "Enemy" || other.gameObject.tag=="Boss_Dragon") 
		{
			//Toggle "isHit" on target object
			other.transform.gameObject.GetComponent<TakeDamage>().TakeDamages(damage);
			Destroy(gameObject,0.01f);
		}
		
		//Debug.Log(other.gameObject.tag.ToString());
		Destroy(gameObject,0.01f);
		Instantiate (impactPrefabs, transform.position,Quaternion.LookRotation (other.contacts [0].normal));
	}
	// private void OnTriggerEnter(Collider collision) {
		
	// 	if (collision.transform.tag == "Enemy") 
	// 	{
	// 		//Toggle "isHit" on target object
	// 		collision.transform.gameObject.GetComponent
	// 			<TakeDamage>().health -= damage;
            
	// 	}
		
	// 	Instantiate (impactPrefabs, transform.position, Quaternion.identity);
	// 	Destroy(gameObject);
	// }

}
