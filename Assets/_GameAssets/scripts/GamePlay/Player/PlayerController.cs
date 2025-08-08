using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

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
    [SerializeField] private float _airMultiplier;
    [SerializeField] private float _airDrag;
    [SerializeField] private bool _canjump;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode _slideKey;
    [SerializeField] private float _slideMultiplier;
    [SerializeField] private float _slideDrag;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundDrag;

    private StateController _stateController;

    private Rigidbody _PlayerRigidbody;


    private float _horizontalInput, _verticalInput;
    private Vector3 _MovemenetDirection;
    private bool _isSliding;
    private void Awake()
    {
        _stateController = GetComponent<StateController>();
        _PlayerRigidbody = GetComponent<Rigidbody>();
        _PlayerRigidbody.freezeRotation = true;
    }
    private void Update()
    {
        SetInputs();
        SetStates();
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

    private void SetStates()
    {
        var movementDirection = GetMovementDirection();
        var isGrounded = IsGrounded();
        var isSliding = IsSliding();
        var currentState = _stateController.GetCurrentState();

        var newState = currentState switch
        {
            _ when movementDirection == Vector3.zero && isGrounded && !isSliding => PlayerState.Idle,
            _ when movementDirection != Vector3.zero && isGrounded && !isSliding => PlayerState.Move,
            _ when movementDirection != Vector3.zero && isGrounded && isSliding => PlayerState.Slide,
            _ when movementDirection == Vector3.zero && isGrounded && isSliding => PlayerState.SlideIdle,
            _ when !_canjump && !isGrounded => PlayerState.Jump,
            _ => currentState
        };

        if (newState != currentState)
        {
            _stateController.ChangeState(newState);
        }
    }

    private void SetPlayerMovement()
    {
        _MovemenetDirection = _OrientationTranform.forward * _verticalInput
        + _OrientationTranform.right * _horizontalInput;

        float forceMultiplier = _stateController.GetCurrentState() switch
        {
            PlayerState.Move => 1f,
            PlayerState.Slide => _slideMultiplier,
            PlayerState.Jump => _airMultiplier,
            _ => 1f
        };

        _PlayerRigidbody.AddForce(_MovemenetDirection.normalized * _movementSpeed * forceMultiplier, ForceMode.Force);
    }

    private void SetPlayerDrag()
    {
        _PlayerRigidbody.linearDamping = _stateController.GetCurrentState() switch
        {
            PlayerState.Move => _groundDrag,
            PlayerState.Slide => _slideDrag,
            PlayerState.Jump => _airDrag,
            _ => _PlayerRigidbody.linearDamping

        };
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

    private Vector3 GetMovementDirection()
    {
        return _MovemenetDirection.normalized;
    }
    private bool IsSliding()
    {
        return _isSliding;
    }





}