using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flow;
using Flow.Unity;


public class FlowController : MonoBehaviour
{

    private FlowClient client;
    private string nodeUrl = "access.devnet.nodes.onflow.org:9000"; // Replace with the desired network URL

    private void Start()
    {
        client = new FlowClient();
        client.SetAccessNode(nodeUrl);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
