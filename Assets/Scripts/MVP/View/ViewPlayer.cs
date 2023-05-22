using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ViewPlayer : MonoBehaviour
{
    [HideInInspector] public Rigidbody Rb;
    
    public Action<string> СollisionPlayerEvt;
    public Action DestroyEvt;
    
    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        СollisionPlayerEvt?.Invoke(other.gameObject.name);
    }
    
    private void OnDestroy()
    {
        DestroyEvt?.Invoke();
    }
}
