using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // もしプレイヤーが他のオブジェクトに触れた場合
        if (collision.gameObject.CompareTag("Object")) // もしくは、触れたオブジェクトが特定のタグを持っている場合
        {
            // ゲームオーバーシーンに移動する
            SceneManager.LoadScene("GameOver");
        }
    }
}
