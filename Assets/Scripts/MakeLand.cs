using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLand : MonoBehaviour {

    public GameObject soil;
    public GameObject initGameObject;
    public int landLength;
    public Material[] soilMaterials;
    public GameObject[] trees;
    /// <summary>
    /// treeGrowthとMaterialの関係
    ///     ~ 20  
    ///  21 ~ 50 
    ///  51 ~ 80 
    ///  81 ~ 99 
    ///  100     
    /// </summary>

    private Vector3 InitPosition;
    private GameObject[] Soils;
    private GameObject[] treeonsoil;
    private SoilAttribute[] SoilAttributes;
    private int[] randomInt;

	void Start () {
        InitPosition = initGameObject.transform.position;
        Soils = new GameObject[landLength * landLength];
        treeonsoil = new GameObject[5];
        randomInt = new int[5];
        for (int i = 0; i < landLength*landLength; i++){
            InitPosition = new Vector3(initGameObject.transform.position.x + (i % landLength) * 3,
                                      0,
                                       initGameObject.transform.position.z - (i / landLength) * 3);
            Soils[i] = Instantiate(soil,
                                   InitPosition,
                                   initGameObject.transform.rotation);
            Soils[i].transform.parent = this.gameObject.transform;
            Soils[i].AddComponent<SoilAttribute>();
            Soils[i].GetComponent<SoilAttribute>().init();
            UpdateMaterial(i);
        }
        for (int i = 0; i < 5; i++){
            randomInt[i] = Random.Range(50, 150);
            treeonsoil[i] = setTree(randomInt[i]);
        }
        StartCoroutine(PollutionSoil());
	}

    IEnumerator PollutionSoil(){
        while (true){
            yield return new WaitForSeconds(7.5f);
            for (int i = 0; i < landLength * landLength; i++){
                Soils[i].GetComponent<SoilAttribute>().PollutionErosion(10);
                UpdateMaterial(i);
            }
            //Debug.Log(Soils[1].GetComponent<SoilAttribute>().pollutionLevel);
        }
    }
	
	//マテリアルの変更
	void UpdateMaterial (int index) {
        int pollitionLevel;
        pollitionLevel = Soils[index].GetComponent<SoilAttribute>().pollutionLevel;
        Debug.Log(pollitionLevel);
        if(pollitionLevel <= 20){
            Soils[index].GetComponent<Renderer>().material = soilMaterials[0];
        }else if(pollitionLevel <= 50){
            Soils[index].GetComponent<Renderer>().material = soilMaterials[1];
        }else if(pollitionLevel <= 80){
            Soils[index].GetComponent<Renderer>().material = soilMaterials[2];
        }else if(pollitionLevel <= 99){
            Soils[index].GetComponent<Renderer>().material = soilMaterials[3];
        }else{
            Soils[index].GetComponent<Renderer>().material = soilMaterials[4];
        }
	}

    //木を植える
    GameObject setTree(int index){
        
        Soils[index].GetComponent<SoilAttribute>().PlantTree();
        GameObject tree = Instantiate(trees[0], 
                                      Soils[index].transform.position, 
                                      Soils[index].transform.rotation);
        tree.transform.parent = Soils[index].transform;
        Debug.Log(tree.transform.position);
        return tree;
    }
}
