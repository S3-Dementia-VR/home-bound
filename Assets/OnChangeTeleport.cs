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

    void Update()
    {
        if (Vector3.Distance(targetGameObjectOriginal.transform.position, targetGameObject.transform.position) != 0)
        {
            fadeScreen.FadeOut();

            userView.position = targetLocation.transform.position;
            userView.rotation = targetLocation.transform.rotation;

            fadeScreen.FadeIn();
        }
    }
}
