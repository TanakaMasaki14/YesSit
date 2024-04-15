using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f; // �ړ����x
    public float deceleration = 0.0f; // �����x

    private Vector3 velocity;

    void Update()
    {
        // �㉺���E�̈ړ����擾
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // �ړ��x�N�g�����v�Z
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        // �ړ��x�N�g���������x�ɓK�p
        velocity += movement;

        // �����x��K�p
        velocity -= velocity * deceleration * Time.deltaTime;

        // �I�u�W�F�N�g���ړ�
        transform.Translate(velocity);
    }
}
