using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinkLy : MonoBehaviour
{
    private float fadeTime = .1f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine("TwinkleLoop");
    }

    private IEnumerator TwinkleLoop()
    {
        while (true)
        {

            yield return StartCoroutine(FadeEffect(1, 0));


            yield return StartCoroutine(FadeEffect(0, 1));

        }

    }

    IEnumerator FadeEffect(float start, float end)
    {
        float currTime = 0;
        float percent = 0;

        while (percent < 1)
        {
            currTime += Time.deltaTime;
            percent = currTime / fadeTime;

            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            spriteRenderer.color = color;

            yield return null;

        }
    }
}
