using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Cycle : MonoBehaviour
{
    public float dayLength = 10.0f;
    public float nightLength = 10.0f;
    public Color dayColor = new Color(1.0f, 1.0f, 1.0f);
    public Color nightColor = new Color(0.25f, 0.25f, 0.6f);
    public TextMeshProUGUI timeDisplay;
    public Light2D light2D;
    public bool daytime;
    public float timeRemaining;
    public float t = 0;

    void Update()
    {
        timeDisplay.text = Mathf.Round(timeRemaining).ToString();
        timeRemaining -= Time.deltaTime;
        light2D.color = Color.Lerp(nightColor, dayColor, Mathf.PingPong(Time.time, dayLength));
        if (timeRemaining <= 0)
        {
            daytime = !daytime;
            if (daytime)
            {
                //light2D.color = dayColor;
                timeRemaining = dayLength;
            }
            else
            {
                //light2D.color = nightColor;
                timeRemaining = nightLength;
            }
        }
    }
}
