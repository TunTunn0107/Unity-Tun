using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; // The target object the camera will follow
    public float smoothSpeed = 0.8f; // How smoothly the camera catches up with its target movement
    public Vector3 offset; // The offset distance between the camera and the target

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position based on the target's position and the offset
            Vector3 desiredPosition = target.position + offset;
            // Smoothly interpolate between the camera's current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the camera's position
            transform.position = smoothedPosition;

            // Ensure the camera's z position stays constant (useful for 2D games)
            transform.position = new Vector3(transform.position.x, transform.position.y, offset.z);
        }
    }
}
