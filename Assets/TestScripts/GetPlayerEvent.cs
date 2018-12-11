using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerEvent : MonoBehaviour {


	private void OnCollisionStay(Collision collision){

        //Event発行
        if(collision.gameObject.tag == "Soil"){
            if (Input.GetKeyDown(KeyCode.Space)){
                this.gameObject.GetComponent<PlayerEvent>().GetSpaceSoil(collision.gameObject);
                Debug.Log(collision.gameObject.GetComponent<SoilAttribute>().SoilNumber);
            }
        }
	}

	private void OnTriggerStay(Collider other){
        
        if (Input.GetKeyDown(KeyCode.Space)){
            if (other.gameObject.tag == "House"){
                if(this.gameObject.GetComponent<PlayerEvent>().isCanCleanse){
                    this.gameObject.GetComponent<PlayerEvent>().
                        GetElectr(other.gameObject.transform.root.gameObject.transform.GetChild(1).gameObject);
                }else{
                    other.gameObject.transform.root.gameObject.transform.GetChild(1).
                     GetComponent<HouseAttribute>().GetSpace(this.gameObject);
                }
            }else if(other.gameObject.tag == "Well"){
                this.gameObject.GetComponent<PlayerEvent>().GetSpaceWater();
            }
        }
	}
}
