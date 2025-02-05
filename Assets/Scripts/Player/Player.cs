using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerController _controller;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _controller = GetComponent<PlayerController>();
        _mainCamera = GetComponentInChildren<Camera>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _controller.Initialization(_rigidbody, _speed, _sensitivity);
    }

    private void FixedUpdate()
    {
        UpdatePlayerControls();
    }

    private void UpdatePlayerControls()
    {
        _controller.Movement();
        _controller.CameraRotation(_mainCamera);
    }
}
