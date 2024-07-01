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
        // プレイヤーの初期位置を保存
        initialPosition = transform.position;
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
        if (other.CompareTag("Player"))
        {
            // プレイヤーの位置を初期位置に戻す
            other.transform.position = initialPosition;

            // 0.8秒後にシーンをロードする
            StartCoroutine(LoadSceneAfterDelay(2f));

            // カーソルを表示し、カーソルをロック解除
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
