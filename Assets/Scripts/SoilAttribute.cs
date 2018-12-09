using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilAttribute : MonoBehaviour{

    public bool isTree;
    public int pollutionLevel;
    public int treeGrowth;
    public Material[] soilMaterials;

    /// <summary>
    /// treeGrowthとMaterialの関係
    ///     ~ 20  
    ///  21 ~ 50
    ///  51 ~ 80
    ///  81 ~ 
    /// </summary>
    void Start(){
        //init attribute
        isTree = false;
        pollutionLevel = Random.Range(0, 100);
        treeGrowth = 0;
    }

    void PlantTree(){
        isTree = true;
        treeGrowth = 0;
    }

    void PollutionErosion(int degreeOfErosion){
        pollutionLevel += degreeOfErosion;
    }

    void SoilUpdate(){
        
    }
}
