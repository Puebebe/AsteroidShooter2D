using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [HideInInspector] public bool doNothing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doNothing)
            return;

        Debug.Log("trigger (asteroid)");

        Asteroid other = collision.GetComponent<Asteroid>();

        if (other != null)
        {
            other.doNothing = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision (asteroid)");
    }
}
