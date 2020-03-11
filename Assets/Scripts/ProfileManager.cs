using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    [SerializeField]
    private List<ProfileButtonsInfo> profileInfo;


    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject profileButtonItem = null;

    [SerializeField]
    private RectTransform content = null;

    void Start() {

        // Path where the saves are stored
        string folder = Path.Combine(Application.persistentDataPath, "saves");

        // Get list of saves
        string[] dir = Directory.GetDirectories(folder);
        int total_saves = dir.Length;

        //setContent Holder Height;
        content.sizeDelta = new Vector2(0, total_saves * 70);

        for (int i = 0; i < total_saves; i++)
        {
            // 60 width of item
            float spawnY = i * 70;
            //newSpawn Position
            Vector3 pos = new Vector3(5, -spawnY, SpawnPoint.position.z);
            //instantiate item
            GameObject SpawnedItem = Instantiate(profileButtonItem, pos, SpawnPoint.rotation);
            //setParent
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //get PatientInfo Component
            ProfileButtonsInfo profileInfo = SpawnedItem.GetComponent<ProfileButtonsInfo>();

            PatientInfo info = GameObject.Find("SaveManager").GetComponent<SaveManager>().LoadInfo(dir[i]);

            //set button contents
            profileInfo.lastName.text = info.lastName;
            profileInfo.firstName.text = info.firstName;
            profileInfo.age.text = info.age;
            profileInfo.patientID.text = info.patientID;
        }
    }
}
