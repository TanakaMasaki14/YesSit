using UnityEngine;

public class ClearObject : MonoBehaviour
{
    public GameObject objectToMove; // 移動させたいオブジェクト
    public float Yspeed = 0f;         // 上方向の速度
    public float Zspeed = 0f;        // 奥行き方向の速度

    void Update()
    {
        if (objectToMove != null)
        {
            // オブジェクトを斜め奥に移動させる
            objectToMove.transform.position += new Vector3(0, Yspeed * Time.deltaTime, Zspeed * Time.deltaTime);
        }
    }
}
