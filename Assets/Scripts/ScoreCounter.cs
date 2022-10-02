using System;

public static class ScoreCounter
{
    private static int BestScore { get; set; }
    public static int Score { get; set; }
    public static Action<int, int> OnScoreChanged { get; set; }

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
