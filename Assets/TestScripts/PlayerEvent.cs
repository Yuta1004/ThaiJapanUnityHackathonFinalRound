﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour {

    public bool isCanCutTree;
    public bool isCanGetTree;
    public bool isCanHaveWater;
    public bool isCanCleanse;
    public bool isCanPlantTree;

    private bool IsHaveWater;
    private bool IsGetWater;
    private float HaveWater;
    private bool IsHaveElectr;
    private float HaveElectr;
    private bool IsGetTree;
    private int HaveSeedings;

	// Use this for initialization
	public void Start () {
        IsHaveWater = false;
        IsGetWater = false;
        IsHaveElectr = false;
        IsGetTree = false;
        HaveWater = 0;
        HaveElectr = 0;
        HaveSeedings = 3;
	}

    public void GetSpace(GameObject Soil){
        if (isCanPlantTree){
            if (HaveSeedings == 0){
                return;
            }
            if (!Soil.GetComponent<SoilAttribute>().isTree){
                int index = Soil.GetComponent<SoilAttribute>().SoilNumber;
                Soil.gameObject.transform.root.GetComponent<MakeLand>().SetTree(index, false);
                HaveSeedings--;
            }
        Debug.Log(HaveSeedings);
        }
    }
}
