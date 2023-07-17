using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlowControllerlast; 

public class ScoreIncrement : MonoBehaviour
{
    public Text PauseScoreText;
    public Text GameOverScoreText;
    public Text InGameScoreText;


    private int score = 0;
    public float initialDelay = 2f; // Delay before starting score increment in seconds
    public float interval = 2f; // Time interval between score increments in seconds

    private void Start()
    {
        StartCoroutine(IncrementScore());
    }

    IEnumerator IncrementScore()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            yield return new WaitForSeconds(interval);
            score++;
            StateManager.plutoCount++;
            PauseScoreText.text = score.ToString();
            GameOverScoreText.text = score.ToString();
            InGameScoreText.text = score.ToString();
        }
    }


        

}
