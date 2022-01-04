using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    public float TextDuration = 5;
    public bool IsEnded = false;
    private float time = 0f;

    public void Start()
    {
        Text text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        time = t;
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        Invoke("FadeOutText", TextDuration);
    }

    public void FadeOutText()
    {
        StartCoroutine(FadeTextToZeroAlpha(time, GetComponent<Text>()));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        IsEnded = true;
        this.gameObject.SetActive(false);
    }
}
