using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 collisionPosition;
    private bool isCollided = false;
    void Start()
    {
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition = transform.position;
    }
    void Update()
    {
        // �Փˌ�͈ʒu���Œ�
        if (isCollided)
        {
            transform.position = collisionPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;

            // 0.8�b��ɃV�[�������[�h����
            StartCoroutine(LoadSceneAfterDelay(2f));

            // �J�[�\����\�����A�J�[�\�������b�N����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Stage1");
    }
}
