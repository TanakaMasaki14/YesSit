using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal2 : MonoBehaviour
{
    private Vector3 collisionPosition;
    private bool isCollided = false;

    // 画面中央に表示するテキスト
    public Text goalText;

    void Start()
    {
        // 初期化
        collisionPosition = transform.position;
        // テキストを非表示に設定
        if (goalText != null)
        {
            goalText.gameObject.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            // 衝突位置を保存
            collisionPosition = transform.position;

            // 衝突フラグを設定
            isCollided = true;

            var playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // テキストを表示
            if (goalText != null)
            {
                goalText.gameObject.SetActive(true);
            }

            // 3秒後にシーンをロードする
            StartCoroutine(LoadSceneAfterDelay(3f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Stage1");
    }
}
