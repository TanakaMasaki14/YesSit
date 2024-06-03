using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitT : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // �v���C���[�̏����ʒu��ۑ�
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            var impulseSource = GetComponent<CinemachineImpulseSource>();
            impulseSource.GenerateImpulse();

            // �v���C���[�̈ʒu�������ʒu�ɖ߂�
            other.transform.position = initialPosition;

            // 0.8�b��ɃV�[�������[�h����
            StartCoroutine(LoadSceneAfterDelay(0.8f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Tutorial");
    }
}