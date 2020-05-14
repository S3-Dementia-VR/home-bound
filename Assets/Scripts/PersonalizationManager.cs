using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PersonalizationManager : MonoBehaviour
{
    Vector3[] pos;
    //public GameObject[] obj;

    public Text folderLocation;

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject imageItem = null;

    [SerializeField]
    private RectTransform content = null;
    
    void Start()
    {
        // Get the current user
        GameObject currentUser = GameObject.Find("CurrentUser");
        PatientInfo patientInfo = currentUser.GetComponent<PatientUser>().myInfo;


        // Open the folder containing the images
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        folder = Path.Combine(folder, patientInfo.patientID);

        // Display location of image files
        folderLocation.text = folder;

        // Find all pictures in the folder
        var filters = new String[] { "jpg", "jpeg", "png" };
        var files = GetFilesFrom(folder, filters, false);

        int total_num_of_pics = files.Length;

        // how many pictures per row
        int row_num = 3;
        int row_ctr = 0;

        //
        float image_width = (content.rect.width / row_num) - (5*row_num);
        Debug.Log(content.rect.width);
        Debug.Log(image_width);
        float content_height = content.rect.height;

        // Display images in a grid
        for (int i = 0; i < total_num_of_pics; i++)
        {
            Texture2D tex = LoadPNG(files[i]);
            //pos = new Vector3[obj.Length];

            // width of image prefab
            float spawnY = i * 100;
            float spawnX = row_ctr * 100;

            //newSpawn Position
            //Vector3 pos = new Vector3(5+spawnX, -spawnY, SpawnPoint.position.z);
            Vector3 pos = new Vector3(0,0,0);

            //pos[0] = new Vector3(transform.position.x + i * 100, transform.position.y - i, transform.position.z);
            //pos[1] = new Vector3(transform.position.x + i, transform.position.y - 1, transform.position.z);
            //pos[2] = new Vector3(transform.position.x + i, transform.position.y - 2, transform.position.z);
            //pos[3] = new Vector3(transform.position.x + i, transform.position.y - 3, transform.position.z);
            //etc...


            //instantiate item
            GameObject SpawnedItem = Instantiate(imageItem, pos, SpawnPoint.rotation);
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //SpawnedItem.transform.localScale = new Vector3(300/100, 200/100, 1.0f);


            SpawnedItem.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2());

            //Instantiate(obj[i], pos[0], transform.rotation);
            //Instantiate(obj[i], pos[1], transform.rotation);
            //Instantiate(obj[i], pos[2], transform.rotation);
            //Instantiate(obj[i], pos[3], transform.rotation);
            //etc...

            row_ctr++;
            if (row_ctr > row_num)
            {
                row_ctr = 0;
            }
        }
    }

    public static Texture2D LoadPNG(string filePath)
    {
        Debug.Log("Load PNG - " + filePath);
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
    {
        List<String> filesFound = new List<String>();
        var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        foreach (var filter in filters)
        {
            filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));

        }
        return filesFound.ToArray();
    }
}
