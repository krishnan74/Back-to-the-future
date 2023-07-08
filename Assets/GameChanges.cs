using UnityEngine;
using UnityEngine.UI;


public class GameChanges : MonoBehaviour
{
    public Slider slider;
    public float DamagePoints;
    public int plutoCount = 0;
    public Text numberText;
    public Text scoreText;

    public float healthIncrementByPoints;
    public float healthIncrementAuto;

    public void TakeDamage()
    {
         slider.value -= (DamagePoints/1000);
    }

    private void Update()
    {
        slider.value += (healthIncrementAuto/1000);

        
    
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
