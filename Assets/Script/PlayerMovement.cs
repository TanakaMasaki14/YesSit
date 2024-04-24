using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.0f; // �ړ����x
    public float deceleration = 0.0f; // �����x
    public float fixedZ = 0.0f; // �Œ肷��Z���̒l

    private Vector3 velocity;

    void Update()
    {
        // �㉺���E�̈ړ����擾
        float verticalInput = Input.GetAxis("VerticalMove");
        float horizontalInput = Input.GetAxis("HorizontalMove");

        // �ړ��x�N�g�����v�Z
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

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

        // �v���C���[�̏����ʒu��ۑ�����ϐ�
    private Vector3 initialPosition;

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

            // �Q�[���I�[�o�[�V�[���ւ̑J��
            SceneManager.LoadScene("tanaka");

            // �J�[�\����\�����A�J�[�\�������b�N����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}