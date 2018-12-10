using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceShit : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(0, 0, -4.0f);
	}
}
