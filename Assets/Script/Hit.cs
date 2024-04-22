using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    // �v���C���[�̏����ʒu��ۑ�����ϐ�
    private Vector3 initialPosition;

    // ������
    private void Start()
    {
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;

            // �J�[�\����\�����A�J�[�\�������b�N����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
