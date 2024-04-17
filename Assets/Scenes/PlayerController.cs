using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x
    public float speed = 5.0f; // �ړ����x
    public float deceleration = 5.0f; // �����x
    public float fixedZ = 0.0f; // �Œ肷��Z���̒l

    private Vector3 velocity;

    void Update()
    {
        // �㉺���E�̈ړ����擾
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // WASD�L�[�ɂ���]
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);

        // ���L�[�ɂ��ړ�
        float moveHorizontal = Input.GetAxis("HorizontalMove");
        float moveVertical = Input.GetAxis("VerticalMove");

        // �ړ��x�N�g�����v�Z
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * speed * Time.deltaTime;

        // Z�����Œ�
        movement.z = 0;

        // �I�u�W�F�N�g�̌����ɉ����ĉ�]
        if (movement.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // �ړ��x�N�g���������x�ɓK�p
        velocity += movement;

        // �����x��K�p
        velocity -= velocity * deceleration * Time.deltaTime;

        // �I�u�W�F�N�g���ړ�
        transform.Translate(velocity);

        // Z�����Œ�
        Vector3 newPosition = transform.position;
        newPosition.z = fixedZ;
        transform.position = newPosition;
    }
}
