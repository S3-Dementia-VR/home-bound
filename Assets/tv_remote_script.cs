using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class tv_remote_script : MonoBehaviour
{
    public VideoPlayer tv;
    public GameObject  tv_screen;
    public AudioSource bgMusic;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void switch_TV_on_off(){
        if (!(tv.isPaused)){
            tv.Pause();
            bgMusic.UnPause();
            tv_screen.transform.localScale = new Vector3(0, 0 ,0);
        }
        else{
            tv.Play();
            bgMusic.Pause();
            tv_screen.transform.localScale = new Vector3(0.96f, 0.7f ,0.74f);
        }
    }
}
