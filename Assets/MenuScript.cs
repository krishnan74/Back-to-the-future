using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Slider slider;
    public GameObject loadingPanel; 
    // Start is called before the first frame update
    public void PlayGame(){

        slider.value = 0f; 
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously("dk"));
    }  

    IEnumerator LoadAsynchronously(string sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while(!operation.isDone){  
            float progress = Mathf.Clamp01(operation.progress / .9f); 
            slider.value = progress;
            yield return null; 
        }
    }

    public void ExitGame(){

        slider.value = 0f; 
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously("Menu"));
    }  

}
