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
        // 初期化
        collisionPosition = transform.position;
    }

    void Update()
    {
        // 衝突後は位置を固定
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

            // 衝突位置を保存
            collisionPosition = transform.position;

            // 衝突フラグを設定
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

            // 0.8秒後にシーンをロードする
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Stage3");
    }
}
