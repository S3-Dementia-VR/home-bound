using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDetector : MonoBehaviour
{
    public List<ActiveStateSelector> gestures;
    public TMPro.TextMeshPro text;

    public LineRenderer rayLine;

    public float lineWidth = 0.1f;
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
            item.WhenSelected += () => SetTextToPoseName("point detected");
        }
    }

    private void SetTextToPoseName(string newText)
    {
        toggled = true;
        rayLine.enabled = true;

        if (toggled)
        {
            castRay(transform.position, transform.forward, lineMaxLength);
        }
    }

    private void castRay(Vector3 targetPosition, Vector3 direction, float length)
    {
        RaycastHit hit;

        Ray rayOut = new Ray(targetPosition, direction);

        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(rayOut, out hit))
        {
            endPosition = hit.point;
            text.text = "ray cast";
        }
    }
}
