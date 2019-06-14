using UnityEngine;

public class Ship : MonoBehaviour
{
    void Start()
    {
        GameState.GameEnded += Reset;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((Vector2)transform.position == Vector2.zero)
            AsteroidSpawner.Instance.StartCoroutine(AsteroidSpawner.RespawnAsteroidAfterOneSecond(collision.gameObject));

        GameState.EndGame();
    }
}
