using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileManager : MonoBehaviour
{
    // Use these for main_menu - showing list of profiles
    [SerializeField]
    private List<ProfileButtonsInfo> profileInfo;

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject profileButtonItem = null;

    [SerializeField]
    private RectTransform content = null;
    // end

    void Start() {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "main_menu")
        {
            this.showProfileList();
        } else if (sceneName == "edit_profile")
        {
            this.showProfileEditForm();
        }
    }

    public void showProfileList()
    {
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

    public void showProfileEditForm()
    {
        GameObject profileForm = GameObject.Find("Edit Profile Form");
        GameObject currentUser = GameObject.Find("CurrentUser");
        PatientInfo patientInfo = currentUser.GetComponent<PatientUser>().myInfo;

        // put data into the form
        InputField lastName = profileForm.transform.Find("LastName/Input").gameObject.GetComponent<InputField>();
        InputField firstName = profileForm.transform.Find("FirstName/Input").gameObject.GetComponent<InputField>();
        InputField age = profileForm.transform.Find("Age/Input").gameObject.GetComponent<InputField>();
        Text patientID = GameObject.Find("PatientID/Text").GetComponent<Text>();

        lastName.text = patientInfo.lastName;
        firstName.text = patientInfo.firstName;
        age.text = patientInfo.age;
        patientID.text = patientInfo.patientID;
    }
}
