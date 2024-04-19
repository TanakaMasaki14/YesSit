using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ‰ñ“]‘¬“x

    void Update()
    {
        // ã‰º¶‰E‚Ì‰ñ“]‚ğæ“¾
        float verticalInput = Input.GetAxis("VerticalRotation");
        float horizontalInput = Input.GetAxis("HorizontalRotation");

        // WASDƒL[‚É‚æ‚é‰ñ“]
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationX, rotationY, 0);
    }
}