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
    public Button gotItButton;
    public Button howToPlayButton;
    //public TextMeshProUGUI highestWaveText;

    public GameObject howToPlayMenu;
    void Start()
    {
        level1Button.onClick.AddListener(HandleLevel1Clicked);
        level2Button.onClick.AddListener(HandleLevel2Clicked);
        level3Button.onClick.AddListener(HandleLevel3Clicked);
        howToPlayButton.onClick.AddListener(HandleHowToPlayClicked);

     // if (PlayerPrefs.GetInt("HasPlayed") != 1)
    //  {
     //        PlayerPrefs.SetInt("HasPlayed", 1);
     //        howToPlayMenu.SetActive(true);
     //        gotItButton.onClick.AddListener(HandleGotItPressed);
     // }
     // else 
     // { 
       //     Destroy(howToPlayMenu);
      //}

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

    void HandleHowToPlayClicked()
    {
        howToPlayMenu.SetActive(true);
        gotItButton.onClick.AddListener(HandleGotItPressed);
    }

    void HandleGotItPressed()
    {
        howToPlayMenu.SetActive(false);
    }
}
