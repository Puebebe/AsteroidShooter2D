using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float bulletSpeed = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
