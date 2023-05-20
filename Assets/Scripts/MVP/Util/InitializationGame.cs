using System;
using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    [SerializeField] private GameObject _playerHero;
    [SerializeField] private GameObject _npcHero;  
    public static Action<float> Execute;

    void Start()
    {
       InitPlayer();
       InitNPS();
    }

    private void InitPlayer()
    {
        var playerView =Instantiate(_playerHero, UtilMVP.GetRandomSpawnPoint(), Quaternion.identity).GetComponent<ViewPlayer>();
        HeroModel heroModel = new HeroModel(15, 300, 300, 2);
        PlayerController playerController= new PlayerController(playerView, heroModel);
        Execute += ((IExecute) playerController).Execute;
    }

    private void InitNPS()
    {
        var npcHero = Instantiate(_npcHero, UtilMVP.GetRandomSpawnPoint(), Quaternion.identity)
            .GetComponent<ViewNPCHiro>();
        NPCHeroModel npcHeroModel = new NPCHeroModel(20, 300, 300, 2, 3);
        NPSHeroController npsHeroController = new NPSHeroController(npcHeroModel, npcHero);
        Execute += ((IExecute) npsHeroController).Execute;
    }

    private void Update()
    {
        Execute?.Invoke(Time.deltaTime);
    }
}
