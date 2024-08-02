using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // 移動速度
    public float deceleration = 0.1f; // 減速度
    public float fixedZ = 0.0f; // 固定するZ軸の値
    public float rotationSpeed = 100f; // 回転速度

    private Vector3 velocity;

    void Update()
    {
        // 上下左右の移動を取得
        float verticalMoveInput = Input.GetAxis("VerticalMove");
        float horizontalMoveInput = Input.GetAxis("HorizontalMove");

        // 上下左右の回転を取得
        float verticalRotationInput = Input.GetAxis("VerticalRotation");
        float horizontalRotationInput = Input.GetAxis("HorizontalRotation");

        // WASDキーによる回転
        float rotationY = horizontalRotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalRotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);

        // 移動ベクトルを計算 (ワールドスペース)
        Vector3 movement = new Vector3(horizontalMoveInput, verticalMoveInput, 0) * speed * Time.deltaTime;

        // Z軸を固定
        movement.z = 0;

        // 移動ベクトルを加速度に適用
        velocity += movement;

        // 減速度を適用
        velocity -= velocity * deceleration * Time.deltaTime;

        // オブジェクトを移動 (ワールドスペース)
        transform.Translate(velocity * Time.deltaTime, Space.World);

        // Z軸を固定
        Vector3 newPosition = transform.position;
        newPosition.z = fixedZ;
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
