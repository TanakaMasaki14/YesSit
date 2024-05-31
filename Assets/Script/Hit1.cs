using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit1 : MonoBehaviour
{
    private Vector3 initialPosition;
    void Start()
    {
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {

            var impulseSource = GetComponent<CinemachineImpulseSource>();
            impulseSource.GenerateImpulse();

            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;

            SceneManager.LoadScene("Stage1");
        }
    }
}