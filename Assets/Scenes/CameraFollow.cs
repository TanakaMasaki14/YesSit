using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �v���C���[��Transform

    void Update()
    {
        if (target != null)
        {
            // �v���C���[�̈ʒu��ǐ�
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
