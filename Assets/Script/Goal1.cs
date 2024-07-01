using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal1 : MonoBehaviour
{
    private Vector3 initialPosition;
    void Start()
    {
        // プレイヤーの初期位置を保存
        initialPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーの位置を初期位置に戻す
            other.transform.position = initialPosition;

            SceneManager.LoadScene("Stage2");

            // カーソルを表示し、カーソルをロック解除
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
