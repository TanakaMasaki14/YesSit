using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTitle : MonoBehaviour
{
    // �V�[�������w��
    public string targetSceneName;
    // �J�ڃG�t�F�N�g�p�̃X�N���v�g
    public Fade fadeController;// �t�F�[�h����p��Fade�N���X�C���X�^���X

    // Start is called before the first frame update
    void Start()
    {
       fadeController = GetComponent<Fade>();// Fade�N���X�̃C���X�^���X���擾
    }

    // Update is called once per frame
    void Update()
    {
        // SPACE�L�[�������ꂽ��V�[����؂�ւ���
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // �t�F�[�h�A�E�g�J�n
            fadeController.FadeOut(1.0f, () =>
            {
                SceneManager.LoadScene(targetSceneName);
            });
        }
    }
}
