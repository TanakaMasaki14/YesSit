using UnityEngine;
using TMPro;

public class ClearText : MonoBehaviour
{
    public TextMeshPro text; // TextMeshPro���g�p
    public float Yspeed = 0f;
    public float Zspeed = 0f;

    void Start()
    {
    }

    void Update()
    {
        if (text != null)
        {
            // �e�L�X�g����Ɉړ�������
            Vector3 newPosition = text.rectTransform.anchoredPosition3D;
            newPosition.y += Yspeed * Time.deltaTime;
            newPosition.z += Zspeed * Time.deltaTime;
            text.rectTransform.anchoredPosition3D = newPosition;
        }
    }
}
