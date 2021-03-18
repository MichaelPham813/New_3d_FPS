using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject deletePoint;
    public GameObject objectToDel;
    public GameObject StandPoint;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == deletePoint)
            
            Destroy(objectToDel,1f);
            enabled=true;
    }
}
