using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProÇàµÇ§ç€Ç…ïKóv

public class Text : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;

    void Start()
    {
        gameOverText.text = "start satge1";
        gameOverText.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        gameOverText.text = "GameOver";
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                gameOverText.color = gameOverText.color + new Color32(0, 0, 0, 1);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
