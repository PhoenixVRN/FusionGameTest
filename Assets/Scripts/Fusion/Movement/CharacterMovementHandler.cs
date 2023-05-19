using Fusion;
using UnityEngine;

public class CharacterMovementHandler : NetworkBehaviour
{

    private NetworkCharacterControllerPrototypeCustom _networkCharacterControllerPrototypeCustom;
    private Camera _localCamera;

    private void Awake()
    {
        _networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        _localCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            // transform.forward = networkInputData.aimForwardVector;

            // Quaternion rotation = transform.rotation;
            // rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, rotation.eulerAngles.z);
            // transform.rotation = rotation;
            
            Vector3 moveDirection = transform.forward * networkInputData.MowementInput.y +
                                    transform.right * networkInputData.MowementInput.x;
            moveDirection.Normalize();
            
            _networkCharacterControllerPrototypeCustom.Move(moveDirection);

            if (networkInputData.IsJumpPressed)
            {
                _networkCharacterControllerPrototypeCustom.Jump();
            }
            
            CheckFalllRespawn();
        }
    }

    private void CheckFalllRespawn()
    {
        if (transform.position.y < -12)
        {
            transform.position = Utils.GetRandomSpaenPoint();
        }
    }
}
