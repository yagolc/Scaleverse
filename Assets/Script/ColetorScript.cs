using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetorScript : MonoBehaviour
{
    void  OnTriggerEnter2D(Collider2D target){
        if(target.tag =="Note"){
            Destroy(target.gameObject);
        }
    }
}
