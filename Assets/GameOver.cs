using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private float CountTime;
	// Use this for initialization
	void Start () {
        CountTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;
        Debug.Log(CountTime);
        
        if(CountTime > 60){
            Debug.Log("GAMEOVER");
        }
	}
}
