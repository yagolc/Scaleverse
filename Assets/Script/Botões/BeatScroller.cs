using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{   

    public float beatTempo;

    public AudioSource audioSource;

    public float velocidade = 0.001f;
    public float DivisorVelociade = 10f;
    
    public bool hasStarted;
    void Start()
    {
        beatTempo = beatTempo / 60f;

        
        
    }

    
    void Update()
    {
        if(!hasStarted){
            if(Input.anyKeyDown){
                hasStarted = true;
            }
        }
         else{
            
            beatTempo += beatTempo * velocidade * Time.deltaTime;
            
            audioSource.pitch += audioSource.pitch * velocidade * Time.deltaTime / DivisorVelociade;

             transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }

        Debug.Log(transform.childCount);
        //Condição de fim de jogo
        /*if(transform.childCount == 0){
            
            EndGame();
        }*/

        
    }
    /*void EndGame(){
        audioSource.Stop();
    }*/
}
