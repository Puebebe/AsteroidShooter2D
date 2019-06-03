using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameState gameState;

    public void Destroy()
    {
        gameState.EndGame();
        Destroy(gameObject);
    }
}
