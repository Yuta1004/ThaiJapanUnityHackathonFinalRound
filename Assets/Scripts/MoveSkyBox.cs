using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkyBox : MonoBehaviour {
	float _curRot = 0f;
	float rotSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		_curRot += rotSpeed * Time.deltaTime;
		_curRot %= 360f;
		RenderSettings.skybox.SetFloat("_Rotation", _curRot);
	}
}
