using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilAttribute : MonoBehaviour{

    public bool isTree;
    public bool isCleaner;
    public int pollutionLevel;
    public int treeGrowth;
    public int SoilNumber;

    private int GrowthPoint;
    private bool isSeedling;
    private bool isYangeTree;
    private bool isLargeTree;
    private int HaveWater;

    public void init(int index){
        //init attribute
        isTree = false;
        isCleaner = false;
        pollutionLevel = Random.Range(0, 50)+20;
        treeGrowth = 0;
        isSeedling = false;
        isYangeTree = false;
        isLargeTree = false;
        HaveWater = 0;
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

    public int CutTree(){
        int Rank = TreeRank();
        isTree = false;
        treeGrowth = 0;
        isSeedling = false;
        isYangeTree = false;
        isLargeTree = false;
        return Rank;
    }


    public void UpdateGrowthPoint(){
        GrowthPoint = 10;
	}

	public void UpdateTree(){
        if (HaveWater > 0){
            treeGrowth = Mathf.Clamp(treeGrowth + GrowthPoint, 0, 200);
            HaveWater -= 2;
        }
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

    public void GetWater(int water){
        HaveWater += water;
    }

    public void SetCleaner(){
        isCleaner = true;
    }
}
