using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameChanges : MonoBehaviour
{
    public Slider slider;
    public float DamagePoints;
    public int plutoCount = 0;
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
        
        
    }



    public void Increment(){
        plutoCount++;
        numberText.text = plutoCount.ToString();
        scoreText.text = plutoCount.ToString();
    }

    public void HealthIncrement(){
        slider.value += (healthIncrementByPoints/1000);
    }
       

    // Update is called once per fra
}
