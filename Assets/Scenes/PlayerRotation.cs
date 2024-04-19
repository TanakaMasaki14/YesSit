using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x

    void Update()
    {
        // �㉺���E�̉�]���擾
        float verticalInput = Input.GetAxis("VerticalRotation");
        float horizontalInput = Input.GetAxis("HorizontalRotation");

        // WASD�L�[�ɂ���]
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}