using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Camera Settings")]
    [Space]
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private float _sensitivity;

    [Header("Movement Settings")]
    [Space]

    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private PlayerController _controller;

    [Header("FootStepsSounds")]

    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private  AudioSource _stepsAudioSource;
    [SerializeField] private SoundManager _soundManager;

    private void Awake()
    {
        _mainCamera = GetComponentInChildren<Camera>();

        _rigidbody = GetComponent<Rigidbody>();
        _controller = GetComponent<PlayerController>();

        _playerAudioSource = GetComponent<AudioSource>();
        _stepsAudioSource = GetComponentInChildren<AudioSource>();

        _soundManager = FindFirstObjectByType<SoundManager>();

        _controller.Initialization(_rigidbody, _playerAudioSource, _stepsAudioSource, _soundManager, _speed, _sensitivity);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        _controller.Movement();
    }
    private void Update()
    {
        _controller.CameraRotation(_mainCamera);       
    }
}
