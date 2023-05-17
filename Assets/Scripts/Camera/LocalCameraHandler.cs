using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraHandler : MonoBehaviour
{
    public Transform cameraAnchorPoint;
    private Camera localCamera;

    private float cameraRotationX = 0;
    private float cameraRotationY = 0;

    private Vector2 viewInput;

    private NetworkCharacterControllerPrototypeCustom _networkCharacterControllerPrototypeCustom;

    private void Awake()
    {
        localCamera = GetComponent<Camera>();
        _networkCharacterControllerPrototypeCustom = GetComponentInParent<NetworkCharacterControllerPrototypeCustom>();
    }

    void Start()
    {
        if (localCamera.enabled)
        {
            localCamera.transform.parent = null;
        }
    }

    
    void LateUpdate()
    {
        if (cameraAnchorPoint == null) return;
        
        if (!localCamera.enabled) return;

        localCamera.transform.position = cameraAnchorPoint.position;
        
        cameraRotationX += viewInput.y * Time.deltaTime * _networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);
        
        cameraRotationY += viewInput.x * Time.deltaTime * _networkCharacterControllerPrototypeCustom.rotationSpeed;

        localCamera.transform.localRotation = Quaternion.Euler(cameraRotationX,cameraRotationY,0);
    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }
}
