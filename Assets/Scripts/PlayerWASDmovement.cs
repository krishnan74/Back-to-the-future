using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDmovement : MonoBehaviour
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
            isoRenderer.SetDirection(movement, isMoving);
            rbody.MovePosition(newPos);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
        else
        {
            Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (movementInput.magnitude > 0)
            {
                targetPosition = transform.position + new Vector3(movementInput.x, movementInput.y, 0f);
                isMoving = true;
            }
            else
            {
                Vector2 idle = new Vector2(0, 0);
                isoRenderer.SetDirection(idle, isMoving);
            }
        }
    }
}
