using UnityEngine;
 using System.Collections;
 
 public class Player_Movement_2 : MonoBehaviour {
     public float moveSpeed;
     private float maxSpeed = 5f;
     private Vector3 input;
 
     void Start () {
         
     }
 
     void Update () {
         input = new Vector3 (Input.GetAxis ("Horizontal_2"), 0, Input.GetAxis ("Vertical_2"));
         if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) {
             GetComponent<Rigidbody>().AddForce (input * moveSpeed);
         }
         if (Input.GetKeyDown(KeyCode.LeftShift)) {
             //I want to shoot
         }
     
         print (input);
     }
 }