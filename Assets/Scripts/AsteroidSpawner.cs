using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] int gridSize;

    void Start()
    {
        StartCoroutine(StartSmoothly());

        for (int x = -gridSize / 2 ; x < gridSize / 2; x++)
        {
            for (int y = -gridSize / 2; y < gridSize / 2; y++)
            {
                GameObject asteroid = Instantiate(asteroidPrefab, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
                asteroid.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;
            }
        }
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
