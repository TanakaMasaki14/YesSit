using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionEffect : MonoBehaviour
{
    public Image fadeImage;// �t�F�[�h�p��UI�C���[�W
    public float fadeSpeed = 1.5f;//�t�F�[�h���x

    private bool ifFading = false;// �t�F�[�h�����ǂ����̃t���O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �t�F�[�h�C��
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

    // �t�F�[�h�A�E�g
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
