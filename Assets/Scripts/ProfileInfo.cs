using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileInfo : MonoBehaviour
{
    public Text lastName = null;
    public Text firstName = null;
    public Text age = null;
    public Text patientID = null;

    private void Start()
    {
        GameObject currentUser = GameObject.Find("CurrentUser");
        PatientInfo patientInfo = currentUser.GetComponent<PatientUser>().myInfo;

        lastName.text = patientInfo.lastName;
        firstName.text = patientInfo.firstName;
        age.text = patientInfo.age;
        patientID.text = patientInfo.patientID;
    }
}
