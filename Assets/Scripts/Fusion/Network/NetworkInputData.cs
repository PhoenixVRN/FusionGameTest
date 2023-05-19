using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
   public Vector2 MowementInput;
   public Vector3 AimForwardVector;
   public NetworkBool IsJumpPressed;
}
