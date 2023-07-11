using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Reference to the character's transform
    public Vector3 offset;          // Offset from the character's position
    private WASD_movement wasdMovement; // Reference to the WASD_movement script

    void Start()
    {
        wasdMovement = target.GetComponent<WASD_movement>(); // Get the WASD_movement component from the target
    }

    void LateUpdate()
    {
        // if(wasdMovement.isDashing){
        //     return ;
        // }
        // Check if the target is assigned and if the character is not dashing
        if (target != null)
        {
            // Update the camera position to follow the character with the offset
            transform.position = target.position + offset;
        }
    }
}
