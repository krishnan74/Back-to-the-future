using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overviewstart : MonoBehaviour
{
    public GameObject ControlPanel;
    public Slider slider;
    public GameObject loadingPanel;
    public GameObject MapOverView;
    private int count;

    void Start()
    {
        count = 0;

        // Delay the activation of the control panel after 126.7 seconds
        float delayInSeconds = 82f;
        Invoke("ActivateControlPanel", delayInSeconds);
    }

    // Function to activate the control panel
    private void ActivateControlPanel()
    {
        ControlPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                MapOverView.SetActive(true);
                ControlPanel.SetActive(false);
                count++;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                MapToGame();
            }
        }
    }

    public void MapToGame()
    {
        slider.value = 0f;
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously("dk"));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
