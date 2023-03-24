using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc_controller_script : MonoBehaviour
{
    public GameObject small_living_room;
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
}
