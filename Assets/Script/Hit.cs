using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �����v���C���[�����̃I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (collision.gameObject.CompareTag("Object")) // �������́A�G�ꂽ�I�u�W�F�N�g������̃^�O�������Ă���ꍇ
        {
            // �Q�[���I�[�o�[�V�[���Ɉړ�����
            SceneManager.LoadScene("GameOver");
        }
    }
}
