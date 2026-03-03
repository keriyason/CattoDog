using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResetSceneController : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeCanvas;   
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float delayBeforeLoad = 0.5f;

    private void Start()
    {
        StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(GameManager.Instance.nextSceneName);
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        fadeCanvas.alpha = 1f;
    }
}



