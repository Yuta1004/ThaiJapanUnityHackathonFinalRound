using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public int player;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        player--;
	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(this.gameObject.transform.root.gameObject.transform.GetChild(0).gameObject.transform.position);
	}
}
