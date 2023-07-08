using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private GameChanges obj; // Reference to the GameChanges script

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        obj = FindObjectOfType<GameChanges>(); // Find the GameChanges script component
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < 2f)
        {
            obj.HealthIncrement(); // Call the Increment() function from the GameChanges script
            Destroy(gameObject);
        }
    }
}
