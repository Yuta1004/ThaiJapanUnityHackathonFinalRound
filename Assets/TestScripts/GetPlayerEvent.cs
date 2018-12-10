using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerEvent : MonoBehaviour {
    
	private void OnCollisionStay(Collision collision){

        //Event発行
        if(collision.gameObject.tag == "Soil"){
            if (Input.GetKeyDown(KeyCode.Space)){
                this.gameObject.GetComponent<PlayerEvent>().GetSpace(collision.gameObject);
            }
        }
	}

	private void OnTriggerStay(Collider other){
        
        if (Input.GetKeyDown(KeyCode.Space)){
            if (other.gameObject.tag == "House"){
                //Debug.Log(other.gameObject.transform.root.gameObject.transform.GetChild(1).gameObject.name);
                other.gameObject.transform.root.gameObject.transform.GetChild(1).GetComponent<HouseAttribute>().GetSpace(this.gameObject);
            }
        }
		
	}
}
