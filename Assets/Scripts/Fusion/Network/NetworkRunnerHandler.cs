using System;
using System.Linq;
using System.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner NetworkRunnerPrefab;

    private NetworkRunner _networkRunner;
    void Start()
    {
        _networkRunner = Instantiate(NetworkRunnerPrefab);
        _networkRunner.name = "Network runner";
        var clientTask = InitalizeNetworkRunner(_networkRunner, GameMode.AutoHostOrClient, NetAddress.Any(),SceneManager.GetActiveScene().buildIndex, null );
        Debug.Log($"Server NetworkRunner started.");
    }

    protected virtual Task InitalizeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address,
        SceneRef scene, Action<NetworkRunner> initialized)
    {
        // var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();
        var sceneObjetProvider = runner.GetComponents(typeof(MonoBehaviour)).OfType<NetworkSceneManagerDefault>().FirstOrDefault();
        if (sceneObjetProvider == null)
        {
            sceneObjetProvider = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }

        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs()
        {
GameMode = gameMode,
Address = address,
Scene = scene,
SessionName =  "TestRoom",
Initialized = initialized,
SceneManager = sceneObjetProvider
        });
    }
}
