using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image healthBarFill;
    public Image dashBarFill;

    int points;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsText2;

    public GameObject winMenu;

    public Button mainButton;
    public Button retryButton;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainButton.onClick.AddListener(LoadMainMenu);
        retryButton.onClick.AddListener(Retry);
    }

    public void DisplayHealth(int currentHealth, int maxHealth)
    { 
        float healthAmount = (float)currentHealth / (float)maxHealth;
        healthBarFill.fillAmount = healthAmount;
    }

    public void AddPoint(int pointsToGive)
    {
        points += pointsToGive;

        pointsText.SetText(points.ToString());
    }

    public void DisplayDashAmount(float currentDash, float maxDash)
    {
        float dashAmount = (float)currentDash / (float)maxDash;
        dashBarFill.fillAmount = dashAmount;
    }

    public void WinLevel()
    {
        winMenu.transform.localScale = Vector3.one;
        pointsText2.SetText(points.ToString());
        Time.timeScale = 0;
    }

    void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
