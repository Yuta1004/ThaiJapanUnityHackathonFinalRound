using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLand : MonoBehaviour {

    public GameObject soil;
    public int landLength;
    private Vector3 InitPosition;
	void Start () {
        InitPosition = this.transform.position;
        for (int i = 0; i < landLength*landLength+1; i++){
            Instantiate(soil,
                        InitPosition,
                        this.transform.rotation);
            InitPosition = new Vector3(this.transform.position.x + (i%landLength)*3,
                                      0,
                                       this.transform.position.z - (i/landLength)*3);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
