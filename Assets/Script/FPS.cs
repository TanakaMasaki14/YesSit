using UnityEngine;

public class FPS : MonoBehaviour
{
    void Start()
    {
        // 目標のFPSを設定
        Application.targetFrameRate = 60;
    }
}
