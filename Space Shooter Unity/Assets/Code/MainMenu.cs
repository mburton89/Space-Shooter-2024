using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //You wrote the wrong script, fool!

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    //public TextMeshProUGUI highestWaveText;


    void Start()
    {
        level1Button.onClick.AddListener(HandleLevel1Clicked);
        level2Button.onClick.AddListener(HandleLevel2Clicked);
        level3Button.onClick.AddListener(HandleLevel3Clicked);

        //int highestWave = PlayerPrefs.GetInt("highestWave");
        //highestWaveText.SetText("Highest Wave: " + highestWave);
    }

    void HandleLevel1Clicked()
    {
        SceneManager.LoadScene(1);
    }

    void HandleLevel2Clicked()
    {
        SceneManager.LoadScene(2);
    }

    void HandleLevel3Clicked()
    {
        SceneManager.LoadScene(3);
    }
}
