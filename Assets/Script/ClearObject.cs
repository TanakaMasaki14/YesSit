using UnityEngine;

public class ClearObject : MonoBehaviour
{
    public GameObject objectToMove; // �ړ����������I�u�W�F�N�g
    public float Yspeed = 0f;         // ������̑��x
    public float Zspeed = 0f;        // ���s�������̑��x

    void Update()
    {
        if (objectToMove != null)
        {
            // �I�u�W�F�N�g���΂߉��Ɉړ�������
            objectToMove.transform.position += new Vector3(0, Yspeed * Time.deltaTime, Zspeed * Time.deltaTime);
        }
    }
}
