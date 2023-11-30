using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEsquerda : MonoBehaviour
{   
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
     public GameObject Note;
    void Start(){
        theSR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(keyToPress)){
            theSR.sprite = pressedImage;
        }
        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }

        
    }
}
