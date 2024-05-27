using UnityEngine;
using TMPro;

public class TextOpacityChange : MonoBehaviour
{
    public TextMeshProUGUI textObject; // TextMeshPro�I�u�W�F�N�g�ւ̎Q��
    public float minOpacity = 0.0f;    // �ŏ��̓����x
    public float maxOpacity = 0.0f;    // �ő�̓����x
    public float changeSpeed = 0f;     // �����x�ω��̑���

    private void Start()
    {
        // �K�v�ɉ����ď������Ȃǂ��s��
    }

    private void Update()
    {
        // �e�L�X�g�̓����x������������
        float newOpacity = Mathf.PingPong(Time.time * changeSpeed, maxOpacity - minOpacity) + minOpacity;

        // TextMeshPro��color�v���p�e�B���X�V
        Color currentColor = textObject.color;
        textObject.color = new Color(currentColor.r, currentColor.g, currentColor.b, newOpacity);
    }
}
