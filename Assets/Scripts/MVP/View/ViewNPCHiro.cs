using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ViewNPCHiro : MonoBehaviour
{
    public Action<string> СollisionNPCEvent;
    public Action Dispose;   
    public Action Moveing;   
    

    private void Start()
    {
        Moveing?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        СollisionNPCEvent?.Invoke(other.gameObject.name);
    }

    private void OnDestroy()
    {
        Dispose?.Invoke();
    }
}