﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "BG"  
            || target.tag == "Platform"
            || target.tag == "ExtraPush" 
            || target.tag == "NormalPush" 
            || target.tag == "Bird") {


            target.gameObject.SetActive(false);

            
        }

    }

}
