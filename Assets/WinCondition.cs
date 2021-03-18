using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject WinUI;
    public TakeDamage bossHealth;
    private void Update()
    {
        if(bossHealth.health <= 0)
        {
            WinUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1f;
        }
    }
}
