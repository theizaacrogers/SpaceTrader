using UnityEngine;
using System.Collections;

public class PlanetInfo {

    public string name;
    public bool habitable;

    public int factories, maxFactories;
    public int refineries, maxRefineries;

    public int factoryCost;
    public int refineryCost;

    public PlanetInfo(string name, bool habitable, int starRank) {
        this.name = name;
        this.habitable = habitable;

        refineries = 0;
        factories = 0;

        int rankBonus = (starRank*2*10)/100;

        if (habitable)
        {
            maxRefineries = 128 * rankBonus;
            maxFactories = 128 * rankBonus;
            refineryCost = 100;
            factoryCost = 100;
        }
        else
        {
            maxRefineries = 256 * rankBonus;
            maxFactories = 64 * rankBonus;
            refineryCost = 200;
            factoryCost = 400;
        }
    }

}
