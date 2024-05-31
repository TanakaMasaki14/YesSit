using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmisionController : MonoBehaviour
{
    public Material emissiveMaterial;
    public Color activeColor = Color.red;
    public float intensity = 3.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // �X�y�[�X�L�[�������Ă���ԁA�ԐF�ɔ���
            Color finalColor = activeColor * Mathf.LinearToGammaSpace(intensity);
            emissiveMaterial.SetColor("_EmissionColor", finalColor);
            DynamicGI.SetEmissive(GetComponent<Renderer>(), finalColor);
        }
        else
        {
            // �X�y�[�X�L�[�𗣂��Ɣ������Ȃ�
            emissiveMaterial.SetColor("_EmissionColor", Color.black);
            DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.black);
        }
    }
}
