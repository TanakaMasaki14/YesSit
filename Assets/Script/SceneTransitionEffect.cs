using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionEffect : MonoBehaviour
{
    public Image fadeImage;// フェード用のUIイメージ
    public float fadeSpeed = 1.5f;//フェード速度

    private bool ifFading = false;// フェード中かどうかのフラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // フェードイン
    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        while(color.a > 0f)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
    }

    // フェードアウト
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine("Play"));
    }

    IEnumerator FadeOutCoroutine(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        while (color.a < 1f)
        {
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
