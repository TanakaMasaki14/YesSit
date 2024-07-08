using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengePosition : MonoBehaviour
{
    public GameObject player;
    public GameObject nextPortal;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            player.transform.position = nextPortal.transform.position;
        }
    }
}