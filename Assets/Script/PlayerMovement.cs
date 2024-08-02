using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // �ړ����x
    public float deceleration = 0.1f; // �����x
    public float fixedZ = 0.0f; // �Œ肷��Z���̒l
    public float rotationSpeed = 100f; // ��]���x

    private Vector3 velocity;

    void Update()
    {
        // �㉺���E�̈ړ����擾
        float verticalMoveInput = Input.GetAxis("VerticalMove");
        float horizontalMoveInput = Input.GetAxis("HorizontalMove");

        // �㉺���E�̉�]���擾
        float verticalRotationInput = Input.GetAxis("VerticalRotation");
        float horizontalRotationInput = Input.GetAxis("HorizontalRotation");

        // WASD�L�[�ɂ���]
        float rotationY = horizontalRotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalRotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);

        // �ړ��x�N�g�����v�Z (���[���h�X�y�[�X)
        Vector3 movement = new Vector3(horizontalMoveInput, verticalMoveInput, 0) * speed * Time.deltaTime;

        // Z�����Œ�
        movement.z = 0;

        // �ړ��x�N�g���������x�ɓK�p
        velocity += movement;

        // �����x��K�p
        velocity -= velocity * deceleration * Time.deltaTime;

        // �I�u�W�F�N�g���ړ� (���[���h�X�y�[�X)
        transform.Translate(velocity * Time.deltaTime, Space.World);

        // Z�����Œ�
        Vector3 newPosition = transform.position;
        newPosition.z = fixedZ;
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
