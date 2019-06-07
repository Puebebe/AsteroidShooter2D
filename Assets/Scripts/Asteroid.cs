using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [HideInInspector] public bool doNothing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doNothing)
            return;

        Asteroid other = collision.GetComponent<Asteroid>();

        if (other != null)
        {
            AsteroidSpawner ass = FindObjectOfType<AsteroidSpawner>();
            ass.StartCoroutine(ass.RespawnAsteroidAfterOneSecond());
            ass.StartCoroutine(ass.RespawnAsteroidAfterOneSecond());

            other.doNothing = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.GetComponent<Ship>() != null)
        {
            if ((Vector2)collision.transform.position == Vector2.zero)
                Destroy(gameObject);

            collision.GetComponent<Ship>().Destroy();
        }
    }
}
