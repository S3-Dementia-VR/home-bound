using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangeTeleport : MonoBehaviour
{
    public Transform userView;
    public Transform targetGameObject;
    public Transform targetGameObjectOriginal;
    public Transform targetLocation;

    public FadeScreen fadeScreen;

    void Start()
    {
        StartCoroutine( teleport() );
    }
    void Update()
    {
        // if (Vector3.Distance(targetGameObjectOriginal.transform.position, targetGameObject.transform.position) != 0)
        // {
        //     // StartCoroutine( fadeScreen.FadeOut() );
        //     StartCoroutine( teleport() );
        //     // teleport();            
        //     // StartCoroutine( fadeScreen.FadeIn() );
        //     // fadeScreen.FadeIn();
        // }
    }
    
    public IEnumerator teleport()
    {
        while (true){
            yield return new WaitUntil(IsChanged);
            targetGameObject.transform.position = targetGameObjectOriginal.transform.position;
            yield return StartCoroutine( fadeScreen.FadeOut() );
            userView.position = targetLocation.transform.position;
            userView.rotation = targetLocation.transform.rotation;
            yield return StartCoroutine( fadeScreen.FadeIn() );
            yield return null;
        }
    }
    bool IsChanged()
    {
        if (Vector3.Distance(targetGameObjectOriginal.transform.position, targetGameObject.transform.position) != 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
