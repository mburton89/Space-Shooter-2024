using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button howToPlayButton;
    public Button gotItButton;

    public GameObject howToPlayMenu;

    void Start()
    {
        playButton.onClick.AddListener(HandleLevel1Clicked);
        gotItButton.onClick.AddListener(HandleGotItPressed);
        howToPlayButton.onClick.AddListener(HandleHowToPlayPressed);
    }

    void HandleLevel1Clicked()
    {
        SceneManager.LoadScene(1);
    }

    void HandleGotItPressed()
    {
        howToPlayMenu.SetActive(false);
    }

    void HandleHowToPlayPressed()
    {
        howToPlayMenu.SetActive(true);
    }
}
