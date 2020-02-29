using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public string filename;
    private PatientInfo _patient;

    public void Save() {
        // Create/Open the file where we save to
        FileStream file = new FileStream(Application.persistentDataPath + "/" + filename + ".dat", FileMode.OpenOrCreate);
        // Binary formatter - allows us to write data to the file
        BinaryFormatter formatter = new BinaryFormatter();
        // Serialization method to write to write data to the file
        formatter.Serialize(file, "sdasd");
    }

    public void Load() {

    }
}
