using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class HitT : MonoBehaviour
{
    PlayerMovement playerMovement;

    private Vector3 initialPosition;
    private Vector3 initialVelocity;

    void Start()
    {
        //�v���C���[�̓����̃X�N���v�g
        playerMovement = new PlayerMovement();
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition.x = 0;
        initialPosition.y = 0;
        initialPosition.z = 0;
        //�v���C���[�̉����x
        initialVelocity.x = 0;
        initialVelocity.y = 0;
        initialVelocity.z = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.SetVelocity(ref initialVelocity);
            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;
            // �J�[�\����\�����A�J�[�\�������b�N����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
