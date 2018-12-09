using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTitleButton : MonoBehaviour {

	public void OnClick() {
//		SceneManager.LoadScene("stage1");
	
		FadeManager mFadeManager = FadeManager.Instance;
		mFadeManager.LoadScene("Title", 2.0f);
	}
}
