using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    private Vector2 _moveInputVector = Vector2.zero;
    private Vector2 _viewInputVector = Vector2.zero;
    private bool _isJumpButtonPressed;

    private LocalCameraHandler _localCameraHandler;
    
    NetworkInputData networkInputData;

    private void Awake()
    {
        _localCameraHandler = GetComponentInChildren<LocalCameraHandler>();
        networkInputData = new NetworkInputData();
    }

    void Update()
    {
        _viewInputVector.x = Input.GetAxis("Mouse X");
        _viewInputVector.y = Input.GetAxis("Mouse Y") * -1;

        _moveInputVector.x = Input.GetAxis("Horizontal");
        _moveInputVector.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            _isJumpButtonPressed = true;
        }
        
        // _localCameraHandler.SetViewInputVector(viewInputVector);
    }

    public NetworkInputData GetNetworkInput()
    {
        // NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.IsJumpPressed = _isJumpButtonPressed;

        // networkInputData.aimForwardVector = _localCameraHandler.transform.forward;
        
        networkInputData.MowementInput = _moveInputVector;

        _isJumpButtonPressed = false;
        return networkInputData;
    }
}
