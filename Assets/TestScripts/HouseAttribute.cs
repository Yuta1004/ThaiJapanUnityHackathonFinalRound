using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAttribute : MonoBehaviour {

    public int electricQuantity;
    public int getElectric;
    public int MaxGive;

    public void GetSpace(GameObject Player){
        int getTree = Player.GetComponent<PlayerEvent>().passTree();
        electricQuantity += getTree * getElectric;
    }

    public int GiveElectr(int nowElectr){
        electricQuantity = electricQuantity - (MaxGive - nowElectr);
        return MaxGive;
    }
}
