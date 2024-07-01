using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalEffect : MonoBehaviour
{

    // �Փˎ��ɍĐ�����p�[�e�B�N���V�X�e��
    public ParticleSystem Effect1;
    public ParticleSystem Effect2;
    public ParticleSystem Effect3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �p�[�e�B�N���G�t�F�N�g���Đ�
            if (Effect1 != null)
            {
                Effect1.Play();
            }
            if (Effect2 != null)
            {
                Effect2.Play();
            }
            if (Effect3 != null)
            {
                Effect3.Play();
            }
        }
    }
}
