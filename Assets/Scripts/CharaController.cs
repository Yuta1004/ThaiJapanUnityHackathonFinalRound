using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour {
	public string keySetup = "";
	
	private Animator animator;
	private bool[] isPressing = {
		false, false, false, false
	};
	private KeyCode[][] keys = new KeyCode[][]{
		new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D }, 
		new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow}
	};
	private int keySetupInt;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		if (keySetup == "WASD") keySetupInt = 0;
		else keySetupInt = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// 十字
		bool flag = false;
		if (Input.GetKey(keys[keySetupInt][0])) {
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			flag = true;
			isPressing[0] = true;
		} else {isPressing[0] = false; }

		if (Input.GetKey(keys[keySetupInt][1])) {
			gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
			flag = true;
			isPressing[2] = true;
		} else {isPressing[2] = false; }
		
		if (Input.GetKey(keys[keySetupInt][2])) {
			gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
			flag = true;
			isPressing[3] = true;
		} else {isPressing[3] = false; }
		
		if (Input.GetKey(keys[keySetupInt][3])) {
			gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
			flag = true;
			isPressing[1] = true;
		} else {isPressing[1] = false; }

		// 斜め
		if (isPressing[0] && isPressing[1]) {
			gameObject.transform.rotation = Quaternion.Euler(0, 45, 0);
			flag = true;
		}else if (isPressing[1] && isPressing[2]) {
			gameObject.transform.rotation = Quaternion.Euler(0, 135, 0);
			flag = true;
		}else if (isPressing[2] && isPressing[3]) {
			gameObject.transform.rotation = Quaternion.Euler(0, 225, 0);
			flag = true;
		}else if (isPressing[3] && isPressing[0]) {
			gameObject.transform.rotation = Quaternion.Euler(0, 315, 0);
			flag = true;
		}

		animator.SetBool("isRunning", flag);
		if(flag) gameObject.transform.Translate(0, 0, 0.05f);
	}
	
	public void OnCallChangeFace(){}
}
