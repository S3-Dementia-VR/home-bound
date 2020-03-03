using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    public string filename;
    private PatientUser _patient;

    private void Awake()
    {
        _patient = GameObject.FindObjectOfType<PatientUser>();
        Save();
    }

    public void Save() {
        // Create/Open the file where we save to
        FileStream file = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);

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
        
        Debug.Log("Save done - " + Application.persistentDataPath);
    }

    public void Load() {
        FileStream file = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.Open);
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
    }
}
