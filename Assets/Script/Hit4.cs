using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit4 : MonoBehaviour
{
    private Vector3 collisionPosition;
    private bool isCollided = false;
    public GameObject face1;
    public GameObject face2;

    void Start()
    {
        // ������
        collisionPosition = transform.position;
        face1.SetActive(true);
        face2.SetActive(false);
    }

    void Update()
    {
        // �Փˌ�͈ʒu���Œ�
        if (isCollided)
        {
            transform.position = collisionPosition;
            face1.SetActive(false);
            face2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            var impulseSource = GetComponent<CinemachineImpulseSource>();
            impulseSource.GenerateImpulse();

            // �Փˈʒu��ۑ�
            collisionPosition = transform.position;

            // �Փ˃t���O��ݒ�
            isCollided = true;

            var playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            var cameraFollow = GetComponent<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.enabled = false;
            }

            // 0.8�b��ɃV�[�������[�h����
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Stage4");
    }
}
