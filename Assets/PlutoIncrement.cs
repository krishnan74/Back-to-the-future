using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlutoIncrement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public int plutoCount = 0;
    public Text numberText;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Pluto").transform;
    }

    private void Update()
    {
        numberText.text = plutoCount.ToString();
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < 2f)
        {
                    
            Debug.Log("COin Collected");            
        }
    }
}
