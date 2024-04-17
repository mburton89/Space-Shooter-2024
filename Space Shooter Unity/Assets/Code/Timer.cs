using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeToSunrise = 60.0f;
    public float timeToNextNight = 3.0f;
    public TextMeshProUGUI nighttimeTimer;

    private void Update()
    {
        timeToSunrise -= Time.deltaTime;

        if (timeToSunrise <= 0.0f)
        {
            RoundEnd();
        }
    }

    public void RoundEnd()
    {
        // start timer before next round
        // have bat return to roost in cutscene *TODO*
        
        timeToNextNight -= Time.deltaTime;
        
        if (timeToNextNight <= 0.0f)
        {
            //SceneManager.LoadScene(x);
        }
    }

}
