using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
  
    [HideInInspector] public CharacterController CharacterController;
    [HideInInspector] public Vector3 Move;

    [HideInInspector] public PlayerController _playerController;
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerController.MoveHandler(Move);
    }

    public void MoveHiro(Vector3 move)
    {
        CharacterController.Move(move);
    }
}
