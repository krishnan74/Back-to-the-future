using UnityEngine;
using UnityEngine.UI;
using System.Collections;


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
        numberText.text = StateManager.plutoCount.ToString();
        scoreText.text = StateManager.plutoCount.ToString();
        transform.position = StateManager.LastPosition;

    }


    public void TakeDamage()
    {
        switch(StateManager.lessDamageFromEnemy) 
        {
        case 0:
            slider.value -= (DamagePoints0/10000);            
            break;
        case 1:
            slider.value -= (DamagePoints1/10000);
            break;
        case 2:
            slider.value -= (DamagePoints2/10000);
            break;
        case 3:
            slider.value -= (DamagePoints3/10000);
            break;
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
        if(!PauseGame.isPaused){
            switch(StateManager.increasedHealthIncrementAuto) 
            {
            case 0:
                slider.value += (healthIncrementAuto0/10000);            
                break;
            case 1:
                slider.value += (healthIncrementAuto1/10000);
                break;
            case 2:
                slider.value += (healthIncrementAuto2/10000);
                break;
            case 3:
                slider.value += (healthIncrementAuto3/10000);
                break;

            }
            
        }

        

        if(Input.GetKeyDown(KeyCode.O)){
            StateManager.lessDamageFromEnemy += 1;
        }

        if(Input.GetKeyDown(KeyCode.I)){
            StateManager.lessDamageFromEnemy -= 1;
        }

        if(Input.GetKeyDown(KeyCode.M)){
            StateManager.increasedHealthIncrementCollect += 1;
        }

        if(Input.GetKeyDown(KeyCode.N)){
            StateManager.increasedHealthIncrementCollect -= 1;
        }
        if(Input.GetKeyDown(KeyCode.L)){
            StateManager.increasedHealthIncrementAuto += 1;

        }
        

        if(Input.GetKeyDown(KeyCode.K)){
            StateManager.increasedHealthIncrementAuto -= 1;
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

        switch(StateManager.increasedHealthIncrementCollect) 
            {
            case 0:
                slider.value += (healthIncrementByPoints0/10000);            
                break;
            case 1:
                slider.value += (healthIncrementByPoints1/10000);
                break;
            case 2:
                slider.value += (healthIncrementByPoints2/10000);
                break;
            case 3:
                slider.value += (healthIncrementByPoints3/10000);
                break;

            }    }
       

    // Update is called once per fra
}
