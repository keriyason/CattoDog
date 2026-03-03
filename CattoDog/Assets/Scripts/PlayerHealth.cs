using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int maxHealth = 3;
    private int currentHealth;

    public static event Action<int> OnHealthChanged;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       
        DeathUI.Instance.ShowDeathScreen();
        Debug.Log("Trying to show death screen");
    }
}
