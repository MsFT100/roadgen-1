using UnityEngine;
using System;

public class GlobalSeeder : MonoBehaviour
{
    public bool useTimeAsSeed = true;
    public int seed = 0;

    static int GetSecondsSinceEpoch()
    {
        var epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var currentTime = DateTime.UtcNow;
        var seconds = (int)(currentTime - epochStart).TotalSeconds;
        return seconds;
    }

    void Start()
    {
        seed = (useTimeAsSeed) ? GetSecondsSinceEpoch() : seed;
        UnityEngine.Random.InitState(seed);
        RoadGen.Perlin.Seed(seed);
        Debug.Log("Seed: " + seed);
    }
}

