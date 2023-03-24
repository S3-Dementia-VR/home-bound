using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitControl : MonoBehaviour
{
    // public GameObject fps;
    // public Transform chairT;
    // private MeshCollider chairC;
    // private MeshCollider floorC;
    // private FirstPersonAIO fpsScript;
    // private Transform fpsPos;                    // stores character position
    // private Vector3 tempPos = new Vector3 (0,0,0);
    // private bool sitting = false;


    void Start() {
        // fps = GameObject.Find("FirstPerson-AIO");
        // fpsScript = fps.GetComponent<FirstPersonAIO>();
        // fpsPos = fps.GetComponent<Transform>();
        // chairT = GetComponent<Transform>();
        // chairC = GetComponent<MeshCollider>();
        // floorC = GameObject.Find("floor_main").GetComponent<MeshCollider>();
    }

    void Update() {
        // if (Vector3.Distance(chairT.position, fpsPos.position) <= 15) {
        //     if (Input.GetButtonDown("Interact")) {
        //         if (sitting == false) {
        //             tempPos = fpsPos.position;
        //             fpsScript.playerCanMove = false;
        //             chairC.enabled = false;
        //             sitting = true;
        //             fpsPos.position = chairT.position;
        //             floorC.enabled = false;
        //         } 
        //         else {
        //             fpsScript.playerCanMove = true;
        //             chairC.enabled = true;
        //             sitting = false;
        //             fpsPos.position = tempPos;
        //             floorC.enabled = true;
        //         }
        //     }
        // }
    }
}
