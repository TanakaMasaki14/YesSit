using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lazer : MonoBehaviour
{
    public ParticleSystem particleEffect; // �p�[�e�B�N���G�t�F�N�g�̎Q��
    public Image redFlashImage; // �Ԃ��t���b�V���p��UI Image
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

        // �Ԃ��t���b�V���p��Image���\���ɂ���
        if (redFlashImage != null)
        {
            var color = redFlashImage.color;
            color.a = 0;
            redFlashImage.color = color;
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
            // �Փˈʒu��ۑ�
            collisionPosition = transform.position;

            // �Փ˃t���O��ݒ�
            isCollided = true;

            var playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // �Ԃ��t���b�V�����J�n
            if (redFlashImage != null)
            {
                StartCoroutine(FlashRed());
            }

            // 0.8�b��ɃV�[�������[�h����
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator FlashRed()
    {
        var color = redFlashImage.color;

        // �t���b�V����\��
        for (int i = 0; i < 3; i++) // �_�ŉ�
        {
            // �t�F�[�h�C��
            for (float t = 0; t <= 1; t += Time.deltaTime / 0.1f) // 0.1�b�Ńt�F�[�h�C��
            {
                color.a = Mathf.Lerp(0, 1, t);
                color.r = 1.0f; // �ԐF���ő�ɐݒ�
                color.g = 0.0f; // �ΐF���ŏ��ɐݒ�
                color.b = 0.0f; // �F���ŏ��ɐݒ�
                redFlashImage.color = color;
                yield return null;
            }

            // �t�F�[�h�A�E�g
            for (float t = 0; t <= 1; t += Time.deltaTime / 0.1f) // 0.1�b�Ńt�F�[�h�A�E�g
            {
                color.a = Mathf.Lerp(1, 0, t);
                redFlashImage.color = color;
                yield return null;
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Stage1");
    }
}