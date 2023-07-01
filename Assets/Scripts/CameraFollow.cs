using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Reference to the character's transform
    public Vector3 offset;          // Offset from the character's position

    void LateUpdate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Update the camera position to follow the character with the offset
            transform.position = target.position + offset;
        }
    }
}
