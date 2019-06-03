using System;
using UnityEngine;

public class GameState : MonoBehaviour
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

    public void EndGame()
    {
        GameEnded(true);
        ChangeSimulationState(false);
    }

    public void StartGame()
    {
        Score = 0;
        GameEnded(false);
        ChangeSimulationState(true);
    }

    private void ChangeSimulationState(bool state)
    {
        Time.timeScale = state ? 1 : 0;
    }
}
