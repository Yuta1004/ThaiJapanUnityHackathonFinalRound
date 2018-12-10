using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilAttribute : MonoBehaviour{

    public bool isTree;
    public int pollutionLevel;
    public int treeGrowth;
    public int SoilNumber;

    private int GrowthPoint;
    private bool isSeedling;
    private bool isYangeTree;
    private bool isLargeTree;

    public void init(int index){
        //init attribute
        isTree = false;
        pollutionLevel = Random.Range(0, 50)+20;
        treeGrowth = 0;
        isSeedling = false;
        isYangeTree = false;
        isLargeTree = false;
        SoilNumber = index;
    }

    public void PlantTree(int getTreeGrowth){
        isTree = true;
        treeGrowth = getTreeGrowth;
        if (treeGrowth <= 100){
            isSeedling = true;
        }else if (treeGrowth <= 199){
            isYangeTree = true;
        }else{
            isLargeTree = true;
        }
    }

    public void CutTree(){
        isTree = false;
        treeGrowth = 0;
        isSeedling = false;
        isYangeTree = false;
        isLargeTree = false;
    }


    public void UpdateGrowthPoint(){
        GrowthPoint = 10;
	}

	public void UpdateTree(){
        treeGrowth = Mathf.Clamp(treeGrowth+GrowthPoint, 0, 200);
        if(treeGrowth <= 100){
            isSeedling = true;
        }else if(treeGrowth <= 199){
            isYangeTree = true;
        }else{
            isLargeTree = true;
        }
	}

    //汚染度変化
	public void PollutionErosion(int degreeOfErosion){
        pollutionLevel = Mathf.Clamp(degreeOfErosion+pollutionLevel, 0, 100);
    }

    public int TreeRank(){
        if(isLargeTree){
            return 2;
        }else if(isYangeTree){
            return 1;
        }else if(isSeedling){
            return 0;
        }
        return 0;
    }
}
