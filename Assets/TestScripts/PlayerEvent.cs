using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{

    public bool isCanCutTree;
    public bool isCanHaveWater;
    public bool isCanCleanse;
    public bool isCanPlantTree;

    private bool IsHaveWater;
    private bool IsGetWater;
    private int HaveWater;
    private bool IsHaveElectr;
    private int HaveElectr;
    private bool IsGetTree;
    private int GetTree;
    private int HaveSeedings;

    // Use this for initialization
    public void Start(){
        IsHaveWater = false;
        IsGetWater = false;
        IsHaveElectr = false;
        IsGetTree = false;
        HaveWater = 50;
        HaveElectr = 0;
        HaveSeedings = 3;
    }

    //スペースを押した時
    public void GetSpaceSoil(GameObject Soil){
        int index = Soil.GetComponent<SoilAttribute>().SoilNumber;
        if (isCanPlantTree){
            PlantTree(Soil, index);
        }
        if (isCanCutTree){
            CutTree(Soil, index);
        }

        if(isCanHaveWater){
            UseWater(Soil, index);
        }

        if(isCanCleanse){
            Cleanse(Soil, index);
        }
    }

    public void PlantTree(GameObject Soil, int index){
        if (HaveSeedings == 0){
            return;
        }else if (Soil.GetComponent<SoilAttribute>().isCleaner){
            return;
        }if (!Soil.GetComponent<SoilAttribute>().isTree){
            Soil.gameObject.transform.root.GetComponent<MakeLand>().SetTree(index, false);
            HaveSeedings--;
        }
    }

    public void CutTree(GameObject Soil, int index){
        if (!Soil.GetComponent<SoilAttribute>().isTree){
            return;
        }else if (IsGetTree){
            return;
        }else if (Soil.GetComponent<SoilAttribute>().TreeRank() == 0){
            return;
        }
        GetTree = Soil.gameObject.transform.root.GetComponent<MakeLand>().CutTree(index);
        IsGetTree = true;
    }

    public void UseWater(GameObject Soil, int index){
        if (HaveWater <= 0){
            Debug.Log("水をあげれない");
            return;
        }else if (!Soil.GetComponent<SoilAttribute>().isTree){
            return;
        }
        Soil.GetComponent<SoilAttribute>().GetWater(10);
        HaveWater -= 10;
        Debug.Log("水をあげた");
    }

    public void Cleanse(GameObject Soil, int index){
        if (Soil.GetComponent<SoilAttribute>().isCleaner){
            return;
        }else if (Soil.GetComponent<SoilAttribute>().isTree){
            return;
        }else if (HaveElectr <= 0){
            Debug.Log("電気がないよ");
            return;
        }
        Debug.Log("置けるよ");
        Soil.gameObject.transform.root.GetComponent<MakeLand>().SetCleaner(index);
        HaveElectr -= 10;
    }

    public void GetSpaceWater(){
        if(isCanHaveWater){
            HaveWater = 100;
            Debug.Log("水をもらった");
        }
    }

    public void GetElectr(GameObject House){
        HaveElectr = House.GetComponent<HouseAttribute>().GiveElectr(HaveElectr);
        Debug.Log("電気をもらった");
    }

    public int passTree(){
        if(!IsGetTree){
            return 0;
        }
        int TotalTree = GetTree;
        GetTree = 0;
        IsGetTree = false;
        Debug.Log("電気を作ったよ");
        return TotalTree;
    }
}
