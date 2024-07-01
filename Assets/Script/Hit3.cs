using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit3 : MonoBehaviour
{
    private Vector3 collisionPosition;
    private bool isCollided = false;

    void Start()
    {
        // ������
        collisionPosition = transform.position;
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
        SceneManager.LoadScene("Stage3");
    }
}
