using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerEvent : MonoBehaviour {

    private string ObjectTag;
	private void OnCollisionStay(Collision collision){

        //Event発行
        ObjectTag = collision.gameObject.tag;
        if(ObjectTag == "Soil"){
            if (Input.GetKeyDown(KeyCode.Space)){
                this.gameObject.GetComponent<PlayerEvent>().GetSpace(collision.gameObject);
            }
        }else if(ObjectTag == "House"){
            if (Input.GetKeyDown(KeyCode.Space)){
                this.gameObject.GetComponent<HouseAttribute>().GetSpace(this.gameObject);
            }
        }
	}

	private void OnTriggerStay(Collider other){
		
	}
}
