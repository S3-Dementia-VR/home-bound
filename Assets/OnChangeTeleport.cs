using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangeTeleport : MonoBehaviour
{
    public Transform userView;
    public Transform targetGameObject;
    public Transform targetGameObjectOriginal;
    public Transform targetLocation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetGameObjectOriginal.transform.position, targetGameObject.transform.position) !=0){
            userView.position = targetLocation.transform.position;
            userView.rotation = targetLocation.transform.rotation;
        }
    }
}
