using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetRandomSpaenPoint()
    {
        return new Vector3(Random.Range(-5, 5), 0.2f, Random.Range(-5, 5));
    }
}
