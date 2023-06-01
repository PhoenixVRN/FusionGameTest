using UnityEngine;

public static class UtilMVP
{
    private const int DISTANCE_SPAWN = 3;
    public static Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-DISTANCE_SPAWN, DISTANCE_SPAWN), 0.3f, Random.Range(-DISTANCE_SPAWN, DISTANCE_SPAWN));
    }
}
