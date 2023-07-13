using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameChanges : MonoBehaviour
{
    public Slider slider;
    public float DamagePoints;
    public Text numberText;
    public Text scoreText;
    public SpriteRenderer spriteRendererPlayer;

    public float healthIncrementByPoints;
    public float healthIncrementAuto;
    public float red;

     private void Start()
    {
        Time.timeScale = 1;
        PauseGame.isPaused = false;
        numberText.text = StateManager.plutoCount.ToString();
        scoreText.text = StateManager.plutoCount.ToString();
        transform.position = StateManager.LastPosition;

    }


    public void TakeDamage()
    {
         slider.value -= (DamagePoints/1000);
         spriteRendererPlayer.color = Color.red;
         StartCoroutine(ChangeColorBack());

    }

    private IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(red);
        spriteRendererPlayer.color = Color.white;
    }

    private void Update()
    {
        if(!PauseGame.isPaused){
            slider.value += (healthIncrementAuto/1000);
        }

        StateManager.LastPosition = transform.position;

    }



    public void Increment(){
        StateManager.plutoCount++;
        numberText.text = StateManager.plutoCount.ToString();
        scoreText.text = StateManager.plutoCount.ToString();
    }

    public void EnemyPlutoIncrement(){
        StateManager.plutoCount+=5;
        numberText.text = StateManager.plutoCount.ToString();
        scoreText.text = StateManager.plutoCount.ToString();
    }

    public void HealthIncrement(){
        slider.value += (healthIncrementByPoints/1000);
    }
       

    // Update is called once per fra
}
