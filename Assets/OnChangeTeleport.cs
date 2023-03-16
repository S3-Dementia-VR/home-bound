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
    }
    
    public IEnumerator teleport()
    {
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
