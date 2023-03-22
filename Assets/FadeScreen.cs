using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if(fadeOnStart)
        {
            StartCoroutine(FadeRoutine(1, 0));
        }
    }

    public IEnumerator FadeOutIn()
    {
        yield return StartCoroutine(FadeRoutine(0, 1));
        yield return StartCoroutine(FadeRoutine(1, 0));
    }

    public IEnumerator FadeIn()
    {
        yield return StartCoroutine(FadeRoutine(1, 0));
        // Fade(1, 0);
    }

    public IEnumerator FadeOut()
    {
        yield return StartCoroutine(FadeRoutine(0, 1));
        // Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;

        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
    }
}
