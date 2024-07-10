using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lazer : MonoBehaviour
{
    public ParticleSystem particleEffect; // �p�[�e�B�N���G�t�F�N�g�̎Q��
    private Vector3 collisionPosition;
    private bool isCollided = false;

    void Start()
    {
        // ������
        collisionPosition = transform.position;

        if (particleEffect != null)
        {
            particleEffect.Play();
        }
        else
        {
            Debug.LogError("Particle effect not assigned.");
        }
    }

    void Update()
    {
        // �Փˌ�͈ʒu���Œ�
        if (isCollided)
        {
            transform.position = collisionPosition;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            var impulseSource = GetComponent<CinemachineImpulseSource>();
            if (impulseSource != null)
            {
                impulseSource.GenerateImpulse();
            }
            else
            {
                Debug.LogError("CinemachineImpulseSource component not found.");
            }

            // �Փˈʒu��ۑ�
            collisionPosition = transform.position;

            // �Փ˃t���O��ݒ�
            isCollided = true;

            var playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
            else
            {
                Debug.LogError("PlayerMovement component not found on player object.");
            }

            var cameraFollow = other.GetComponent<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.enabled = false;
            }
            else
            {
                Debug.LogError("CameraFollow component not found on player object.");
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