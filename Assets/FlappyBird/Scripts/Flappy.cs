using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    public GameObject GameOverScreen;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private float destroyThreshold = 0.1f;

    bool isActive = true;
    public float targetXup;
    public float targetXdown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            Jump();
        }

        if (Mathf.Abs(transform.position.y - targetXup) < destroyThreshold)
        {   isActive = false;
            GameOverScreen.SetActive(true);
        }

        if (Mathf.Abs(transform.position.y - targetXdown) < destroyThreshold)
        {   isActive = false;
            GameOverScreen.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FlappyObstacle"))
        {
            isActive = false;
            GameOverScreen.SetActive(true);
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
