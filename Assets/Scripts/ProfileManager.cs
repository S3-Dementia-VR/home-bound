using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public GameObject userProfilePrefab;

    [SerializeField]
    private List<PatientInfo> patientInfo;


    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private int numberOfItems = 3;

    [SerializeField]
    private GameObject item = null;

    [SerializeField]
    private RectTransform content = null;

    public string[] itemNames = null;

    void Start() {

        //setContent Holder Height;
        content.sizeDelta = new Vector2(0, numberOfItems * 60);

        for (int i = 0; i < numberOfItems; i++)
        {
            // 60 width of item
            float spawnY = i * 60;
            //newSpawn Position
            Vector3 pos = new Vector3(SpawnPoint.position.x, -spawnY, SpawnPoint.position.z);
            //instantiate item
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);
            //setParent
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //get PatientInfo Component
            PatientInfo patientInfo = SpawnedItem.GetComponent<PatientInfo>();
            //set lastName
            patientInfo.lastName.text = itemNames[i];


        }
    }

    public void showInfo()
    {
        LastName
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    

    
}
