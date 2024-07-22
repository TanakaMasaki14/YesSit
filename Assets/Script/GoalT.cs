using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalT : MonoBehaviour
{
    private Vector3 collisionPosition;
    private bool isCollided = false;
    public AudioClip goalSound;
    private AudioSource audioSource;
    public int StageNum;

    // ��ʒ����ɕ\������e�L�X�g
    public Text goalText;

    void Start()
    {
        // ������
        collisionPosition = transform.position;
        // �e�L�X�g���\���ɐݒ�
        if (goalText != null)
        {
            goalText.gameObject.SetActive(false);
        }
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = goalSound;
    }

    void Update()
    {
        // �Փˌ�͈ʒu���Œ�
        if (isCollided)
        {
            transform.position = collisionPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            // �Փˈʒu��ۑ�
            collisionPosition = transform.position;

            // �Փ˃t���O��ݒ�
            isCollided = true;

            var playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // �e�L�X�g��\��
            if (goalText != null)
            {
                goalText.gameObject.SetActive(true);
            }

            audioSource.Play();

            // 3�b��ɃV�[�������[�h����
            StartCoroutine(LoadSceneAfterDelay(3f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(StageNum == 0)
        {
            SceneManager.LoadScene("Stage1");
        }
        if (StageNum == 4)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
