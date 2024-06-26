using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float dashBarValue;
    public float points;
    public float mothsGotten;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        StartCoroutine(DelayGameOver());
    }

    private IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}

