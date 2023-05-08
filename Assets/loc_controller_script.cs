using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class loc_controller_script : MonoBehaviour
{
    // gameobject for interactables
    public GameObject small_living_room;                        
    public GameObject small_dining_room;
    public GameObject small_garden_room;
    // gameobject for hand gestures
    public GameObject use_grab_interactor_right1;
    public GameObject use_grab_interactor_right2;
    // gameobject for lights
    public GameObject nature_view_light;    
    // gameobject for birds and Statistics
    public lb_BirdController bird_controller;
    public float time_out;
    public stat_timer_script view_stat;
    // gameobject for companion
    public GameObject insideHouse;
    public GameObject diningRoom;
    public GameObject livingRoom;
    public GameObject gardenArea;
    public GameObject birdwatching;
    // gameobject for PhotoUpload
    public GameObject photo;

    // tv
    public VideoPlayer tv;
    public GameObject  tv_screen;
    // radio
    public AudioSource old_music;
    public AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(time_out));
        // tv
        tv.Pause();
        tv_screen.transform.localScale = new Vector3(0, 0 ,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (small_living_room.activeSelf){
            view_stat.livingTime += Time.deltaTime;
        }
        if (small_dining_room.activeSelf){
            view_stat.diningTime += Time.deltaTime;
        }
        if (small_garden_room.activeSelf){
            view_stat.gardenTime += Time.deltaTime;
        } else{
            if (nature_view_light.activeSelf){
                view_stat.gardenTime += Time.deltaTime;
            }
        }
    }

    public void switch_LivingRoom(){
        StartCoroutine( switch_LivingRoom_coroutine() );
    }
    public void switch_DiningRoom(){
        StartCoroutine( switch_DiningRoom_coroutine() );
    }
    public void switch_GardenRoom(){
        StartCoroutine( switch_GardenRoom_coroutine() );
    }
    public void switch_NatureView(){
        StartCoroutine( switch_NatureView_coroutine() );
    }
    public void switch_InsideEntrance(){
        StartCoroutine( switch_InsideEntrance_coroutine() );
    }
    public void switch_BirdWatchSeat(){
        StartCoroutine( switch_BirdWatchSeat_coroutine() );
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Pause birdspawning at the start
        switch_NatureView();
        // radio
        old_music.Pause();
    }
    public IEnumerator switch_LivingRoom_coroutine(){
        yield return new WaitForSeconds(time_out);  // wait for transition
        bird_controller.AllUnspawn();               // unspawn possibly misplaced birds
        if (small_living_room.activeSelf){          // checks if interactable area is visible
            small_living_room.SetActive(false);     // deactivate area 
            livingRoom.SetActive(false);            // deactivate companion
            photo.SetActive(false);                 // deactivate photoupload
        }
        else{
            small_living_room.SetActive(true);
            livingRoom.SetActive(true);
            photo.SetActive(true);
        }
        yield return null;
    }
    
    public IEnumerator switch_DiningRoom_coroutine(){
        yield return new WaitForSeconds(time_out);
        bird_controller.AllUnspawn();
        if (small_dining_room.activeSelf){
            small_dining_room.SetActive(false);
            diningRoom.SetActive(false);
        }
        else{
            small_dining_room.SetActive(true);
            diningRoom.SetActive(true);
        }
        yield return null;
    }

    public IEnumerator switch_GardenRoom_coroutine(){
        yield return new WaitForSeconds(time_out);
        bird_controller.AllUnspawn();
        if (small_garden_room.activeSelf){
            small_garden_room.SetActive(false);
            use_grab_interactor_right1.SetActive(false);    // deactivate use grabs interactors that causes bug
            use_grab_interactor_right2.SetActive(false);  
            gardenArea.SetActive(false);   
        }
        else{
            small_garden_room.SetActive(true);
            use_grab_interactor_right1.SetActive(true);
            use_grab_interactor_right2.SetActive(true);
            gardenArea.SetActive(true);   
        }
        yield return null;
    }
    
    public IEnumerator switch_NatureView_coroutine(){
        yield return new WaitForSeconds(time_out);
        bird_controller.AllUnspawn();
        if (nature_view_light.activeSelf){                // Turn off outside settings
            nature_view_light.SetActive(false);
            bird_controller.AllPause();                   // Pause spawning if not in garden area
            bgMusic.UnPause();
        }
        else{
            nature_view_light.SetActive(true);
            bird_controller.AllUnPause();
            bgMusic.Pause();
        }
        yield return null;
    }
    
    public IEnumerator switch_BirdWatchSeat_coroutine(){
        yield return new WaitForSeconds(time_out); 
        bird_controller.AllUnspawn();          
        if (birdwatching.activeSelf){   
            birdwatching.SetActive(false);
        }
        else{
            birdwatching.SetActive(true);
        }
        yield return null;
    }
    
    public IEnumerator switch_InsideEntrance_coroutine(){
        yield return new WaitForSeconds(time_out); 
        bird_controller.AllUnspawn();          
        if (insideHouse.activeSelf){   
            insideHouse.SetActive(false);
        }
        else{
            insideHouse.SetActive(true);
        }
        yield return null;
    }
}
