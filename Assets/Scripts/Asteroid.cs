using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger (asteroid)");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision (asteroid)");
    }
}
