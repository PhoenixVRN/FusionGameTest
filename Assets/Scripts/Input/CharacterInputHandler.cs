using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    private bool isJumpButtonPressed;


    private LocalCameraHandler _localCameraHandler;

    private void Awake()
    {
        _localCameraHandler = GetComponentInChildren<LocalCameraHandler>();
    }

    void Update()
    {
        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1;

        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            isJumpButtonPressed = true;
        }
        
        _localCameraHandler.SetViewInputVector(viewInputVector);
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.isJumpPressed = isJumpButtonPressed;

        networkInputData.aimForwardVector = _localCameraHandler.transform.forward;
        
        networkInputData.mowementInput = moveInputVector;

        isJumpButtonPressed = false;
        return networkInputData;
    }
}
