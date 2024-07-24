using UnityEngine;
using TMPro;

public class EndText : MonoBehaviour
{
    public TextMeshPro text; // TextMeshProUGUI�ɕύX
    public float speed = 0f;
    private float elapsedTime = 0f;
    public float stopTime = 10f; // 10�b��ɒ�~

    void Update()
    {
        if (text != null && elapsedTime < stopTime)
        {
            // �e�L�X�g����Ɉړ�������
            text.rectTransform.anchoredPosition += new Vector2(0, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
    }
}
