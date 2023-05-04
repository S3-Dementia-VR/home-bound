using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class indicate_teleport_script : MonoBehaviour
{
    // gameobject for teleport interactor
    public GameObject teleport_gameObject;
    public TMP_Text teleport_trigger_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (teleport_gameObject.activeSelf){
            teleport_trigger_text.text = "Teleport On";
        }
        else{
            teleport_trigger_text.text = "Teleport Off";
        }
    }
}
