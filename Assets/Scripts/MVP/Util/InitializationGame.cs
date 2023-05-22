using System;
using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    [SerializeField] private GameObject _playerHero;
    [SerializeField] private GameObject _npcHero;  
    public static Action<float> Execute;

    void Start()
    {
       InitNPS();
       InitPlayer();
    }

    private void InitPlayer()
    {
        HeroModel heroModel = new HeroModel(15, 200, 300, 2);
        PlayerController playerController= new PlayerController(Instantiate(_playerHero, UtilMVP.GetRandomSpawnPoint(),
            Quaternion.identity).GetComponent<ViewPlayer>(), heroModel);
        playerController.Init();
        Execute += ((IExecute) playerController).Execute;
    }

    private void InitNPS()
    {
        NPCHeroModel npcHeroModel = new NPCHeroModel(20, 3, 300, 2, 3);
        NPSHeroController npsHeroController = new NPSHeroController(Instantiate(_npcHero, UtilMVP.GetRandomSpawnPoint(), Quaternion.identity)
            .GetComponent<ViewNPCHiro>(), npcHeroModel);
        npsHeroController.Init();
        Execute += ((IExecute) npsHeroController).Execute;
    }

    private void FixedUpdate()
    {
        Execute?.Invoke(Time.deltaTime);
    }
}
