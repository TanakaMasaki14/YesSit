using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.0f; // 移動速度
    public float deceleration = 0.0f; // 減速度
    public float fixedZ = 0.0f; // 固定するZ軸の値
    public float rotationSpeed = 100f; // 回転速度

    private Vector3 velocity;
    // プレイヤーの初期位置を保存する変数
    private Vector3 initialPosition;
    void Update()
    {
        // 上下左右の移動を取得
        float verticalmoveInput = Input.GetAxis("VerticalMove");
        float horizontalmoveInput = Input.GetAxis("HorizontalMove");

        // 上下左右の回転を取得
        float verticalrotatitonInput = Input.GetAxis("VerticalRotation");
        float horizontalrotationInput = Input.GetAxis("HorizontalRotation");

        // 移動ベクトルを計算
        Vector3 movement = new Vector3(horizontalmoveInput, verticalmoveInput, 0) * speed * Time.deltaTime;

        // WASDキーによる回転
        float rotationY = horizontalrotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalrotatitonInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);

        // Z軸を固定
        movement.z = 0;

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

    // 初期化
    private void Start()
    {
        // プレイヤーの初期位置を保存
        initialPosition = GameObject.FindGameObjectWithTag("Object").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            // プレイヤーの位置を初期位置に戻す
            other.transform.position = initialPosition;

            SceneManager.LoadScene("tanaka");

            // カーソルを表示し、カーソルをロック解除
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}