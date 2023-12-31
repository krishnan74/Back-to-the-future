using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FlowControllerlast; 

public class GameChanges : MonoBehaviour
{

    public Slider slider;
    public Text numberText;
    public Text scoreText;
    public SpriteRenderer spriteRendererPlayer;
    public float red;

    public Slider powerSlider;
    public float DamagePoints0;
    public float DamagePoints1;
    public float DamagePoints2;
    public float DamagePoints3;
    public float healthIncrementByPoints0;
    public float healthIncrementByPoints1;
    public float healthIncrementByPoints2;
    public float healthIncrementByPoints3;

    public float healthIncrementAuto0;
    public float healthIncrementAuto1;
    public float healthIncrementAuto2;
    public float healthIncrementAuto3;
     private void Start()
    {
        Time.timeScale = 1;
        PauseGame.isPaused = false;
        transform.position = StateManager.LastPosition;

    }


    public void TakeDamage()
{
    if (StateManager.lessDamageFromEnemy == 0)
    {
        slider.value -= (DamagePoints0 / 10000);
    }
    else if (StateManager.lessDamageFromEnemy == 1)
    {
        slider.value -= (DamagePoints1 / 10000);
    }
    else if (StateManager.lessDamageFromEnemy == 2)
    {
        slider.value -= (DamagePoints2 / 10000);
    }
    else if (StateManager.lessDamageFromEnemy == 3)
    {
        slider.value -= (DamagePoints3 / 10000);
    }

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
       if (!PauseGame.isPaused && !Interactable.inShop)
    {
        if (StateManager.increasedHealthIncrementAuto == 0)
        {
            slider.value += (healthIncrementAuto0 / 10000);
        }
        else if (StateManager.increasedHealthIncrementAuto == 1)
        {
            slider.value += (healthIncrementAuto1 / 10000);
        }
        else if (StateManager.increasedHealthIncrementAuto == 2)
        {
            slider.value += (healthIncrementAuto2 / 10000);
        }
        else if (StateManager.increasedHealthIncrementAuto == 3)
        {
            slider.value += (healthIncrementAuto3 / 10000);
        }
    }

    numberText.text = StateManager.plutoCount.ToString();
    scoreText.text = StateManager.plutoCount.ToString();



        StateManager.LastPosition = transform.position;

    }



    public void Increment(){
        if(StateManager.increasedPlutoFromEnemy == 0){
            StateManager.plutoCount+=1;
        }
        else if(StateManager.increasedPlutoFromEnemy == 1){
            StateManager.plutoCount+=2;
        }
        else if(StateManager.increasedPlutoFromEnemy == 2){
            StateManager.plutoCount += 4;
        }
        else if(StateManager.increasedPlutoFromEnemy == 3){
            StateManager.plutoCount += 8;
        }

        

        
            numberText.text = StateManager.plutoCount.ToString();
            scoreText.text = StateManager.plutoCount.ToString();
        
        
    }

    public void EnemyPlutoIncrement(){
        if(StateManager.increasedPlutoFromEnemy == 0){
            StateManager.plutoCount+=5;
        }
        else if(StateManager.increasedPlutoFromEnemy == 1){
            StateManager.plutoCount+=10;
        }
        else if(StateManager.increasedPlutoFromEnemy == 2){
            StateManager.plutoCount += 15;
        }
        else if(StateManager.increasedPlutoFromEnemy == 3){
            StateManager.plutoCount += 20;
        }
        numberText.text = StateManager.plutoCount.ToString();
        scoreText.text = StateManager.plutoCount.ToString();
    }

    public void HealthIncrement()
{
    if (StateManager.increasedHealthIncrementCollect == 0)
    {
        slider.value += (healthIncrementByPoints0 / 10000);
    }
    else if (StateManager.increasedHealthIncrementCollect == 1)
    {
        slider.value += (healthIncrementByPoints1 / 10000);
    }
    else if (StateManager.increasedHealthIncrementCollect == 2)
    {
        slider.value += (healthIncrementByPoints2 / 10000);
    }
    else if (StateManager.increasedHealthIncrementCollect == 3)
    {
        slider.value += (healthIncrementByPoints3 / 10000);
    }
}

       

    // Update is called once per fra
}
