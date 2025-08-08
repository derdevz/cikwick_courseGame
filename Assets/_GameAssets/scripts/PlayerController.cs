using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerConter : MonoBehaviour
{
    [Header("Refererances")]
    [SerializeField] private Transform _OrientationTranform;

    [Header("Movement Settings")]
    [SerializeField] private KeyCode _movementKey;
    [SerializeField] private float _movementSpeed;

    [Header("Jump Settings")]
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private float _jumpforce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private bool _canjump;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode _slideKey;
    [SerializeField] private float _slideMultiplier;
    [SerializeField] private float _slideDrag;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundDrag;

    private Rigidbody _PlayerRigidbody;


    private float _horizontalInput, _verticalInput;
    private Vector3 _MovemenetDirection;
    private bool _isSliding;
    private void Awake()
    {
        _PlayerRigidbody = GetComponent<Rigidbody>();
        _PlayerRigidbody.freezeRotation = true;
    }
    private void Update()
    {
        SetInputs();
        SetPlayerDrag();
        LimitPlayerLimit();
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(_slideKey))
        {
            _isSliding = true;
        }

        else if (Input.GetKey(_movementKey))
        {
            _isSliding = false;
        }
        
         else if (Input.GetKey(_jumpKey) && _canjump && IsGrounded())
        {
            //ZIPLAMA İŞLEMİ GERÇEKLEŞECEK!
            _canjump = false;
            SetPlayerJumping();
            Invoke(nameof(ResetJumping), _jumpCooldown);
        }

    }

    private void SetPlayerMovement()
    {
        _MovemenetDirection = _OrientationTranform.forward * _verticalInput
        + _OrientationTranform.right * _horizontalInput;

        if (_isSliding)
        {
            _PlayerRigidbody.AddForce(_MovemenetDirection.normalized * _movementSpeed * _slideMultiplier, ForceMode.Force);
        }
        else
        {
            _PlayerRigidbody.AddForce(_MovemenetDirection.normalized * _movementSpeed, ForceMode.Force);
        }
    }

    private void SetPlayerDrag()
    {
        if (_isSliding)
        {
            _PlayerRigidbody.linearDamping = _slideDrag;
        }
        else
        {
            _PlayerRigidbody.linearDamping = _groundDrag;
        }
    }

    private void LimitPlayerLimit()
    {
        Vector3 flatvelocity = new Vector3(_PlayerRigidbody.linearVelocity.x, 0f, _PlayerRigidbody.linearVelocity.z);

        if (flatvelocity.magnitude > _movementSpeed)
        {
            Vector3 limitedVelocity = flatvelocity.normalized * _movementSpeed;
            _PlayerRigidbody.linearVelocity = new Vector3(limitedVelocity.x, _PlayerRigidbody.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void SetPlayerJumping()
    {
        _PlayerRigidbody.linearVelocity = new Vector3(_PlayerRigidbody.linearVelocity.x, 0f, _PlayerRigidbody.linearVelocity.z);
        _PlayerRigidbody.AddForce(transform.up * _jumpforce, ForceMode.Impulse);
    }

    private void ResetJumping()
    {
        _canjump = true;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
    }

    




}