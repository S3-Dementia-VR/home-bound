using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    public Animator anim;
    public Transform door;
    public Transform fps;
    private Vector3 offset = new Vector3(0,0,0);
    private Vector3 minus5 = new Vector3(0,0,-5);

    void Start() {
        anim = GetComponent<Animator>();
        anim.speed = 2;
    }

    void Update() {
        if (Vector3.Distance(door.position+offset, fps.position) <= 20) {
            if (Input.GetButtonDown("Interact")) {
                if(anim.GetBool("open") == false) {
                    anim.Play("Door_open");
                    anim.SetBool("open", true);
                    offset += minus5;
                }
                else {
                    anim.Play("Door_Close");
                    anim.SetBool("open", false);
                    offset -= minus5;
                }
            }
        }
    }
}
