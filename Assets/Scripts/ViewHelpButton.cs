using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHelpButton : MonoBehaviour {

	public void OnClick() {
//		SceneManager.LoadScene("stage1");
	
		FadeManager mFadeManager = FadeManager.Instance;
		mFadeManager.LoadScene("help", 2.0f);
	}
}
