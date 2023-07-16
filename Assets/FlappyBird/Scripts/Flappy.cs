using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject StartScreen;
    public static bool isGameOver;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private float destroyThreshold = 0.5f;

    public float targetXup;
    public float targetXdown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
        isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            StartScreen.SetActive(false);

            Jump();
            
        }

        if (Mathf.Abs(transform.position.y - targetXup) < destroyThreshold)
        {   
            isGameOver = true;
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (Mathf.Abs(transform.position.y + targetXdown) < destroyThreshold)
        {   
            isGameOver = true;
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FlappyObstacle"))
        {
            isGameOver = true;
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

}
