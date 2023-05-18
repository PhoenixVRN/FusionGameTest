using UnityEngine;

public class LocalCameraHandler : MonoBehaviour
{
    public Transform CameraAnchorPoint;
    
    private Camera _localCamera;

    private float _cameraRotationX = 0;
    private float _cameraRotationY = 0;

    private Vector2 _viewInput;

    private NetworkCharacterControllerPrototypeCustom _networkCharacterControllerPrototypeCustom;

    private void Awake()
    {
        _localCamera = GetComponent<Camera>();
        _networkCharacterControllerPrototypeCustom = GetComponentInParent<NetworkCharacterControllerPrototypeCustom>();
    }

    void Start()
    {
        if (_localCamera.enabled)
        {
            _localCamera.transform.parent = null;
        }
    }

    
    void Update()
    {
        if (CameraAnchorPoint == null) return;
        
        if (!_localCamera.enabled) return;

        _localCamera.transform.position = CameraAnchorPoint.position + new Vector3(0,3,-1);
        
        // cameraRotationX += viewInput.y * Time.deltaTime * _networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;
        // cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);
        //
        // cameraRotationY += viewInput.x * Time.deltaTime * _networkCharacterControllerPrototypeCustom.rotationSpeed;
        //
        // localCamera.transform.localRotation = Quaternion.Euler(cameraRotationX,cameraRotationY,0);
    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        this._viewInput = viewInput;
    }
}
