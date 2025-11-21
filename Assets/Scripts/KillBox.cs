using System;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    [SerializeField] private GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
            
            CameraScript.instance.ResetToPlayer();
        }
    }
}
