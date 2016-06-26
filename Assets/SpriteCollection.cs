using UnityEngine;
using System.Collections;

public class SpriteCollection : MonoBehaviour {

    public Sprite[] Stars;
    public Sprite[] SmallStars;
    public Sprite[] HabitablePlanets;
    public Sprite[] HostilePlanets;

    public Sprite getStar()
    {
        return Stars[Random.Range(0, Stars.Length)];
    }

    public Sprite getSmallStar()
    {
        return SmallStars[Random.Range(0, SmallStars.Length)];
    }

    public Sprite getHabitablePlanet()
    {
        return HabitablePlanets[Random.Range(0, HabitablePlanets.Length)];
    }

    public Sprite getHostilePlanet()
    {
        return HostilePlanets[Random.Range(0, HostilePlanets.Length)];
    }

}
