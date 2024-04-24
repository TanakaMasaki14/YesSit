using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度

    void Update()
    {
        // 上下左右の回転を取得
        float verticalrotatitonInput = Input.GetAxis("VerticalRotation");
        float horizontalrotationInput = Input.GetAxis("HorizontalRotation");

        // WASDキーによる回転
        float rotationY = horizontalrotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalrotatitonInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}