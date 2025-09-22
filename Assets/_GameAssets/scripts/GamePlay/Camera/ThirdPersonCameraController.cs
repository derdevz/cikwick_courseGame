using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private Transform _playerVisualTransform;

    [Header("SETTINGS")]
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        if (GameManager.Instance.GetCurrentGameState() != GameState.Play
            && GameManager.Instance.GetCurrentGameState() != GameState.Resume)
        {
            return;
            }

        Vector3 wievDirection
        = _playerTransform.position - new Vector3(transform.position.x, _playerTransform.position.y, transform.position.z);

        _orientationTransform.forward = wievDirection.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection
        = _orientationTransform.forward * verticalInput + _orientationTransform.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {
        _playerVisualTransform.forward
        = Vector3.Slerp(_playerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);
        }
    }





}