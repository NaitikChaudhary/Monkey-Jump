using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target) {
        print("bird collector - "+target.tag);
        if(target.tag == "Bird") {
           target.gameObject.SetActive(false);
        }
    }
}
