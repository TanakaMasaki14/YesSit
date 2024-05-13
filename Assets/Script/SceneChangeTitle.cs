using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTitle : MonoBehaviour
{
    // シーン名を指定
    public string targetSceneName;
    // 遷移エフェクト用のスクリプト
    public Fade fadeController;// フェード制御用のFadeクラスインスタンス

    // Start is called before the first frame update
    void Start()
    {
       fadeController = GetComponent<Fade>();// Fadeクラスのインスタンスを取得
    }

    // Update is called once per frame
    void Update()
    {
        // SPACEキーが押されたらシーンを切り替える
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // フェードアウト開始
            fadeController.FadeOut(1.0f, () =>
            {
                SceneManager.LoadScene(targetSceneName);
            });
        }
    }
}
