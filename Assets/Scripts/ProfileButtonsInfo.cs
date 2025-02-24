﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProfileButtonsInfo : MonoBehaviour
{
    public Text lastName = null;
    public Text firstName = null;
    public Text age = null;
    public Text patientID = null;

    private Button myselfButton;

    void Start()
    {
        myselfButton = GetComponent<Button>();
        myselfButton.onClick.AddListener(() => selectProfile());
    }

    public void selectProfile()
    {
        Debug.Log("Loading Profile triggered - " + patientID.text);

        PatientUser currentUser = GameObject.Find("CurrentUser").GetComponent<PatientUser>();
        SaveManager saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        currentUser.myInfo = saveManager.LoadInfo(patientID.text);

        DontDestroyOnLoad(saveManager);
        DontDestroyOnLoad(currentUser);
    }

    void Destroy()
    {
        Debug.Log("Button Destroyed - " + patientID.text);
        myselfButton.onClick.RemoveListener(() => selectProfile());
    }

}
