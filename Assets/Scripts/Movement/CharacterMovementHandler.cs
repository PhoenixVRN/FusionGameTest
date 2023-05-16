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
        if (!Object.HasInputAuthority)
        {
            localCamera.gameObject.SetActive(false);
        }
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
            networkCharacterControllerPrototypeCustom.Rotate(networkInputData.rotationInput);
            
            Vector3 moveDirection = transform.forward * networkInputData.mowementInput.y +
                                    transform.right * networkInputData.mowementInput.x;
            moveDirection.Normalize();
            
            networkCharacterControllerPrototypeCustom.Move(moveDirection);

            if (networkInputData.isJumpPressed)
            {
                networkCharacterControllerPrototypeCustom.Jump();
            }
        }
    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }
}
