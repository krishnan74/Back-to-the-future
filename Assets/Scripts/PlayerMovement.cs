using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;
    Vector3 targetPosition;
    bool isMoving = false;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 currentPos = rbody.position;
            Vector2 movement = (targetPosition - transform.position).normalized * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            isoRenderer.SetDirection(movement,true);
            rbody.MovePosition(newPos);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }  

        else{  
            Vector2 idle = new Vector2(0,0);
            isoRenderer.SetDirection(idle, false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
            isMoving = true;
        }
    }
}
