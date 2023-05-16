using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
   public Vector2 mowementInput;
   public float rotationInput;
   public NetworkBool isJumpPressed;
}
