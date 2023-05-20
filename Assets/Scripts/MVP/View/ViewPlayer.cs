using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
    [HideInInspector] public Rigidbody Rb;
    
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
}
