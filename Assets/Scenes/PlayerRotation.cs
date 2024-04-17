using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x

    void Update()
    {
        // �㉺���E�̈ړ����擾
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // WASD�L�[�ɂ���]
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}
