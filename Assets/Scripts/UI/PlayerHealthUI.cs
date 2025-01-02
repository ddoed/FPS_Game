using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("Health Bar")]
    private float health;
    public float maxHealth = 100;
    private float minHealth = 0;
    public Image BG;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        health = maxHealth;
        healthText.text = "";
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        BG.fillAmount = health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }

    public void TakeDamage(float damage)
    {
        if (health > minHealth)
        {
            health -= damage;
        }
    }

    public void RestoreHealth(float healAmount)
    {
        if(health < maxHealth)
        {
            health += healAmount;
        }    
    }
}
