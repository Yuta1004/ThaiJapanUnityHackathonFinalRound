﻿using System.Collections;
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

    public void init(int index){
        //init attribute
        isTree = false;
        isCleaner = false;
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
        UpdateTree();
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
        treeGrowth += water*2;
    }

    public void SetCleaner(){
        isCleaner = true;
    }

    public void DestroyCleanre(){
        isCleaner = false;
    }
}
