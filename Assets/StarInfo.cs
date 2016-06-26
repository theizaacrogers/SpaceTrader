using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class StarInfo{

    public string name;
    public int rank;
    public GameObject[] planets;

    public StarInfo(string name, int rank, GameObject[] planets) {
        this.name = name;
        this.rank = rank;
        this.planets = planets;
    }

}
