using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeDisplay;

    private TimeSpan timePlaying;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = timePlaying.ToString("mm':'ss");
        timeDisplay.text = timePlayingStr;
    }
}
