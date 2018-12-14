using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public float CountTime;
    private int Electr;
    private bool isLoaded = false;
	// Use this for initialization
	void Start () {
        CountTime = 0;
        Electr = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;
        //Debug.Log(CountTime);
        
        if(CountTime > 60){
            Electr = this.gameObject.GetComponent<HouseAttribute>().electricQuantity;
            if(!isLoaded){
                FadeManager mFadeManager = FadeManager.Instance;
                mFadeManager.LoadScene("GameOver", 1f);
                isLoaded = true;
	            GameoverScript.score = Electr;
            }
            Debug.Log("GAMEOVER");
        }
	}
}
