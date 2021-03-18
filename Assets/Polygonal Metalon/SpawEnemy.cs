
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy;
    public int soluong;
    private IEnumerator cour;
    private void Awake() {
        int count=0;
        while(count<soluong){
            cour = SpawOne();
            StartCoroutine(cour);
            count++;
            //Debug.Log("vv");
        }
    }

    private IEnumerator SpawOne()
    {
        //Debug.Log("...");
        int randX = Random.Range(-200, 100);
        int randZ = Random.Range(-200, 100);
        Vector3 spawPoint = gameObject.transform.position;
        spawPoint.x+=randX;
        spawPoint.z+=randZ;
        Instantiate(enemy[Random.Range(0,enemy.Length)], spawPoint,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
    }
}
