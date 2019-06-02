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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger (bullet)");

        if (collision.GetComponent<Asteroid>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision (bullet)");
    }
}
