using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image background;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        background.color = gradient.Evaluate(1);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        background.color = gradient.Evaluate(slider.normalizedValue);
        if(health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
