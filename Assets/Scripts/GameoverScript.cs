using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverScript : MonoBehaviour {
    public static int score = 0;

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Text>().text = "Score : " + score.ToString();//UIのテキストの取得の仕方
	}
}
