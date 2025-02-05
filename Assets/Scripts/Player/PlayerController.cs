using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;

    private float _sensitivity;
    private float _verticalRotation = 0f;

    private Rigidbody _rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Initialization(Rigidbody rigidbody, float speed, float sensitivity)
    {
        _rb = rigidbody;
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
