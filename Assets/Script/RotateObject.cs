using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Unity画面に表示する
    [SerializeField]
    [Tooltip("x軸の回転角度")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y軸の回転角度")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z軸の回転角度")]
    private float rotateZ = 0;

    [SerializeField]
    [Tooltip("往復の時間")]
    private float moveTime = 0;

    [SerializeField]
    [Tooltip("オブジェクトのタイプ")]
    private bool type = false;

    private Vector3 pos;
    void Start()
    {
        // オブジェクトの座標を宣言した値として使う
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!type)
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
        }
        else
        {
            // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
            // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
            gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
            // X座標にPingPong関数を使い往復するようにしている
            transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time, moveTime), pos.y, pos.z);
        }
    }
}
