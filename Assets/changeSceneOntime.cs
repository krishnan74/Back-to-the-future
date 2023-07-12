using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class changeSceneOntime : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

    void Start()
    {
        StartCoroutine(changeSceneOnT());
    }

    private IEnumerator changeSceneOnT()
    {
        yield return new WaitForSeconds(changeTime);
        SceneManager.LoadScene(sceneName);
    }

}
