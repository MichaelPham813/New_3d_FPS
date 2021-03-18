using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwap : MonoBehaviour
{
    [SerializeField] public GameObject pistol;
    [SerializeField] public GameObject rifle;
    [SerializeField] public GameObject bomber;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            bomber.gameObject.SetActive(true);
            pistol.gameObject.SetActive(false);
            rifle.gameObject.SetActive(false);
        }
        if(Input.GetKey(KeyCode.F))
        {
            bomber.gameObject.SetActive(false);
            pistol.gameObject.SetActive(true);
            rifle.gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.T))
        {
            bomber.gameObject.SetActive(false);
            pistol.gameObject.SetActive(false);
            rifle.gameObject.SetActive(true);
        }
    }
}
