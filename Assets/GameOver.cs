using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private float CountTime;
    private int Electr;
	// Use this for initialization
	void Start () {
        CountTime = 0;
        Electr = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;
        Debug.Log(CountTime);
        
        if(CountTime > 60){
            Electr = this.gameObject.GetComponent<HouseAttribute>().electricQuantity;
            Debug.Log("GAMEOVER");
        }
	}
}
