using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersonalizationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject currentUser = GameObject.Find("CurrentUser");
        PatientInfo patientInfo = currentUser.GetComponent<PatientUser>().myInfo;

        // Open the folder containing the images
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        folder = Path.Combine(folder, patientInfo.patientID);
        
        //Find all the images

        //Display images in idk a grid ??
    }
    
}
