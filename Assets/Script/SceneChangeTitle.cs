using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTitle : MonoBehaviour
{
    // シーン名を指定
    public string targetSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // SPACEキーが押されたらシーンを切り替える
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
