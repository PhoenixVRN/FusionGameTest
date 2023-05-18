using UnityEngine;

public static class Utils
{
    public static Vector3 GetRandomSpaenPoint()
    {
        return new Vector3(Random.Range(-4, 4), 3f, Random.Range(-4, 4));
    }

    public static void SetRenderLayerInChidren(Transform transform, int layerNumber)
    {
        foreach (var trans in transform.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
