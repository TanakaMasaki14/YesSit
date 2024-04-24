using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.0f; // �ړ����x
    public float deceleration = 0.0f; // �����x
    public float fixedZ = 0.0f; // �Œ肷��Z���̒l
    public float rotationSpeed = 100f; // ��]���x

    private Vector3 velocity;
    // �v���C���[�̏����ʒu��ۑ�����ϐ�
    private Vector3 initialPosition;
    void Update()
    {
        // �㉺���E�̈ړ����擾
        float verticalmoveInput = Input.GetAxis("VerticalMove");
        float horizontalmoveInput = Input.GetAxis("HorizontalMove");

        // �㉺���E�̉�]���擾
        float verticalrotatitonInput = Input.GetAxis("VerticalRotation");
        float horizontalrotationInput = Input.GetAxis("HorizontalRotation");

        // �ړ��x�N�g�����v�Z
        Vector3 movement = new Vector3(horizontalmoveInput, verticalmoveInput, 0) * speed * Time.deltaTime;

        // WASD�L�[�ɂ���]
        float rotationY = horizontalrotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalrotatitonInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);

        // Z�����Œ�
        movement.z = 0;

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

    // ������
    private void Start()
    {
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition = GameObject.FindGameObjectWithTag("Object").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;

            SceneManager.LoadScene("tanaka");

            // �J�[�\����\�����A�J�[�\�������b�N����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}