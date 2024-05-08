using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;

    int points;
    public TextMeshProUGUI pointsText;

    void Awake()
    {
        Instance = this;
    }

    public void DisplayHealth(int currentHealth, int maxHealth)
    { 
        float healthAmount = (float)currentHealth / (float)maxHealth;
        healthBarFill.fillAmount = healthAmount;
    }

    public void AddPoint(int pointsToGive)
    {
        points += pointsToGive;

        pointsText.SetText("Points: " + points);
    }
}
