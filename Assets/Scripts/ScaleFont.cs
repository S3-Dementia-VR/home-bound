using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]


public class ScaleFont : MonoBehaviour
{
    public Vector2 offset;
    public float ratio = 10;

    void OnGUI()
    {
        float finalSize = (float)Screen.width / ratio;
        //Text.fontSize = (int)finalSize;
        //Text.pixelOffset = new Vector2(offset.x * Screen.width, offset.y * Screen.height);
    }
}
