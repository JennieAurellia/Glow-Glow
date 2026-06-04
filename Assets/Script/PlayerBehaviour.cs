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

    // ground check vars
    public bool IsOnGround = true;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;

    // shooting vars
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    public bool _isShooting;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        _isShooting = Input.GetKeyDown(KeyCode.F);

        IsOnGround = Physics.CheckSphere(transform.position, GroundCheckRadius, GroundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround) 
            _isJumping = true;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.deltaTime);
        Quaternion angleRot = Quaternion.Euler(Vector3.up * _hInput * Time.deltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }
            
        if (_isShooting)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1f;
            GameObject newBullet = Instantiate(Bullet, spawnPos, this.transform.rotation);
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = transform.forward * BulletSpeed;
            _isShooting = false;
        }
    }
}
