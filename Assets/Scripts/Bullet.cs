using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float bulletSpeed = 2f;
    float bulletLifespan = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, bulletLifespan);
    }

    public void Launch(Vector2 baseVelocity)
    {
        rb.velocity = baseVelocity + (Vector2)transform.up * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameState.Score++;
        AsteroidSpawner.Instance.StartCoroutine(AsteroidSpawner.RespawnAsteroidAfterOneSecond(collision.gameObject));
        Destroy(gameObject);
    }
}
