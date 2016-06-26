using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SolarSystemGen : MonoBehaviour {

    public int rank;
    public int numPlanets;

    public bool selected = false;
    bool deselect = true;


    public List<GameObject> planets = new List<GameObject>();

    Sprite starSprite;
    public SpriteRenderer g;
    SpriteCollection sc;
    CircleCollider2D c;

    public StarInfo starInfo;

    // Use this for initialization
    void Start() {
        //solar system mechanics
        rank = Random.Range(1,6);
        numPlanets = Random.Range(0,4);

        for (int i = 0; i < numPlanets; i++) {
            planets.Add(new GameObject("planet"));
            planets[planets.Count - 1].transform.parent = transform;
            planets[planets.Count - 1].transform.position = transform.position;
            planets[planets.Count - 1].AddComponent<PlanetController>();
            planets[planets.Count - 1].GetComponent<PlanetController>().orbitDistance = i+1;
            planets[planets.Count - 1].GetComponent<PlanetController>().habitable = (((int)Random.Range(1,10))/rank<=2) ? true : false;
        }

        //star graphics
        sc = GameObject.Find("Sprite Collection").GetComponent<SpriteCollection>();
        g = gameObject.AddComponent<SpriteRenderer>();
        g.transform.localScale = new Vector3(starScale, starScale, starScale);
        starSprite = sc.getStar();

        //collider stuff
        c = gameObject.AddComponent<CircleCollider2D>();

        starInfo = new StarInfo("" + transform.position.ToString(), rank, planets.ToArray());

    }

    void OnMouseDown() {
        selected = !selected;
        Debug.Log("OnMouseDown");
        if (!selected)
            deselect=true;

    }

    void OnMouseOver() {
        //For Later UI Stuff
        if (!selected) {
            StarInfoGUI gui = GameObject.Find("Canvas").GetComponent<StarInfoGUI>();
            gui.guiHolder.transform.position = Input.mousePosition;
            gui.DrawStarInfo(starInfo);
        }
    }

    void OnMouseExit() {
        StarInfoGUI gui = GameObject.Find("Canvas").GetComponent<StarInfoGUI>();
        gui.UndrawStarInfo();
    }

    float starScale = Random.Range(0.25f, 1.5f);
	// Update is called once per frame
	void Update () {

        if (selected) {
            g.sprite = starSprite;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z),Time.deltaTime*2.5f);
            Camera.main.GetComponent<CameraController>().LerpZoom();
        }

        if (deselect) {
            deselect = false;
            Camera.main.GetComponent<CameraController>().zoomOut();
            Debug.Log("deselect");
            g.sprite = sc.getSmallStar();
            
        }

	}
}
