using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // プレイヤーのTransform

    void Update()
    {
        if (target != null)
        {
            // プレイヤーの位置を追跡
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
