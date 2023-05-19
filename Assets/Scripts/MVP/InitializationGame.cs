using UnityEngine;

public class initializationGame : MonoBehaviour
{
    [SerializeField] private GameObject _playerHuro;
    [SerializeField] private GameObject _npcHiro;
   
    void Start()
    {
        var player =Instantiate(_playerHuro, UtilMVP.GetRandomSpawnPoint(), Quaternion.identity).GetComponent<ViewPlayer>();
        HiroModel hiroModel = new HiroModel(15, 5, 2);
        PlayerController playerController= new PlayerController(player, hiroModel);
        player._playerController = playerController;
        
        Instantiate(_npcHiro, UtilMVP.GetRandomSpawnPoint(), Quaternion.identity);
    }

    
}
