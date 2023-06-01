using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ViewHero : MonoBehaviour
{
    public Transform SpawnBullet;
    [HideInInspector] public Rigidbody Rb;
    
    public Action<GameObject> СollisionEvt;

    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        СollisionEvt?.Invoke(other.gameObject);
    }
}
