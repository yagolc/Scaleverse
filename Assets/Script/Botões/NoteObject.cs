using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{   

    public GameObject MissEffect;

    public float beatTempo = 120f;

    public bool hasStarted;

    public bool canBePressed;

    public KeyCode keyToPress;
    
    void Start()
    {

    }

    
    void Update()
    {   
        
             transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);



        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                gameObject.SetActive(false);
                Destroy(gameObject);
                GameManager.instance.NoteHit();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (gameObject.active){
            if(other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();

                Instantiate(MissEffect, transform.position, MissEffect.transform.rotation);
            }
        }
    }
}
