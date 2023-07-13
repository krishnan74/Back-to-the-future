using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlutoCollect : MonoBehaviour
{
     private Transform target;
    public float dieTime;

    private GameChanges obj;
    private float elapsedTime = 0f;
    private bool isDestroyed = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        obj = FindObjectOfType<GameChanges>();
    }

    private void Update()
    {
        if (!isDestroyed)
        {
            elapsedTime += Time.deltaTime;

            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < 2f)
            {
                obj.Increment();
                isDestroyed = true;
                Destroy(gameObject);
            }
            else if (elapsedTime >= dieTime)
            {
                isDestroyed = true;
                Destroy(gameObject);
            }
        }

        // Other update logic here
        // This code will continue to execute even after the object is destroyed
    }
}
