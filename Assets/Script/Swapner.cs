using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapner : MonoBehaviour
{
    public GameObject NotaPrefab;
    private float position = 0;

    void Start()
    {
        StartCoroutine (SpawnNote());
    }

    IEnumerator SpawnNote(){
        yield return new WaitForSeconds (4);

        Instantiate (NotaPrefab , new Vector2(position, transform.position.y), 
            Quaternion.identity);
        
        StartCoroutine (SpawnNote());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
