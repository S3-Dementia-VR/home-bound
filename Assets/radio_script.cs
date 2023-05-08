using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio_script : MonoBehaviour
{
    public AudioSource old_music;
    public AudioSource bgMusic;
    public GameObject light_on;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switch_Audio_on_off(){
        if (light_on.activeSelf){
            old_music.Pause();
            light_on.SetActive(false);
            bgMusic.UnPause();
        }
        else{
            old_music.UnPause();
            light_on.SetActive(true);
            bgMusic.Pause();
        }
    }
}
