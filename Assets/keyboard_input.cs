using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_input : MonoBehaviour
{
    public TMPro.TextMeshPro text;
    public Transform userView;
    public List<Transform> locations;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            text.text = "space!";
            } 
        if (Input.GetKeyDown(KeyCode.Q)) { 
            text.text = "Entrance-Outside"; 
            userView.position = locations[0].transform.position;
            // userView.rotation = locations[0].transform.rotation;
            } 
        if (Input.GetKeyDown(KeyCode.W)) { 
            text.text = "Entrance-Inside";   
            userView.position = locations[1].transform.position;
            } 
        if (Input.GetKeyDown(KeyCode.E)) { 
            text.text = "LivingRoom";        
            userView.position = locations[2].transform.position;
            } 
        if (Input.GetKeyDown(KeyCode.R)) { 
            text.text = "Kitchen";            
            userView.position = locations[3].transform.position;
            } 
        if (Input.GetKeyDown(KeyCode.T)) { 
            text.text = "Garden";
            userView.position = locations[4].transform.position;           
            } 
        if (Input.GetMouseButtonDown(0))     {  text.text = "left mouse button!"; } 
    }
}
