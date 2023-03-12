using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tv_remote_script : MonoBehaviour
{
    public GameObject tv;
    public Transform tv_remote;
    public Transform tv_remote_original;
    public Transform userView;
    public Transform livingRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(userView.transform.position, livingRoom.transform.position) !=0){
            tv_remote.position = tv_remote_original.transform.position;
            tv_remote.rotation = tv_remote_original.transform.rotation;
        }
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
