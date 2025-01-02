using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarUI : MonoBehaviour
{
    [Header("Reload Bar")]
    public float bullet;
    public float maxBullet = 30;
    public float minBullet = 0;
    public Image BG;
    public TextMeshProUGUI reloadBarText;

    private void Start()
    {
        bullet = maxBullet;
        reloadBarText.text = "";
    }

    private void Update()
    {
        bullet = Mathf.Clamp(bullet, 0, maxBullet);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        BG.fillAmount = bullet / maxBullet;
        reloadBarText.text = $"{bullet}/{maxBullet}";
        
    }

    public void DecreaseBullet()
    {
        if (bullet > minBullet)
        {
            bullet--;
        }
    }

    public void Reload()
    {
        if (bullet < maxBullet)
        {
            bullet = maxBullet;
        }
    }
}
