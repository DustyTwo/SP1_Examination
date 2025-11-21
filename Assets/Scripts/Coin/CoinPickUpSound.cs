using TMPro;
using UnityEngine;

public class CoinPickUpSound : MonoBehaviour
{
    [SerializeField] private float timeToLive = 1f;
    private float timeAlive;
    
    private TMP_Text coinPickUpText;
    private int coinValue;
    
    //private AudioSource audioSource;
    
    void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        coinPickUpText = GetComponentInChildren<TMP_Text>();

    }
    
    
    void Start()
    {
        //audioSource.Play();
    }
    
    void Update()
    {
        timeAlive += Time.deltaTime;
        
        if(timeAlive >= timeToLive)
        {
            Destroy(this.gameObject);
        }
       //if(timeAlive >= timeToLive && !audioSource.isPlaying)
       //{
       //    Destroy(this.gameObject);
       //}
    }

    public void SetCoinValue(int amount)
    {
        coinValue = amount;
        setCoinText();
    }

    private void setCoinText()
    {
        coinPickUpText.text = "+" + coinValue;
    }
    
}
