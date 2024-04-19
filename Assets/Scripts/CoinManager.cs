using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int coins;
    public TextMeshProUGUI coinText; 

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinUI();
    }

    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateCoinUI();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coins.ToString();
    }

    
    public void GiveTestCoins()
    {
        AddCoins(10);
    }
}
