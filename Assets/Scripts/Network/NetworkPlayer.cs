using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    public static NetworkPlayer Local;

    private void Awake()
    {
        Local = this;
    }

    void Start()
    {
      
    }

   
    void Update()
    {
        
    }
}
