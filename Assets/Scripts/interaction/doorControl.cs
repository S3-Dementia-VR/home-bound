using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    public Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        anim.speed = 2;
    }

    void Update() {
        if (Input.GetButtonDown("Interact")) {
            if(anim.GetBool("open") == false) {
                anim.Play("Door_open");
                anim.SetBool("open", true);
            }
            else {
                anim.Play("Door_Close");
                anim.SetBool("open", false);
            }
        }
    }
}
