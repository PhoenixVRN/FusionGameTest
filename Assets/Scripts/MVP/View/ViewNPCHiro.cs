using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ViewNPCHiro : MonoBehaviour
{
    public Action<string> СollisionNPCEvt;
    public Action DestroyEvt;

    [HideInInspector] public Rigidbody Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
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