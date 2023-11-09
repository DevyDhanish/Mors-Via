using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float smoothTime = 0.1f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    private float smoothX = 0.0f; // smoothed rotation around the right/x axis
    private float smoothY = 0.0f; // smoothed rotation around the up/y axis
    private Vector2 currentRotationVelocity;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        float mouseX = -InputBindings.Instance.cameraVectorAxis.y;
        float mouseY = InputBindings.Instance.cameraVectorAxis.x;

        // Smooth the inputs using Mathf.SmoothDamp
        smoothX = Mathf.SmoothDamp(smoothX, mouseX * mouseSensitivity, ref currentRotationVelocity.x, smoothTime);
        smoothY = Mathf.SmoothDamp(smoothY, mouseY * mouseSensitivity, ref currentRotationVelocity.y, smoothTime);

        rotX += smoothX * Time.deltaTime;
        rotY += smoothY * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
