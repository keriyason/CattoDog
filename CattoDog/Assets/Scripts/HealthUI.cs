using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.maxValue = 3;
        healthSlider.value = 3;
    }

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealth;
    }

    void UpdateHealth(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
