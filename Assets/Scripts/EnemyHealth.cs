using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
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
            Destroy(gameObject);
        }
        else
            health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (health > minHealth)
        {
            health -= damage;
        }
    }
}
