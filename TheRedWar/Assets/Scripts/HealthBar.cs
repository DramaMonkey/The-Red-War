using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth playerHealthValue;

    private void Start()
    {
        playerHealthValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealthValue.maxHealth;
        healthBar.value = playerHealthValue.maxHealth;
    }

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}