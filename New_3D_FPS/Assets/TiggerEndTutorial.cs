using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerEndTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public TutorialControl control; 
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == ("Player")){
            control.EndTutorial();
        }
    }
}
