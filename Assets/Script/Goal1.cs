using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal1 : MonoBehaviour
{
    private Vector3 initialPosition;
    void Start()
    {
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;

            SceneManager.LoadScene("Stage2");

            // �J�[�\����\�����A�J�[�\�������b�N����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
