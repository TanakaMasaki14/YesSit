using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    // Unity��ʂɕ\������
    [SerializeField]
    [Tooltip("��]���x")]
    private float speed;                // �I�u�W�F�N�g�̃X�s�[�h

    private int radius;               // �~��`�����a
    private Vector3 pos;      // defPosition��Vector3�Œ�`����B
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        radius = 2;

        pos = transform.position;    // defPosition�������̂���ʒu�ɐݒ肷��B
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);      // X���̐ݒ�
        y = radius * Mathf.Cos(Time.time * speed);      // Y���̐ݒ�
                                                        // z = radius * Mathf.Cos(Time.time * speed);      // Z���̐ݒ�

        transform.position = new Vector3(x + pos.x, y + pos.y, pos.z);  // �����̂���ʒu������W�𓮂����B
    }
}
