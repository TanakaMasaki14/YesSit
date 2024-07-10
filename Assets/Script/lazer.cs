using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lazer : MonoBehaviour
{
    public ParticleSystem particleEffect; // パーティクルエフェクトの参照
    private Vector3 collisionPosition;
    private bool isCollided = false;

    void Start()
    {
        // 初期化
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
        // 衝突後は位置を固定
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

            // 衝突位置を保存
            collisionPosition = transform.position;

            // 衝突フラグを設定
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

            // 0.8秒後にシーンをロードする
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Stage4");
    }
}