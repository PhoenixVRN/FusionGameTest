using System;
using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    public static Action<float> Execute;

    void Start()
    {
        new NPCBuilder();
        new PlayerBuilder();
    }

   
    
    private void FixedUpdate()
    {
        Execute?.Invoke(Time.deltaTime);
    }
}
