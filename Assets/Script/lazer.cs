using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lazer : MonoBehaviour
{
    public ParticleSystem particleEffect; // パーティクルエフェクトの参照
    public Image redFlashImage; // 赤いフラッシュ用のUI Image
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

        // 赤いフラッシュ用のImageを非表示にする
        if (redFlashImage != null)
        {
            var color = redFlashImage.color;
            color.a = 0;
            redFlashImage.color = color;
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
            // 衝突位置を保存
            collisionPosition = transform.position;

            // 衝突フラグを設定
            isCollided = true;

            var playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // 赤いフラッシュを開始
            if (redFlashImage != null)
            {
                StartCoroutine(FlashRed());
            }

            // 0.8秒後にシーンをロードする
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator FlashRed()
    {
        var color = redFlashImage.color;

        // フラッシュを表示
        for (int i = 0; i < 3; i++) // 点滅回数
        {
            // フェードイン
            for (float t = 0; t <= 1; t += Time.deltaTime / 0.1f) // 0.1秒でフェードイン
            {
                color.a = Mathf.Lerp(0, 1, t);
                color.r = 1.0f; // 赤色を最大に設定
                color.g = 0.0f; // 緑色を最小に設定
                color.b = 0.0f; // 青色を最小に設定
                redFlashImage.color = color;
                yield return null;
            }

            // フェードアウト
            for (float t = 0; t <= 1; t += Time.deltaTime / 0.1f) // 0.1秒でフェードアウト
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