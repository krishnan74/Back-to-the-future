using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using FlowControllerlast;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject interactPanel; 
    public GameObject minigameloadingPanel;

    public static bool inShop = false;
    public GameObject ShopCanvas;
    public Slider slider;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isInRange = true;
            interactPanel.SetActive(true);

        }
    }

    

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isInRange = false;
            interactPanel.SetActive(false);
        }
    }

    public void EnterFlappyBird(){
        slider.value = 0f; 
        minigameloadingPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously("FlappyBird"));
    }

    public void EnterPlatformer(){
        slider.value = 0f; 
        minigameloadingPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously("Platformer"));
    }

    public void EnterEndScene(){
        if(StateManager.plutoCount > 1000){
            slider.value = 0f; 
            minigameloadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("end-scene"));
        }
        
    }

    IEnumerator LoadAsynchronously(string sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while(!operation.isDone){  
            float progress = Mathf.Clamp01(operation.progress / .9f); 
            slider.value = progress;
            yield return null; 
        }
    }

    public void EnterShop()
    {
        Time.timeScale = 0;
        inShop = true;
        ShopCanvas.SetActive(true);

        // Optionally, you can add additional pause logic here
    }

    public void ExitShop()
    {
        Time.timeScale = 1;
        inShop = false;
        ShopCanvas.SetActive(false);

        // Optionally, you can add additional resume logic here
    }


}
