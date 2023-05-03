using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangeTeleport : MonoBehaviour
{
    public Transform userView;                          // location of user to be teleported
    public Transform targetGameObject;                  // location of invisble object to be triggered
    public Transform targetGameObjectOriginal;          // Original coordinates; to track if location has changed
    public Transform targetLocation;                    // location to be teleported to

    public FadeScreen fadeScreen;                       // for fadescreen

    void Start()
    {
        StartCoroutine( teleport() );
    }
    void Update()
    {
    }
    
    public IEnumerator teleport()
    {   
        // teleport function; changes the position of user gameobject
        while (true){
            yield return new WaitUntil(IsChanged);
            yield return StartCoroutine( fadeScreen.FadeOut() );
            userView.position = targetLocation.transform.position;
            userView.rotation = targetLocation.transform.rotation;
            targetGameObject.transform.position = targetGameObjectOriginal.transform.position;
            yield return null;
            yield return StartCoroutine( fadeScreen.FadeIn() );
            yield return new WaitUntil(IsOrigin);
        }
    }

    bool IsChanged()
    {
        // detects change in coodinates
        if (Vector3.Distance(targetGameObjectOriginal.transform.position, targetGameObject.transform.position) != 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    bool IsOrigin()
    {
        // checks if original position
        if (Vector3.Distance(targetGameObjectOriginal.transform.position, targetGameObject.transform.position) == 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
