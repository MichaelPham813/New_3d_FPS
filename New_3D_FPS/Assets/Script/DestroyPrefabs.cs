using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
    public float timeDisappear = 12.5f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,timeDisappear);
    }
}
