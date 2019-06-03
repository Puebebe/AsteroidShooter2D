using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameState gameState;

    void Start()
    {
        GameState.GameEnded += Reset;
    }

    public void Destroy()
    {
        gameState.EndGame();
    }

    void Reset(bool toDestroy)
    {
        gameObject.SetActive(!toDestroy);

        if (!toDestroy)
        {
            transform.position = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
    }
}
