using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TakeDamage : MonoBehaviour
{
    public float health, maxHealth;
    public int timeAfterDead;  
    public Canvas canvas;
    public Image healthbar;  
    public bool isImmuDamage;
    private void Awake() {
        health = maxHealth;
        isImmuDamage=false;
        health = Mathf.Clamp(health,0,350);
    }
    private void Update() {
        if(!gameObject.tag.Equals("Player"))
            canvas.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        if(health <= 0 )  {
            
            if(gameObject.tag.Equals("Enemy")){
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }            
            if(gameObject.tag.Equals("Boss_Dragon")){
                gameObject.GetComponent<Animator>().SetTrigger("Die");
            }
        } 
        HealthBarControl();
     }

    public void TakeDamages(float damage){
        if(!isImmuDamage)
            health -= damage;
    }
    private void HealthBarControl(){
        healthbar.fillAmount = (maxHealth - health) / maxHealth;
    }

    private void OnCollisionEnter(Collision other) {
        
    }
}