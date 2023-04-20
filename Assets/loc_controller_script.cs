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
    public GameObject nature_view;
    public float time_out;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public IEnumerator switch_LivingRoom_coroutine(){
        yield return new WaitForSeconds(time_out);
        if (small_living_room.activeSelf){
            small_living_room.SetActive(false);
        }
        else{
            small_living_room.SetActive(true);
        }
        yield return null;
    }
    
    public IEnumerator switch_DiningRoom_coroutine(){
        yield return new WaitForSeconds(time_out);
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
        if (small_garden_room.activeSelf){
            small_garden_room.SetActive(false);
            use_grab_interactor_right1.SetActive(false);
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
        if (nature_view.activeSelf){
            nature_view.SetActive(false);
        }
        else{
            nature_view.SetActive(true);
        }
        yield return null;
    }
}
