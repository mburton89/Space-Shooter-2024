using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI highestWaveText;

    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);

        int highestWave = PlayerPrefs.GetInt("highestWave");
        highestWaveText.SetText("Highest Wave: " + highestWave);
    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
