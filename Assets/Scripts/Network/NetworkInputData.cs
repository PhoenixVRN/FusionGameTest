using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
   public Vector2 mowementInput;
   public Vector3 aimForwardVector;
   public NetworkBool isJumpPressed;
}
