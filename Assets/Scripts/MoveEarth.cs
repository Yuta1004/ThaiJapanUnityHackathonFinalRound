﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEarth : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(0, 1f, 0);
	}
}
