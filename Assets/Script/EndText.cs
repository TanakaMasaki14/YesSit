using UnityEngine;
using TMPro;

public class EndText : MonoBehaviour
{
    public TextMeshPro text; // TextMeshProUGUIに変更
    public float speed = 0f;
    private float elapsedTime = 0f;
    public float stopTime = 10f; // 10秒後に停止

    void Update()
    {
        if (text != null && elapsedTime < stopTime)
        {
            // テキストを上に移動させる
            text.rectTransform.anchoredPosition += new Vector2(0, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
    }
}
