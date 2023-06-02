using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer Local;
    public  Transform PlayerModel;

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;
            // Utils.SetRenderLayerInChidren(playerModel, LayerMask.NameToLayer("LocalPlayerModel"));
            // if (Camera.main is not null) Camera.main.gameObject.SetActive(false);
            Debug.Log("Spawned local player");
        }
        else
        {
            // Camera localCamera = GetComponentInChildren<Camera>();
            // localCamera.enabled = false;
            //
            // AudioListener audioListener = GetComponentInChildren<AudioListener>();
            // audioListener.enabled = false;
            Debug.Log("Spawned remote player");
        }

        transform.name = $"P_{Object.Id}";
    }
    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.InputAuthority)
        {
            Runner.Despawn(Object);
        }
    }
    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_Change(Color color)
    {
        PlayerModel.gameObject.GetComponent<Renderer>().material.color = color;
    }
}
