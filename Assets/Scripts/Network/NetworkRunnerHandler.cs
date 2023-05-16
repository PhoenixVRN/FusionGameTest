using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;
using Fusion.Sockets;
using System;
using System.Linq;
using System.Threading.Tasks;



public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;

    private NetworkRunner _networkRunner;
    void Start()
    {
        _networkRunner = Instantiate(networkRunnerPrefab);
        _networkRunner.name = "Network runner";
        var clientTask = InitalizeNetworkRunner(_networkRunner, GameMode.AutoHostOrClient, NetAddress.Any(),SceneManager.GetActiveScene().buildIndex, null );
        Debug.Log($"Server NetworkRunner started.");
    }

    protected virtual Task InitalizeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address,
        SceneRef scene, Action<NetworkRunner> initialized)
    {
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
