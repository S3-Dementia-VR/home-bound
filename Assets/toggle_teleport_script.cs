using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle_teleport_script : MonoBehaviour
{
    // gameobject for teleport interactor
    public GameObject teleport_gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle_teleport(){
        if (teleport_gameObject.activeSelf){          // checks if interactable area is visible
            teleport_gameObject.SetActive(false);     // deactivate area 
        }
        else{
            teleport_gameObject.SetActive(true);
        }
    }
}
