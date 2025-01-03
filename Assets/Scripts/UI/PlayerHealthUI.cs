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
        gameOverImage.SetActive(false); // 게임 오버 UI 비활성화
        Time.timeScale = 1f; // 시간 초기화
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
        Debug.Log("게임 종료"); // Unity 에디터에서 로그로 확인
        Application.Quit();    // 빌드된 게임에서 애플리케이션 종료
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 시간을 다시 정상으로 설정
        ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 다시 로드

        // 초기화가 필요한 경우
        
    }

    // 초기화 메서드
    public void ResetGame()
    {
        health = maxHealth; // 체력 초기화
    }
}
