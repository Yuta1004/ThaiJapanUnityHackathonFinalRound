using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAttribute : MonoBehaviour {

    public int electricQuantity;
    public int getElectric;

    public void GetSpace(GameObject Player){
        int getTree = Player.GetComponent<PlayerEvent>().passTree();
        electricQuantity += getTree * getElectric;
        Debug.Log(electricQuantity);
    }
}
