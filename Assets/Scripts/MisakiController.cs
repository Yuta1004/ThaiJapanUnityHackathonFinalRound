using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisakiController : MonoBehaviour {
	private Animator animator;
	private bool[] isPressing = {
		false, false, false, false
	};

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// 十字
		bool flag = false;
		if (Input.GetKey(KeyCode.UpArrow)) {
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			flag = true;
			isPressing[0] = true;
		} else {isPressing[0] = false; }

		if (Input.GetKey(KeyCode.DownArrow)) {
			gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
			flag = true;
			isPressing[2] = true;
		} else {isPressing[2] = false; }
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
			flag = true;
			isPressing[3] = true;
		} else {isPressing[3] = false; }
		
		if (Input.GetKey(KeyCode.RightArrow)) {
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
