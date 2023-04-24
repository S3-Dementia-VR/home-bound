using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc_controller_script : MonoBehaviour
{
    public GameObject small_living_room;
    public GameObject small_dining_room;
    public GameObject small_garden_room;
    public GameObject use_grab_interactor_right1;
    public GameObject use_grab_interactor_right2;
    public GameObject nature_view_light;
    public lb_BirdController bird_controller;
    public stat_timer_script view_stat;
    public float time_out;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(time_out));
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
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Pause birdspawning at the start
        switch_NatureView();
    }
    public IEnumerator switch_LivingRoom_coroutine(){
        yield return new WaitForSeconds(time_out);  // wait for transition
        bird_controller.AllUnspawn();               // unspawn possibly misplaced birds
        if (small_living_room.activeSelf){          // checks if interactable area is visible
            small_living_room.SetActive(false);     // deactivate area 
        }
        else{
            small_living_room.SetActive(true);
        }
        yield return null;
    }
    
    public IEnumerator switch_DiningRoom_coroutine(){
        yield return new WaitForSeconds(time_out);
        bird_controller.AllUnspawn();
        if (small_dining_room.activeSelf){
            small_dining_room.SetActive(false);
        }
        else{
            small_dining_room.SetActive(true);
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
        }
        else{
            small_garden_room.SetActive(true);
            use_grab_interactor_right1.SetActive(true);
            use_grab_interactor_right2.SetActive(true);
        }
        yield return null;
    }
    
    public IEnumerator switch_NatureView_coroutine(){
        yield return new WaitForSeconds(time_out);
        bird_controller.AllUnspawn();
        if (nature_view_light.activeSelf){
            nature_view_light.SetActive(false);
            bird_controller.AllPause();                   // Pause spawning if not in garden area
        }
        else{
            nature_view_light.SetActive(true);
            bird_controller.AllUnPause();
        }
        yield return null;
    }
}
