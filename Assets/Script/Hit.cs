using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    // プレイヤーの初期位置を保存する変数
    private Vector3 initialPosition;

    // 初期化
    private void Start()
    {
        // プレイヤーの初期位置を保存
        initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーの位置を初期位置に戻す
            other.transform.position = initialPosition;

            // カーソルを表示し、カーソルをロック解除
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
