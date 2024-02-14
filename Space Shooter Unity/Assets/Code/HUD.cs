using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;
    public TextMeshProUGUI waveText;

    void Awake()
    {
        Instance = this;
    }

    public void DisplayHealth(int currentHealth, int maxHealth)
    { 
        float healthAmount = (float)currentHealth / (float)maxHealth;
        healthBarFill.fillAmount = healthAmount;
    }

    public void DisplayWave(int currentWave)
    {
        waveText.SetText("Wave " + currentWave);
    }
}
