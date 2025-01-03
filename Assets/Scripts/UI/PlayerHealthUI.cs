using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("Health Bar")]
    private float health;
    public float maxHealth = 100;
    private float minHealth = 0;
    public Image BG;
    public TextMeshProUGUI healthText;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public int score = 0;

    [Header("GameOver")]
    public GameObject gameOverImage;

    private void Start()
    {
        health = maxHealth;
        healthText.text = "";
        gameOverImage.SetActive(false); // ���� ���� UI ��Ȱ��ȭ
        Time.timeScale = 1f; // �ð� �ʱ�ȭ
    }

    private void Update()
    {
        if(health == 0)
        {
            gameOverImage.SetActive(true);
            Time.timeScale = 0f;
        }
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        scoreText.text = $"Gold  {score}";
    }

    public void UpdateScore()
    {
        score += 10;
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

    public void DecreaseCoin(int coin)
    {
        if (coin <= score)
        {
            score -= coin;
        }
    }

    public void QuitGame()
    {
        Debug.Log("���� ����"); // Unity �����Ϳ��� �α׷� Ȯ��
        Application.Quit();    // ����� ���ӿ��� ���ø����̼� ����
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // �ð��� �ٽ� �������� ����
        ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �ٽ� �ε�

        // �ʱ�ȭ�� �ʿ��� ���
        
    }

    // �ʱ�ȭ �޼���
    public void ResetGame()
    {
        health = maxHealth; // ü�� �ʱ�ȭ
    }
}
