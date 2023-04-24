using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stat_timer_script : MonoBehaviour
{
    public TMP_Text timeDisplay;

    public float livingTime;
    public float diningTime;
    public float gardenTime;

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        timeDisplay.text = "Living room: " + Mathf.RoundToInt(livingTime) + "s \n Dining room: " + Mathf.RoundToInt(diningTime) + "s \n Garden room: " + Mathf.RoundToInt(gardenTime) + "s";
    }
}
