using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;

    public float moveSpeed = 8f;
    public float rotateSpeed = 100f;

    public float jumpVelocity = 5f;
    private bool _isJumping;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        _isJumping = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.deltaTime);
        Quaternion angleRot = Quaternion.Euler(Vector3.up * _hInput * Time.deltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isJumping) 
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            _isJumping = false;
    }
}
