using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    private bool isJumpButtonPressed;

    private CharacterMovementHandler _characterMovementHandler;

    private void Awake()
    {
        _characterMovementHandler = GetComponent<CharacterMovementHandler>();
    }

    void Update()
    {
        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1;
        
        _characterMovementHandler.SetViewInputVector(viewInputVector);
        
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        isJumpButtonPressed = Input.GetButtonDown("Jump");

    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.isJumpPressed = isJumpButtonPressed;

        networkInputData.rotationInput = viewInputVector.x;
        
        networkInputData.mowementInput = moveInputVector;
        return networkInputData;
    }
}
