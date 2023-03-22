using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio_script : MonoBehaviour
{
    public GameObject old_music;
    public GameObject light_on;
    public GameObject light_off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switch_Audio_on_off(){
        if (old_music.activeSelf){
            old_music.SetActive(false);
            light_on.SetActive(false);
            light_off.SetActive(true);
        }
        else{
            old_music.SetActive(true);
            light_on.SetActive(true);
            light_off.SetActive(false);
        }
    }
}
