using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleMovement : MonoBehaviour
{
    public float Speed;
    public float destroyThreshold = 0.1f;
    private float targetX;




    private void Start()
    {
        targetX = -10.16f;
    }

    private void Update()
    {
        transform.position -= Vector3.right * Speed * Time.deltaTime;


        if (Mathf.Abs(transform.position.x - targetX) < destroyThreshold)
        {
            Destroy(gameObject);
        }


    }

}
