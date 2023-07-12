using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class changeSceneOntime : MonoBehaviour
{

    public Slider slider;
    public GameObject loadingPanel; 
    public float changeTime;
    public string sceneName;

    void Start()
    {
        slider.value = 0f; 
        StartCoroutine(LoadAsynchronously(sceneName));
    }


    IEnumerator LoadAsynchronously(string sceneName){
        yield return new WaitForSeconds(changeTime);
        
        loadingPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while(!operation.isDone){  
            float progress = Mathf.Clamp01(operation.progress / .9f); 
            slider.value = progress;
            yield return null; 
        }
    }

}
