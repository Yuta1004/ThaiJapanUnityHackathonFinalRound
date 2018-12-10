using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToSpaceShip : MonoBehaviour {
	private bool doDash = false;
	
	// Update is called once per frame
	void Update () {
		if(doDash) gameObject.transform.Translate(0, 0, 0.1f);
	}

	void SendMessage(string message) {
		doDash = true;
	}
	
	public void OnCallChangeFace(){}
}
