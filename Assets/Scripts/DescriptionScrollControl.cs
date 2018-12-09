using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionScrollControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ScrollRect>().horizontalNormalizedPosition = 0.0f;
	}
}
