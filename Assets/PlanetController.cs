using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {
    public float orbitDistance;
    public bool habitable;

    public SpriteRenderer g;
    CircleCollider2D c;
    SolarSystemGen ssc;

    public PlanetInfo planetInfo;

	// Use this for initialization
	void Start () {

        //planet graphics
        SpriteCollection sc = GameObject.Find("Sprite Collection").GetComponent<SpriteCollection>();
        ssc = transform.parent.GetComponent<SolarSystemGen>();

        transform.position += new Vector3(orbitDistance, 0, 0);
        g = gameObject.AddComponent<SpriteRenderer>();
        c = gameObject.AddComponent<CircleCollider2D>();

        g.sprite = habitable ? sc.getHabitablePlanet() : sc.getHostilePlanet();

        float scale = habitable ? Random.Range(0.2f, 0.5f): Random.Range(0.4f, 0.75f);
        transform.localScale = new Vector3(scale, scale, scale);

        planetInfo = new PlanetInfo(GetComponentInParent<SolarSystemGen>().starInfo.name + orbitDistance, habitable, GetComponentInParent<SolarSystemGen>().starInfo.rank);

	}

    void OnMouseDown(){
        
    }

    // Update is called once per frame
    void Update () {
        //orbit
        transform.RotateAround(transform.parent.position, Vector3.forward, (orbitDistance * 1 * Time.deltaTime));

        if (ssc.selected){
            g.enabled = true;
        }
        else {
            g.enabled = false;
        }
    }
}
