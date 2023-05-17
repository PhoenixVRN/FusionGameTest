using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class CharacterMovementHandler : NetworkBehaviour
{
    private Vector2 viewInput;

    private float cameraRotationX = 0;
    
    private NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;
    private Camera localCamera;

    private void Awake()
    {
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        localCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        cameraRotationX += viewInput.y * Time.deltaTime * networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);
        
        localCamera.transform.localRotation = Quaternion.Euler(cameraRotationX,0,0);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            transform.forward = networkInputData.aimForwardVector;
            
            Vector3 moveDirection = transform.forward * networkInputData.mowementInput.y +
                                    transform.right * networkInputData.mowementInput.x;
            moveDirection.Normalize();
            
            networkCharacterControllerPrototypeCustom.Move(moveDirection);

            if (networkInputData.isJumpPressed)
            {
                networkCharacterControllerPrototypeCustom.Jump();
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

    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }
}
