using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDetector : MonoBehaviour
{
    public List<ActiveStateSelector> gestures;
    public TMPro.TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in gestures)
        {
            item.WhenSelected += () => SetTextToPoseName(item.gameObject.name);
            item.WhenUnselected += () => SetTextToPoseName("");
        }
    }

    private void SetTextToPoseName(string newText)
    {
        text.text = newText;
    }
}
