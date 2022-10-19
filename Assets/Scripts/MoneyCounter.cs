using UnityEngine;
using UnityEngine.Events;

public class MoneyCounter : MonoBehaviour
{
    private const string CoinsSaveKey = "CoinsAmount";
    
    public UnityEvent<int> OnCoinsChanged { get; } = new();
    private int CoinsAmount { get; set; }
    
    private void Awake()
    {
        int coins = SaveSystem.Get<int>(CoinsSaveKey);
        CoinsAmount = coins;
    }
    
    public void AddCoins(int amount)
    {
        CoinsAmount += amount;
        OnCoinsChanged?.Invoke(CoinsAmount);
        SaveSystem.Set(CoinsSaveKey, CoinsAmount);
    }

    public bool TryTakeCoins(int amount)
    {
        if (CoinsAmount - amount < 0) return false;

        CoinsAmount -= amount;
        OnCoinsChanged?.Invoke(CoinsAmount);
        SaveSystem.Set(CoinsSaveKey, CoinsAmount);
        return true;
    }
}