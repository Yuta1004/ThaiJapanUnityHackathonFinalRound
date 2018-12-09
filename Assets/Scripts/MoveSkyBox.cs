using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

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

