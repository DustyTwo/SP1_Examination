using System;
using TMPro;
using UnityEngine;

public class CoinCounterText : MonoBehaviour
{
    public static CoinCounterText instance;
    
    private TMP_Text coinCounterText;
    
    private int coinCount = 0;
    private string defaultCoinText;

    private float timer;
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        coinCounterText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        defaultCoinText = coinCounterText.text;
        
        UpdateCoinText();
    }

    public void IncrementCounter(int amount = 1)
    {
        coinCount += amount;
        
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinCounterText.text = defaultCoinText + coinCount;
    }
}
