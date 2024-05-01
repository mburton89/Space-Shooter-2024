using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }

    public float fadeInTime;
    public float fadeOutTime;

    public float startFadeOutAfterTime;
    public string sceneToLoadAfterFadeOut;

    public Image fadeImage;

    bool isClassValid = true;

    public Animator anim;


    [HideInInspector]
    public bool transition = false;

    private void Awake ()
    {
        if (Instance != null && Instance != this)
        {
            isClassValid = false;
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start ()
    {

        if (isClassValid)
        {
            fadeImage.gameObject.SetActive(true);

            //Fade();

            if (startFadeOutAfterTime > 0)
            {
                StartCoroutine(StartFadeAfter());
            }
        }
    }


    void Update()
    {
        if (transition && isClassValid)
        {
            Fade();
        }
    }

    public void SetTransition()
    {
        transition = true;
        StartCoroutine(Transition());
    }   

    public void SetNextScene(string sceneName)
    {
        sceneToLoadAfterFadeOut = sceneName;
    }

    public IEnumerator StartFadeAfter ()
    {
        yield return new WaitForSeconds(startFadeOutAfterTime);
        transition = true;
        StartCoroutine(Transition());
        Fade();
    }

    public IEnumerator Transition()
    {

        anim.SetBool("isPlaying", true);

        yield return new WaitForSeconds(fadeOutTime);
        if (sceneToLoadAfterFadeOut == "")
        {
            sceneToLoadAfterFadeOut = SceneManager.GetSceneByBuildIndex(0).name;
        }

        SceneManager.LoadScene(sceneToLoadAfterFadeOut, LoadSceneMode.Single);
        anim.SetBool("isPlaying", false);
    }

    public void Fade()
    {
        float fTime = (transition ? fadeOutTime : fadeInTime);
        float target = (transition ? 1 : 0f);
        transition = false;
        fadeImage.CrossFadeAlpha(target, fTime, false);
    }

    public void QuitApplication()
    {
        StartCoroutine(QuitApplicationInternal());
    }

    IEnumerator QuitApplicationInternal()
    {
        transition = true;
        Time.timeScale = 1;
        yield return new WaitForSeconds(fadeOutTime);
        Debug.Log("Quitting Application");
        Application.Quit();
        
    }


}
