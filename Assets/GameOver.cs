using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Slider slider;
    public GameObject GameOverPanel;
    public GameObject PlayerHealth;


    // Update is called once per frame
    void Update()
    {

        if (slider.value == 0f)
        {
            Time.timeScale = 0;
            PlayerHealth.SetActive(false);
            GameOverPanel.SetActive(true); // Activate the game object
        }
    }
}
