using UnityEngine.Events;

public static class ScoreCounter
{
    private static int BestScore { get; set; }
    public static int Score { get; set; }
    public static UnityEvent<int, int> OnScoreChanged { get; } = new();

    public static void IncreaseScore()
    {
        BestScore = ++Score > BestScore ? Score : BestScore;
        OnScoreChanged?.Invoke(Score, BestScore);
    }

    public static void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score, BestScore);
    }
}
