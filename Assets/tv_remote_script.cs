using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_remote_script : MonoBehaviour
{
    public GameObject tv;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void switch_TV_on_off(){
        if (tv.activeSelf){
            tv.SetActive(false);
        }
        else{
            tv.SetActive(true);
        }
    }
}
