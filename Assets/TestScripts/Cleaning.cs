using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour {


    public int totralClean;

    private int index;
	void Start () {
        Invoke("DestroyCleanre", 3);
	}

    public void ReceiveIndex(int Index){
        index = Index;
    }

    private void DestroyCleanre(){
        this.gameObject.transform.root.GetComponent<MakeLand>().DestroyCleanre(index, totralClean);
        Destroy(this.gameObject);
    }
}
