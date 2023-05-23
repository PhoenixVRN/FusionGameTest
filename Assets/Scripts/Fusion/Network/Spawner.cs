using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkPlayer PlayerPrefab;
    public PhysxBall Ball;
    private CharacterInputHandler _characterInputHandler;

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerJoine");
        if (runner.IsServer)
        {
            Debug.Log("OnPlayerJoined we are serwer. Spawwning player");
            runner.Spawn(PlayerPrefab, Utils.GetRandomSpaenPoint(),Quaternion.identity, player);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
            runner.Spawn(Ball, Utils.GetRandomSpaenPoint(),Quaternion.identity);
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerLeft");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        if (_characterInputHandler == null && NetworkPlayer.Local != null)
        {
            _characterInputHandler = NetworkPlayer.Local.GetComponent<CharacterInputHandler>();
        }

        if (_characterInputHandler != null)
        {
            input.Set(_characterInputHandler.GetNetworkInput());
        }
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    { 
        Debug.Log("OnInputMissing");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("OnShutdown");
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("OnConnectedToServer");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log("OnDisconnectedFromServe");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("OnConnectRequest");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
         Debug.Log("OnConnectFailed");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        Debug.Log("OnUserSimulationMessage");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("OnSessionListUpdated");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("OnCustomAuthenticationResponse");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("OnHostMigration");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        Debug.Log("OnReliableDataReceived");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("OnSceneLoadDone");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
         Debug.Log("OnSceneLoadStart");
    }
}
