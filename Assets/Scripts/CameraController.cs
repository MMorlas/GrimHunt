using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 mouseAxis;
    private Transform cameraTransform;
    private Quaternion cameraRotation;

    private Transform playerTransform;
    private Quaternion playerRotation;

    public bool smooth;

    public float minAngle = -70;
    public float maxAngle = 70;

    public float smoothTime;

    //mouse axis Y -> rot X cam
    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraRotation = cameraTransform.localRotation;

        playerTransform = transform;
        playerRotation = playerTransform.localRotation;
    }

    private void Update()
    {
        cameraRotation *= Quaternion.Euler(-mouseAxis.y, 0, 0);
        playerRotation *= Quaternion.Euler(0, mouseAxis.x, 0);

        cameraRotation = ClampRotationAroundXAxis(cameraRotation);

        if (smooth)
        {
            cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, cameraRotation, Time.deltaTime * smoothTime);
            playerTransform.localRotation = Quaternion.Slerp(playerTransform.localRotation, playerRotation, Time.deltaTime * smoothTime);
        }
        else
        {
            cameraTransform.localRotation = cameraRotation;
            playerTransform.localRotation = playerRotation;
        }
    }

    public void SetAxis(Vector2 inputAxis)
    {
        mouseAxis = inputAxis;
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, minAngle, maxAngle);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

}
