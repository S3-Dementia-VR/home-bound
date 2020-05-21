using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = GetComponent<Collider>().bounds.size;
        Debug.Log(size.x);
        Debug.Log(size.y);
        Debug.Log(size.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
