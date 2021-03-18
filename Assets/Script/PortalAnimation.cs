﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimation : MonoBehaviour,IPortal
{
   private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenPortal()
    {
        animator.SetBool("Open",true);

    }
    public void ClosePortal()
    {
        animator.SetBool("Open",false);

    }

}
