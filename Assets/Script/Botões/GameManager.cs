using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;

    public int socrePerNote = 10;
    public float totalNotes;

    public float HitNotes;

    public float missedHits;
    public int currentMultiplier;
    public int multplierTracker;
    public int[] multiplierThresholds;
    public Text scoreText;
    public Text multText;

    public GameObject GameStart;
    public GameObject resultsScreen;
    public Text percentHitText, HitText, missesText, rankText;

    

    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    
    void Update()
    {
        if(!startPlaying){
            if(Input.anyKeyDown){
                startPlaying = true;
                theBS.hasStarted = true;
                GameStart.SetActive(false);
                
                theMusic.Play();
            }
        }else{
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy){
                resultsScreen.SetActive(true);
                HitText.text = "" + HitNotes;
                missesText.text = "" + missedHits;
            }
        }
        
    }

    public void NoteHit(){
        Debug.Log("Acertou");

        if(currentMultiplier - 1 < multiplierThresholds.Length){
            multplierTracker ++;

            if(multiplierThresholds[currentMultiplier - 1] <= multplierTracker){
                multplierTracker = 0;
                currentMultiplier ++;
            }
        }

        multText.text = "Multiplier: x" + currentMultiplier;

        currentScore += socrePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        
        HitNotes++;
    }


    public void NoteMissed(){

        Debug.Log("Errou");

        currentMultiplier = 1;
        multplierTracker = 0;

        multText.text = "Multiplier: x" + currentMultiplier;

        missedHits ++;
    }

    public void RestartGame(string cena){
        Debug.Log("Reiniciou");
        SceneManager.LoadScene(cena);
    }
}
