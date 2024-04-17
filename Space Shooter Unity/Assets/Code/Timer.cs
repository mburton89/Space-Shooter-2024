using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeToSunrise = 80.0f;
    public float timeToNextNight = 3.0f;
    private float rotateZ;

    private void Start()
    {
        rotateZ = -180 / timeToSunrise;
    }

    private void Update()
    {
        // function

        if (timeToSunrise <= 0.0f)
        {
            timeToSunrise -= Time.deltaTime;
            RoundEnd();
        }

        // form
        gameObject.transform.Rotate(0, 0, Time.deltaTime * rotateZ);
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
