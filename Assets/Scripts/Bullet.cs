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
}
