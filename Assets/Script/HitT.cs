using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitT : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // プレイヤーの初期位置を保存
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            var impulseSource = GetComponent<CinemachineImpulseSource>();
            impulseSource.GenerateImpulse();

            // プレイヤーの位置を初期位置に戻す
            other.transform.position = initialPosition;

            // 0.8秒後にシーンをロードする
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Tutorial");
    }
}