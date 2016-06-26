using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarInfoGUI : MonoBehaviour {

    public GameObject guiHolder;
    public GameObject StarInfoPrefab;
    public GameObject[] PlanetInfoPrefabs;

    Image StarImage;
    Text StarNameField;
    Text RankNum;

    public void DrawStarInfo(StarInfo info) {
        //update StarInfoGUI objects according to given StarInfo
        StarInfoPrefab.SetActive(true);
        StarNameField.text = info.name;
        RankNum.text = ""+info.rank;

        for (int i=0;i<info.planets.Length;i++) {
            PlanetController pc = info.planets[i].GetComponent<PlanetController>();
            GameObject planetGUI = PlanetInfoPrefabs[i];
            planetGUI.SetActive(true);
            planetGUI.transform.FindChild("Name Field").GetComponent<Text>().text = pc.planetInfo.name;
            planetGUI.transform.FindChild("Factory num").GetComponent<Text>().text = ""+pc.planetInfo.factories;
            planetGUI.transform.FindChild("Refinery num").GetComponent<Text>().text = ""+pc.planetInfo.refineries;
            planetGUI.transform.FindChild("habitable").GetComponent<Toggle>().isOn = pc.planetInfo.habitable;
        }

    }

    public void UndrawStarInfo() {
        StarInfoPrefab.SetActive(false);
        foreach (GameObject g in PlanetInfoPrefabs) {
            g.SetActive(false);
        }
    }


	// Use this for initialization
	void Start () {
        StarImage = StarInfoPrefab.GetComponentInChildren<Image>();
        StarNameField = GameObject.Find("Star Name Field").GetComponent<Text>();
        RankNum = GameObject.Find("Rank num").GetComponent<Text>();
        foreach (GameObject g in PlanetInfoPrefabs)
        {
            g.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
