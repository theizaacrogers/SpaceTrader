using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class StarGenerator : MonoBehaviour {
    public float mapscale = 10;

    List<GameObject> stars = new List<GameObject>();

    void gen()
    {
        for (int x = 0; x < mapscale; x++)
        {
            for (int y = 0; y < mapscale; y++)
            {
                stars.Add(new GameObject("star"));
                stars[stars.Count - 1].transform.position = new Vector3(Random.Range(x*5 - 10, x*5 + 10)*10, Random.Range(y*5 - 10, y*5 + 10)*2, 0);
                stars[stars.Count - 1].AddComponent<SolarSystemGen>();
            }
        }
    }

	// Use this for initialization
	void Start () {
        gen();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
