using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Bar")]
    public Image BG;
    [SerializeField] public float health;
    public float maxHealth = 100;
    public float minHealth = 0;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health == 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                PlayerHealthUI playerHealthUI = player.GetComponent<PlayerHealthUI>();
                if (playerHealthUI != null)
                {
                    playerHealthUI.UpdateScore();  // 플레이어 점수 10점 증가
                }
            }
            Destroy(gameObject);
        }
        else
        {
            health = Mathf.Clamp(health, 0, maxHealth);
            UpdateHealthUI();
        }
    }

    public void UpdateHealthUI()
    {
        BG.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (health > minHealth)
        {
            health -= damage;
        }
    }
}
