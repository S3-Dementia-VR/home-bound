using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc_controller_script : MonoBehaviour
{
    public GameObject big_living_room;
    public GameObject small_living_room;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switch_LivingRoom(){
        if (big_living_room.activeSelf){
            big_living_room.SetActive(false);
            small_living_room.SetActive(true);
        }
        else{
            big_living_room.SetActive(true);
            small_living_room.SetActive(false);
        }
    }
}
