using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPickUpAudioPlayer;

    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject coinPickUpAudioPlayerInstance = Instantiate(coinPickUpAudioPlayer, transform.position, Quaternion.identity);
            
            coinPickUpAudioPlayerInstance.GetComponent<CoinPickUpSound>().SetCoinValue(coinValue);
            
            CoinCounterText.instance.IncrementCounter(coinValue);
        
            Destroy(this.gameObject);
        }
    }
}
