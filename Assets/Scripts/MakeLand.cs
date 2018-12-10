using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLand : MonoBehaviour {

    public GameObject soil;
    public GameObject initGameObject;
    public int landLength;
    public Material[] soilMaterials;
    public GameObject[] trees;
    public int totelSetTree;
    public float waveTime;
    public GameObject Cleaner;
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
    private GameObject[] OnSoil;
    private SoilAttribute[] SoilAttributes;
    private int[] RandomInt;

	private void Start () {
        
        InitPosition = initGameObject.transform.position;
        Soils = new GameObject[landLength * landLength];
        OnSoil = new GameObject[landLength * landLength];
        RandomInt = new int[totelSetTree];

        for (int i = 0; i < landLength*landLength; i++){
            InitPosition = new Vector3(initGameObject.transform.position.x + (i % landLength) * 5,
                                      0,
                                       initGameObject.transform.position.z - (i / landLength) * 5);
            Soils[i] = Instantiate(soil,
                                   InitPosition,
                                   initGameObject.transform.rotation);
            Soils[i].transform.parent = this.gameObject.transform;
            Soils[i].AddComponent<SoilAttribute>();
            Soils[i].GetComponent<SoilAttribute>().init(i);
            Soils[i].GetComponent<SoilAttribute>().UpdateGrowthPoint();
            UpdateMaterial(i);
        }
        //最初の木の設定
        for (int i = 0; i < 5; i++){
            bool isContinue = false;
            RandomInt[i] = Random.Range(0, landLength * landLength);
            for (int j = 0; j < i; j++){
                if(RandomInt[i] == RandomInt[j]){
                    RandomInt[i] = 0;
                    isContinue = true;
                }
            }
            if(isContinue){
                i--;
                Debug.Log("yes");
                continue;
            }
            SetTree(RandomInt[i], true);
        }
        //汚染開始！！
        StartCoroutine(PollutionSoil());
	}

    //汚染
    IEnumerator PollutionSoil(){
        
        while (true){
            yield return new WaitForSeconds(waveTime);
            for (int i = 0; i < landLength * landLength; i++){
                Soils[i].GetComponent<SoilAttribute>().PollutionErosion(10);
                UpdateMaterial(i);
                UpdateTree(i);
            }
            //Debug.Log(Soils[1].GetComponent<SoilAttribute>().pollutionLevel);
        }
    }
	
	//マテリアルの変更
	public void UpdateMaterial (int index) {
        
        int pollitionLevel;
        pollitionLevel = Soils[index].GetComponent<SoilAttribute>().pollutionLevel;
        //Debug.Log(pollitionLevel);
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
    public void SetTree(int index, bool isSet){
        
        int treeIndex;
        if(isSet){
            Soils[index].GetComponent<SoilAttribute>().PlantTree(Random.Range(101, 150));
            treeIndex = 1;
        }else{
            Soils[index].GetComponent<SoilAttribute>().PlantTree(0);
            treeIndex = 0;
            
        }
        OnSoil[index] = Instantiate(trees[treeIndex], 
                                      Soils[index].transform.position, 
                                      Soils[index].transform.rotation);
        OnSoil[index].transform.parent = Soils[index].transform;
        return;
    }

    public void UpdateTree(int index){
        //木を成長させる
        if(!Soils[index].GetComponent<SoilAttribute>().isTree){
            return;
        }
        int beforeTreeRank = Soils[index].GetComponent<SoilAttribute>().TreeRank();
        if(beforeTreeRank == 2){
            return;
        }
        Soils[index].GetComponent<SoilAttribute>().UpdateTree();
        int afterTreeRank = Soils[index].GetComponent<SoilAttribute>().TreeRank();
        //木の成長度に応じてオブジェクトを入れ替える
        if(beforeTreeRank != afterTreeRank){
            Destroy(OnSoil[index]);
            OnSoil[index] = Instantiate(trees[afterTreeRank],
                                      Soils[index].transform.position,
                                      Soils[index].transform.rotation);
            OnSoil[index].transform.parent = Soils[index].transform;
        }
    }

    public int CutTree(int index){
        //木を切る
        int getTree = Soils[index].GetComponent<SoilAttribute>().CutTree();
        Destroy(OnSoil[index].gameObject);
        return getTree;
    }

    //浄化機を置く
    public void SetCleaner(int index){
        OnSoil[index] = Instantiate(Cleaner,
                                      Soils[index].transform.position,
                                      Soils[index].transform.rotation);
        OnSoil[index].transform.parent = Soils[index].transform;
        OnSoil[index].transform.position = new Vector3(OnSoil[index].transform.position.x,
                                                       OnSoil[index].transform.position.y + 0.5f,
                                                       OnSoil[index].transform.position.z);
        Soils[index].GetComponent<SoilAttribute>().SetCleaner();
        OnSoil[index].GetComponent<Cleaning>().ReceiveIndex(index);
    }

    //浄化機を消す
    public void DestroyCleanre(int index, int clean){
        Destroy(OnSoil[index].gameObject);
        Soils[index].GetComponent<SoilAttribute>().PollutionErosion(-clean);
        UpdateMaterial(index);
        Soils[index].GetComponent<SoilAttribute>().DestroyCleanre();
        Debug.Log("消えたよ");
    }

}
