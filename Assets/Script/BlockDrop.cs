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
        // 初期位置を記録
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

        // 重力を無効化し、速度をリセット
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 元の位置に戻すフラグを立てる
        isReturning = true;
        float elapsedTime = 0f;
        float duration = 2f; // 2秒かけて戻る

        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最後に位置を初期位置に正確に合わせる
        transform.position = initialPosition;
        isReturning = false;

        // クールダウンの開始
        StartCoroutine(CoolDown(2f)); // 2秒のクールダウン
    }

    IEnumerator CoolDown(float coolDownTime)
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(coolDownTime);
        isCoolingDown = false;
    }
}