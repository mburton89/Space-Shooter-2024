using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessOverlay : MonoBehaviour
{
    public static DarknessOverlay Instance;

    public float fadeInSpeed = 0.05f; // Adjust the speed of fading as needed
    private Image image;
    public float targetAlpha = 0.6f;

    void Start()
    {
        Instance = this;
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    void Update()
    {
        float currentAlpha = image.color.a;
        float newAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, fadeInSpeed * Time.deltaTime);
        image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);

        //if (Mathf.Approximately(newAlpha, targetAlpha))
        //{
        //    enabled = false;
        //}
    }

    public void Reset()
    {
        image.color = Color.clear;
    }
}
