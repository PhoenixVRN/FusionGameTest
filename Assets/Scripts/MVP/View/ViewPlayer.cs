using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
    private Rigidbody _rb;

    [HideInInspector] public PlayerController _playerController;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        _playerController.MoveHandler();
    }

    public void MoveHiro(int speed, int rotateSpeed)
    {
        _rb.velocity = (transform.forward * Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        transform.Rotate(transform.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
    }
}
