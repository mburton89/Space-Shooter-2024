using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSender : MonoBehaviour
{
    public GameManager GameManager;
    private Slider slider;
    public float rateOfRecovery = 0.00005f;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.dashBarValue;
        

        if(GameManager.dashBarValue <= 1)
        {
            slider.value += rateOfRecovery;
            GameManager.dashBarValue = slider.value;
        }
    }
}
