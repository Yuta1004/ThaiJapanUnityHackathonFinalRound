using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSceneManage : MonoBehaviour {
	void Start () {
		Invoke("goGame", 5.0f);
	}
	
	void goGame () {
		FadeManager mFadeManager = FadeManager.Instance;
		mFadeManager.LoadScene("main", 2.0f);
	}
}
