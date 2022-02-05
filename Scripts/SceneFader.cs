using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public Image img;
    public float fadeTime;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime * fadeTime;
            float a = curve.Evaluate(time);
            img.color = new Color(1f, 1f, 1f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * fadeTime;
            float a = curve.Evaluate(time);
            img.color = new Color(1f, 1f, 1f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
