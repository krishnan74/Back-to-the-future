using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlowControllerlast
{
    public class MenuScript : MonoBehaviour
    {
        public Slider slider;
        public string SceneName;
        public GameObject loadingPanel;
        private GameController gameController;
        // Start is called before the first frame update

        private void Awake()
        {
            gameController = GetComponent<GameController>();

        }
        public void PlayGame()
        {
            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously(SceneName));
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

        public void MenuNewGame()
        {
            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("intro-cutscene"));
        }

        public void MenuLoadGame()
        {
            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("dk"));
        }

        public void MenuExitGame()
        {
            Application.Quit();
        }
        public void ExitGame()
        {

            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("Menu"));
        }

        public void ExitMiniGame()
        {
            if (gameController != null)
            {
                gameController.UpdatePlutonium();
            }

        }

        public void ExitShop()
        {

            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("dk"));
        }

        public void PlatformerGame()
        {
            slider.value = 0f;
            loadingPanel.SetActive(true);
            StartCoroutine(LoadAsynchronously("Platformer"));
        }

        public void PlatformerExitGame()
        {

            if (gameController != null)
            {
                gameController.UpdatePlutonium();
            }
            
        }

    }
}