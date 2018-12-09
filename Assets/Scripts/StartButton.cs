using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public void OnClick() {
//		SceneManager.LoadScene("stage1");
	
		FadeManager mFadeManager = FadeManager.Instance;
		mFadeManager.LoadScene("main", 2.0f);
	}
}
