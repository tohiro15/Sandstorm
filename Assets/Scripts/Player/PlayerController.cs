using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;

    private float _sensitivity;
    private float _verticalRotation = 0f;

    private Rigidbody _rb;

    private AudioSource _playerAudioSource;
    private AudioSource _stepsAudioSource;
    private SoundManager _soundManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Initialization(Rigidbody rigidbody, AudioSource playerAudioSource, AudioSource stepsAudioSource, SoundManager soundManager, float speed, float sensitivity)
    {
        _rb = rigidbody;
        if (_rb == null) Debug.Log("Rigidbody - не инициализирован!");

        _playerAudioSource = playerAudioSource;
        _stepsAudioSource = stepsAudioSource;
        _soundManager = soundManager;
        _stepsAudioSource = stepsAudioSource;
        if (_stepsAudioSource == null) Debug.Log("Steps Audio Source - не инициализирован!");
        if (_soundManager == null) Debug.Log("Sound Manager - не инициализирован!");

        _speed = speed;

        _sensitivity = sensitivity;
    }
    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        Vector3 direction = transform.right * moveX + transform.forward * moveZ;

        if (_rb != null)
        {
            _rb.MovePosition(transform.position + direction);
        }
        if (moveX != 0 || moveZ != 0)
        {
           _soundManager.FootStapsSound(_stepsAudioSource);
        }
    }

    public void CameraRotation(Camera camera)
    {
        if (camera == null)
        {
            Debug.LogWarning("Camera is not assigned!");
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
}
