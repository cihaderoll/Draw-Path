﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour
{
    public GameObject star;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.tag == "star")
        {
            oyunKontrol.instantiate.starCollected = true;
            Destroy(star);
        }
        
    }
}
