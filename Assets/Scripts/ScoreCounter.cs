using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private const string BestScoreSaveKey = "BestScore"; 
    
    public UnityEvent<int, int> OnScoreChanged { get; } = new();
    public int Score { get; private set; }
    private int BestScore { get; set; }

    private void Awake()
    {
        int bestScore = SaveSystem.Get<int>(BestScoreSaveKey);
        BestScore = bestScore;
    }

    public void IncreaseScore()
    {
        Score++;
        if (Score > BestScore)
        {
            BestScore = Score;
            SaveSystem.Set(BestScoreSaveKey, BestScore);
        }
        
        OnScoreChanged?.Invoke(Score, BestScore);
    }

    public void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score, BestScore);
    }
}