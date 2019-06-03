using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static event Action<bool> GameEnded;

    public void EndGame()
    {
        GameEnded(true);
        ChangeSimulationState(false);
    }

    public void StartGame()
    {
        GameEnded(false);
        ChangeSimulationState(true);
    }

    private void ChangeSimulationState(bool state)
    {
        Time.timeScale = state ? 1 : 0;
    }
}
