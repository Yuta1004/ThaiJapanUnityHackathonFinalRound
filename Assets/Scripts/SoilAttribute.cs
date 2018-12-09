using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilAttribute : MonoBehaviour{

    public bool isTree;
    public int pollutionLevel;
    public int treeGrowth;

    private void Start(){
        //init attribute
        isTree = false;
        pollutionLevel = Random.Range(0, 50)+20;
        treeGrowth = 0;
    }

    public void PlantTree(){
        isTree = true;
        treeGrowth = 0;
    }

    public void PollutionErosion(int degreeOfErosion){
        pollutionLevel = Mathf.Max(degreeOfErosion+pollutionLevel, 100);
    }

    //private void SoilUpdate(){
    //}
}
