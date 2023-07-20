using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Slider _healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        _healthSlider.value = health;   
    }
}
