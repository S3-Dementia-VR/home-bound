using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public GameObject userProfilePrefab;

    [SerializeField]
    private List<ProfileInfo> profileInfo;


    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject profileButtonItem = null;

    [SerializeField]
    private RectTransform content = null;

    public string[] itemNames = null;

    void Start() {

        //setContent Holder Height;
        content.sizeDelta = new Vector2(0, 3 * 60);

        for (int i = 0; i < 5; i++)
        {
            // 60 width of item
            float spawnY = i * 70;
            //newSpawn Position
            Vector3 pos = new Vector3(SpawnPoint.position.x, -spawnY, SpawnPoint.position.z);
            //instantiate item
            GameObject SpawnedItem = Instantiate(profileButtonItem, pos, SpawnPoint.rotation);
            //setParent
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //get PatientInfo Component
            ProfileInfo profileInfo = SpawnedItem.GetComponent<ProfileInfo>();
            //set lastName
            profileInfo.age.text = itemNames[i];

            // go through list of files
            // for each file create the button
        }
    }

    public void showInfo()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    

    
}
