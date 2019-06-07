using UnityEngine;

public class Ship : MonoBehaviour
{
    void Start()
    {
        GameState.GameEnded += Reset;
    }

    public void Destroy()
    {
        GameState.EndGame();
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
