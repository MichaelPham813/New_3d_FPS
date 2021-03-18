using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {

	private void Awake() {
        Destroy(gameObject,2*Time.timeScale);
    } 
}
