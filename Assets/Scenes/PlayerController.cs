using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度
    public float speed = 5.0f; // 移動速度
    public float deceleration = 5.0f; // 減速度
    public float fixedZ = 0.0f; // 固定するZ軸の値

    private Vector3 velocity;

    void Update()
    {
        // 上下左右の移動を取得
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // WASDキーによる回転
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);

        // 矢印キーによる移動
        float moveHorizontal = Input.GetAxis("HorizontalMove");
        float moveVertical = Input.GetAxis("VerticalMove");

        // 移動ベクトルを計算
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * speed * Time.deltaTime;

        // Z軸を固定
        movement.z = 0;

        // オブジェクトの向きに応じて回転
        if (movement.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // 移動ベクトルを加速度に適用
        velocity += movement;

        // 減速度を適用
        velocity -= velocity * deceleration * Time.deltaTime;

        // オブジェクトを移動
        transform.Translate(velocity);

        // Z軸を固定
        Vector3 newPosition = transform.position;
        newPosition.z = fixedZ;
        transform.position = newPosition;
    }
}
