using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ‰ñ“]‘¬“x

    void Update()
    {
        // ã‰º¶‰E‚Ì‰ñ“]‚ğæ“¾
        float verticalrotatitonInput = Input.GetAxis("VerticalRotation");
        float horizontalrotationInput = Input.GetAxis("HorizontalRotation");

        // WASDƒL[‚É‚æ‚é‰ñ“]
        float rotationY = horizontalrotationInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalrotatitonInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}