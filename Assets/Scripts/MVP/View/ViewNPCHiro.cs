using System;
using UnityEngine;

public class ViewNPCHiro : MonoBehaviour
{
    public Action<string> СollisionNPCEvt;
    public Action DestroyEvt;   
    public Action MoveingEvt;   
    

    private void Start()
    {
        MoveingEvt?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        СollisionNPCEvt?.Invoke(other.gameObject.name);
    }

    private void OnDestroy()
    {
        DestroyEvt?.Invoke();
    }
}