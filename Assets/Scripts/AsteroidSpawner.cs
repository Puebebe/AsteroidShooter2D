using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
    public static AsteroidSpawner Instance { get; private set; }

    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] int gridSize;
    static int spawnRange;
    List<GameObject> asteroids;
    Collider2D[] results = new Collider2D[2];
    const int ASTEROIDS_LAYER = 1 << 8;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        //StartCoroutine(StartSmoothly());
        asteroids = new List<GameObject>();
        spawnRange = gridSize / 2;

        for (int x = -spawnRange ; x < spawnRange; x++)
        {
            for (int y = -spawnRange; y < spawnRange; y++)
            {
                if (CameraController.view.Contains(new Vector2(x + 0.5f, y + 0.5f).Rotate(CameraController.cam.transform.rotation)))
                    continue;

                GameObject asteroid = Instantiate(asteroidPrefab, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
                asteroid.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;
                asteroids.Add(asteroid);
            }
        }
    }

    void FixedUpdate()
    {
        foreach (var a in asteroids)
        {
            if (!a.activeSelf)
                continue;
            
            if (Physics2D.OverlapCircleNonAlloc(a.transform.position, 0.2f, results, ASTEROIDS_LAYER) > 1)
            {
                StartCoroutine(RespawnAsteroidAfterOneSecond(results[0].gameObject));
                StartCoroutine(RespawnAsteroidAfterOneSecond(results[1].gameObject));
            }
        }
    }

    public static IEnumerator RespawnAsteroidAfterOneSecond(GameObject asteroid)
    {
        asteroid.SetActive(false);
        yield return new WaitForSeconds(1);

        int x, y;
        Vector2 camShift = new Vector2((int)CameraController.cam.transform.position.x, (int)CameraController.cam.transform.position.y);

        do
        {
            x = Random.Range(-spawnRange, spawnRange);
            y = Random.Range(-spawnRange, spawnRange);
        } while (CameraController.view.Contains(new Vector2(x + 0.5f, y + 0.5f).Rotate(CameraController.cam.transform.rotation) + camShift));

        asteroid.transform.position = new Vector2(x + 0.5f, y + 0.5f) + camShift;
        asteroid.SetActive(true);
        asteroid.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;
    }

    IEnumerator StartSmoothly()
    {
        Time.fixedDeltaTime = 0.1f;

        float[] lastDeltaTime = new float[4];

        for (int i = 0; i < lastDeltaTime.Length; i++)
            lastDeltaTime[i] = Time.deltaTime;

        yield return new WaitUntil(() => {
            float averageDeltaTime = 0f;

            for (int i = 0; i < lastDeltaTime.Length; i++)
                averageDeltaTime += lastDeltaTime[i];

            averageDeltaTime = (averageDeltaTime + Time.deltaTime) / (lastDeltaTime.Length + 1);
            
            for (int i = lastDeltaTime.Length - 1; i > 0;)
                lastDeltaTime[i] = lastDeltaTime[--i];

            lastDeltaTime[0] = Time.deltaTime;
            
            return averageDeltaTime < 0.0167f;
        });

        Time.fixedDeltaTime = 0.02f;
    }
}
