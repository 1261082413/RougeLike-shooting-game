using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public float moveSpeed;
    public Transform target;

    public Vector2 minCameraPos; // Minimum camera position
    public Vector2 maxCameraPos; // Maximum camera position

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (target != null)
        {
            // Interpolate the camera's position towards the target's position
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // Clamp the camera's x and y position to keep it within the defined bounds
            float clampedX = Mathf.Clamp(smoothedPos.x, minCameraPos.x, maxCameraPos.x);
            float clampedY = Mathf.Clamp(smoothedPos.y, minCameraPos.y, maxCameraPos.y);

            // Set the camera's position to the clamped position
            transform.position = new Vector3(clampedX, clampedY, smoothedPos.z);
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
