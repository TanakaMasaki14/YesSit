using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public GameObject wall;
    public GameObject tvFace;
    public GameObject portal;

    void Start()
    {
        
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �ǂ��o������
            wall.SetActive(true);

            // 1.5�b��ɃV�[�������[�h����
            StartCoroutine(LoadTVAfterDelay(1.5f, 1));
            // 3�b��Ƀ|�[�^���o������
            StartCoroutine(LoadTVAfterDelay(3.0f, 2));
        }
    }
    private IEnumerator LoadTVAfterDelay(float delay,int num)
    {
        if(num == 1)
        {
            yield return new WaitForSeconds(delay);
            tvFace.SetActive(true);
        }
        else if(num == 2)
        {
            yield return new WaitForSeconds(delay);
            portal.SetActive(true);
        }
    }
}
