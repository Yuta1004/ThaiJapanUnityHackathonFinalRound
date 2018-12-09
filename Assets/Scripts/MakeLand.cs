using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLand : MonoBehaviour {

    public GameObject soil;
    public int landLength;
    public Material[] soilMaterials;
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
	void Start () {
        InitPosition = this.transform.position;
        Soils = new GameObject[landLength * landLength];
        for (int i = 0; i < landLength*landLength; i++){
            InitPosition = new Vector3(this.transform.position.x + (i % landLength) * 3,
                                      0,
                                       this.transform.position.z - (i / landLength) * 3);
            Soils[i] = Instantiate(soil,
                        InitPosition,
                        this.transform.rotation);
        }
	}
	
	// Update is called once per frame
	void UpdateMa () {
		
	}
}
