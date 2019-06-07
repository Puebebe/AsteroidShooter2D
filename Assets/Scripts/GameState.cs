using System;

public static class GameState
{
    public static event Action<bool> GameEnded;
    public static event Action<int> OnScoreChanged;
    public static int Score
    {
        get => score;

        set
        {
            score = value;
            OnScoreChanged(value);
        }
    }

    private static int score;

    public static void EndGame()
    {
        GameEnded(true);
        ChangeSimulationState(false);
    }

    public static void StartGame()
    {
        Score = 0;
        GameEnded(false);
        ChangeSimulationState(true);
    }

    private static void ChangeSimulationState(bool state)
    {
        UnityEngine.Time.timeScale = state ? 1 : 0;
    }
}
