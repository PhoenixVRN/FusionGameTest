using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilMVP
{
    public static Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-4, 4), 3f, Random.Range(-4, 4));
    }
}
