using System;

public static class ScoreManager
{
    public static int Score { get; private set; }
    public static int HighScore { get; private set; }

    public static int WaveCount { get; private set; }
    public static int HighWaveCount { get; private set; }

    public static event Action NewWave;

    public static void Reset()
    {
        Score = 0;
        WaveCount = 0;
    }

    public static void AddPoint()
    {
        if (GameOver.IsGameOver)
            return;

        Score++;

        if (Score > HighScore)
            HighScore = Score;
    }

    public static void AddWave()
    {
        if (GameOver.IsGameOver)
            return;

        WaveCount++;

        if (WaveCount > HighWaveCount)
            HighWaveCount = WaveCount;

        NewWave?.Invoke();
    }
}
