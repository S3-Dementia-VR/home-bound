
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class test_script : MonoBehaviour
{
    public GameObject obj;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        string folder = Path.Combine(Application.persistentDataPath, "saves");
        folder = Path.Combine(folder, "20200306_220347818");
        folder = Path.Combine(folder, "map.png");

        Texture2D tex = LoadPNG(folder);
        //rend.material.SetTexture("_source", tex);
        rend.material.mainTexture = tex;
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
}
