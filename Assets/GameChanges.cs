using UnityEngine;
using UnityEngine.UI;


public class GameChanges : MonoBehaviour
{
    public Slider slider;
    public float DamagePoints;
    public float HealPoints;


    public void TakeDamage()
    {
         slider.value -= DamagePoints;
    }

    public void PlusHealth()
    {
        slider.value += HealPoints;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            PlusHealth();
        }
    }
}
