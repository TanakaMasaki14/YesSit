using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    public GameObject target;
    private Vector3 initialPosition;
    private Rigidbody rb;
    private bool isReturning = false;
    private bool isCoolingDown = false;

    void Start()
    {
        // �����ʒu���L�^
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isReturning || isCoolingDown)
        {
            return;
        }

        Vector3 player = target.transform.position;
        float dis = Vector3.Distance(player, this.transform.position);

        if (dis < 3f)
        {
            SphereGravity();
        }
    }

    void SphereGravity()
    {
        rb.useGravity = true;
        StartCoroutine(ResetPositionAfterDelay(1f));
    }

    IEnumerator ResetPositionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // �d�͂𖳌������A���x�����Z�b�g
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // ���̈ʒu�ɖ߂��t���O�𗧂Ă�
        isReturning = true;
        float elapsedTime = 0f;
        float duration = 2f; // 2�b�����Ė߂�

        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �Ō�Ɉʒu�������ʒu�ɐ��m�ɍ��킹��
        transform.position = initialPosition;
        isReturning = false;

        // �N�[���_�E���̊J�n
        StartCoroutine(CoolDown(2f)); // 2�b�̃N�[���_�E��
    }

    IEnumerator CoolDown(float coolDownTime)
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(coolDownTime);
        isCoolingDown = false;
    }
}