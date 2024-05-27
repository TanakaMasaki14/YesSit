using UnityEngine;
using TMPro;

public class TextOpacityChange : MonoBehaviour
{
    public TextMeshProUGUI textObject; // TextMeshProオブジェクトへの参照
    public float minOpacity = 0.0f;    // 最小の透明度
    public float maxOpacity = 0.0f;    // 最大の透明度
    public float changeSpeed = 0f;     // 透明度変化の速さ

    private void Start()
    {
        // 必要に応じて初期化などを行う
    }

    private void Update()
    {
        // テキストの透明度を往復させる
        float newOpacity = Mathf.PingPong(Time.time * changeSpeed, maxOpacity - minOpacity) + minOpacity;

        // TextMeshProのcolorプロパティを更新
        Color currentColor = textObject.color;
        textObject.color = new Color(currentColor.r, currentColor.g, currentColor.b, newOpacity);
    }
}
