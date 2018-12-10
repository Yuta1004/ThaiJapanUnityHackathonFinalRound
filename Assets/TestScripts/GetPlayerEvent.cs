using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerEvent : MonoBehaviour {

	private void OnCollisionStay(Collision collision){
        if(collision.gameObject.tag != "Soil"){
            return;
        }

        //Event発行
        if(Input.GetKeyDown(KeyCode.Space)){
            this.gameObject.GetComponent<PlayerEvent>().GetSpace(collision.gameObject);
        }
	}
}
