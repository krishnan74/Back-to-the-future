using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public string tagToDestroy;

    private void OnBecameInvisible()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
