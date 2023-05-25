using System;
using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    void Start()
    {
        new NPCBuilder();
        new PlayerBuilder();
    }

    private void SpawnNpc()
    {
        new NPCBuilder();
    }
    
    private void Update()
    {
        ListController.UpDate(Time.deltaTime);
    }
}
