using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ƒS[ƒ‹‚Ìˆ—
            SceneManager.LoadScene("GameOver");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}