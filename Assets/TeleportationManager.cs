using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationManager : MonoBehaviour
{
    public List<ActiveStateSelector> gestures;
    public Transform userView;
    public List<Transform> locations;
    public TMPro.TextMeshPro text;

    public LineRenderer rayLine;

    public float lineWidth = 5f;
    public float lineMaxLength = 1f;

    public bool toggled = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] startLinePositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        rayLine.SetPositions(startLinePositions);
        rayLine.enabled = false;
    }

    void Update()
    {
        foreach (var item in gestures)
        {
            item.WhenSelected += () => checkAim();
        }
    }

    private void checkAim()
    {
        Debug.Log("pointed detected");
        toggled = true;
        rayLine.enabled = true;

        if (toggled)
        {
            castRay(transform.position, transform.forward, lineMaxLength);
        }
    }

    private void castRay(Vector3 targetPosition, Vector3 direction, float length)
    {
        Debug.Log("ray casted");
        RaycastHit hit;

        Ray rayOut = new Ray(targetPosition, direction);

        // Inside entrance
        if (Physics.Raycast(rayOut, out hit, Mathf.Infinity, ~(1 << 6)))
        {
            userView.position = locations[0].transform.position;
        }

        // Sala
        if (Physics.Raycast(rayOut, out hit, Mathf.Infinity, ~(1 << 7)))
        {
            userView.position = locations[1].transform.position;
        }
    }
}
