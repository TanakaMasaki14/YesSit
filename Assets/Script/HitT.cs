using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class HitT : MonoBehaviour
{
    PlayerMovement playerMovement;

    private Vector3 initialPosition;
    private Vector3 initialVelocity;

    void Start()
    {
        //プレイヤーの動きのスクリプト
        playerMovement = new PlayerMovement();
        // プレイヤーの初期位置を保存
        initialPosition.x = 0;
        initialPosition.y = 0;
        initialPosition.z = 0;
        //プレイヤーの加速度
        initialVelocity.x = 0;
        initialVelocity.y = 0;
        initialVelocity.z = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.SetVelocity(ref initialVelocity);
            // プレイヤーの位置を初期位置に戻す
            other.transform.position = initialPosition;
            // カーソルを表示し、カーソルをロック解除
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
