using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject PauseScreen;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape) && !Flappy.isGameOver)
        {
            if (isPaused)
            {
                ResumeGamefunc();
            }
            else
            {
                PauseGamefunc();
            }
        }
    }


    void PauseGamefunc()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseScreen.SetActive(true);

        // Optionally, you can add additional pause logic here
    }

    public void ResumeGamefunc()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseScreen.SetActive(false);

        // Optionally, you can add additional resume logic here
    }

}
