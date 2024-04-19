using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    // Unity画面に表示する
    [SerializeField]
    [Tooltip("回転速度")]
    private float speed;                // オブジェクトのスピード

    private int radius;               // 円を描く半径
    private Vector3 pos;      // defPositionをVector3で定義する。
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        radius = 2;

        pos = transform.position;    // defPositionを自分のいる位置に設定する。
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);      // X軸の設定
        y = radius * Mathf.Cos(Time.time * speed);      // Y軸の設定
                                                        // z = radius * Mathf.Cos(Time.time * speed);      // Z軸の設定

        transform.position = new Vector3(x + pos.x, y + pos.y, pos.z);  // 自分のいる位置から座標を動かす。
    }
}
