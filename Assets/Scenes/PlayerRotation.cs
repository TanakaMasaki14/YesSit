using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度

    void Update()
    {
        // 上下左右の回転を取得
        float verticalInput = Input.GetAxis("VerticalRotation");
        float horizontalInput = Input.GetAxis("HorizontalRotation");

        // WASDキーによる回転
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}