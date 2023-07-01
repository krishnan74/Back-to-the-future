using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_move : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector3 mouseScreenPosition = Input.mousePosition;

            // Convert the screen position to world coordinates in the z-plane
            mouseScreenPosition.z = -Camera.main.transform.position.z;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            // Print the mouse world position to the console
            Debug.Log("Mouse Position: " + mouseWorldPosition);
      
        } 
    } 

    
}
