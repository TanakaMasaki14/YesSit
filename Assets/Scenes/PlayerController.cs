using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f; // 移動速度
    public float deceleration = 0.0f; // 減速度

    private Vector3 velocity;

    void Update()
    {
        // 上下左右の移動を取得
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // 移動ベクトルを計算
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        // 移動ベクトルを加速度に適用
        velocity += movement;

        // 減速度を適用
        velocity -= velocity * deceleration * Time.deltaTime;

        // オブジェクトを移動
        transform.Translate(velocity);
    }
}
