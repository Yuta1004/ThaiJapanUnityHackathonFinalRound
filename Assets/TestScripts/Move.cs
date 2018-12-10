using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 Axis;

    void Start () {
        rb = GetComponent<Rigidbody>();
        Axis.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Axis.x = Input.GetAxis("Horizontal")*10;
        Axis.z = Input.GetAxis("Vertical")*10;
        rb.velocity = Axis;
	}
}
