using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x

    void Update()
    {
        // �㉺���E�̉�]���擾
        float verticalrotatitonInput = Input.GetAxis("VerticalRotation");
        float horizontalrotationInput = Input.GetAxis("HorizontalRotation");

        // WASD�L�[�ɂ���]
        float rotationY = horizontalrotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalrotatitonInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}