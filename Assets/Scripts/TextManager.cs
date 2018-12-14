using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public Text Electr;
    public Text HaveElectr;
    public Text HaveWater;
    public Text HaveSeeding;
    public Text HaveWood;
    public Text Time;
    public GameObject House;
    public GameObject Player1;
    public GameObject Player2;

    private string HaveElectrText;
    private string HaveWaterText;
    private string HaveSeedingText;
    private string HaveWoodText;
	// Use this for initialization
	void Start () {
        HaveElectrText = HaveElectr.text;
        HaveWaterText = HaveWater.text;
        HaveSeedingText = HaveSeeding.text;
        HaveWoodText = HaveWood.text;
	}
	
	// Update is called once per frame
	void Update () {
        Time.text = "[ "+House.GetComponent<GameOver>().CountTime.ToString("F2") + " ]";
        Electr.text = House.GetComponent<HouseAttribute>().electricQuantity + "";
        HaveElectr.text = HaveElectrText + Player1.GetComponent<PlayerEvent>().HaveElectr;
        HaveWater.text = HaveWaterText + Player1.GetComponent<PlayerEvent>().HaveWater;
        HaveSeeding.text = HaveSeedingText + Player2.GetComponent<PlayerEvent>().HaveSeedings;
        HaveWood.text = HaveWoodText + Player2.GetComponent<PlayerEvent>().GetTree;
	}
}
