using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    public string _patientID;
    private PatientUser _patient;

    private void Awake()
    {
        _patient = GameObject.FindObjectOfType<PatientUser>();
        Debug.Log("Current Patient - " + _patient.myInfo.patientID);
        //Save();
    }

    /*
     * called in add_new_profile.unity
     * takes form data and generates a patient ID
     */
    public void CreateNewSave()
    {
        GameObject profileForm = GameObject.Find("New Profile Form");

        // get data from form
        InputField lastName = profileForm.transform.Find("LastName/Input").gameObject.GetComponent<InputField>();
        InputField firstName = profileForm.transform.Find("FirstName/Input").gameObject.GetComponent<InputField>();
        InputField age = profileForm.transform.Find("Age/Input").gameObject.GetComponent<InputField>();

        // Generate Patient ID
        string patientID = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");// + lastName.text.GetHashCode();


        PatientInfo patientInfo = new PatientInfo();

        patientInfo.lastName = lastName.text;
        patientInfo.firstName = firstName.text;
        patientInfo.age = age.text;
        patientInfo.patientID = patientID;

        _patient = gameObject.AddComponent(typeof(PatientUser)) as PatientUser;
        _patient.myInfo = patientInfo;

        Save();
        //Debug.Log(patientID);
    }

    /*
     * called in edit_profile.unity
     * takes form data and saves it to the existing save.dat associated to the patient ID
     */
    public PatientInfo SaveEditedProfile()
    {
        GameObject profileForm = GameObject.Find("Edit Profile Form");

        // get data from form
        InputField lastName = profileForm.transform.Find("LastName/Input").gameObject.GetComponent<InputField>();
        InputField firstName = profileForm.transform.Find("FirstName/Input").gameObject.GetComponent<InputField>();
        InputField age = profileForm.transform.Find("Age/Input").gameObject.GetComponent<InputField>();

        string patientID = GameObject.Find("PatientID/Text").GetComponent<Text>().text;

        PatientInfo patientInfo = new PatientInfo();

        patientInfo.lastName = lastName.text;
        patientInfo.firstName = firstName.text;
        patientInfo.age = age.text;
        patientInfo.patientID = patientID;

        _patient = gameObject.AddComponent(typeof(PatientUser)) as PatientUser;
        _patient.myInfo = patientInfo;

        Save();

        return _patient.myInfo;
    }

    // Creates the save folder sand save.dat
    public void Save() {

        // Create/Open the file where we save to
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        if (!Directory.Exists(folder)) {
            Directory.CreateDirectory(folder);
        }

        folder = Path.Combine(folder, _patient.myInfo.patientID);

        if (!Directory.Exists(folder)) {
            Directory.CreateDirectory(folder);
        }

        FileStream file = new FileStream(folder + "/save.dat", FileMode.OpenOrCreate);

        try
        {
            // Binary formatter - allows us to write data to the file
            BinaryFormatter formatter = new BinaryFormatter();
            // Serialization method to write to write data to the file
            formatter.Serialize(file, _patient.myInfo);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Issue with serializing data: " + e.Message);
        }
        finally {
            file.Close();
        }
        
        Debug.Log("Save done - " + _patient.myInfo.patientID);
    }

    // used to load the PatientInfo stored in save.dat
    public void Load() {
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        folder = Path.Combine(folder, _patientID);

        FileStream file = new FileStream(folder + "/save.dat", FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            _patient.myInfo = formatter.Deserialize(file) as PatientInfo;
        }
        catch (SerializationException e)
        {
            Debug.LogError("Issue with deserializing data: " + e.Message);
        }
        finally
        {
            file.Close();
        }

        Debug.Log("Load done - " + _patient.myInfo.patientID);
    }

    /*
     * Used in main_menu.unity (called by ProfileManager.cs)
     * Does the same as Load(), but takes in a patientID input
     * and explicitly returns a PatientInfo object
     */
    public PatientInfo LoadInfo(string patientID) {
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        folder = Path.Combine(folder, patientID);

        FileStream file = new FileStream(folder + "/save.dat", FileMode.Open);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            _patient.myInfo = formatter.Deserialize(file) as PatientInfo;
        }
        catch (SerializationException e)
        {
            Debug.LogError("Issue with deserializing data: " + e.Message);
        }
        finally
        {
            file.Close();
        }

        Debug.Log("Load done - " + _patient.myInfo.patientID);

        return _patient.myInfo;
    }

    /*
     * can be called in user_profile.unity
     * used to delete the save folder and its contents
     */
    public void DeleteSave()
    {
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        folder = Path.Combine(folder, _patient.myInfo.patientID);

        Debug.Log("Deleting - "+ folder);
        if (Directory.Exists(folder))
        {
            Directory.Delete(folder, true);
        }
    }
}
