using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] int gridSize;
    [SerializeField] Camera cam;
    Vector2 camPos;
    float xView, yView;

    void Start()
    {
        StartCoroutine(StartSmoothly());

        camPos = cam.transform.position;
        xView = cam.orthographicSize * cam.aspect;
        yView = cam.orthographicSize;

        for (int x = -gridSize / 2 ; x < gridSize / 2; x++)
        {
            for (int y = -gridSize / 2; y < gridSize / 2; y++)
            {
                if (x + 0.5f < camPos.x + xView && x + 0.5f > camPos.x - xView && y + 0.5f < camPos.y + yView && y + 0.5f > camPos.y - yView)
                    continue;
                
                GameObject asteroid = Instantiate(asteroidPrefab, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
                asteroid.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;
            }
        }
    }

    public IEnumerator RespawnAsteroidAfterOneSecond()
    {
        yield return new WaitForSeconds(1);

        int x, y;
        camPos = cam.transform.position;

        do
        {
            x = Random.Range((int)camPos.x - gridSize / 2, (int)camPos.x + gridSize / 2);
            y = Random.Range((int)camPos.y - gridSize / 2, (int)camPos.y + gridSize / 2);
        } while (x + 0.5f < camPos.x + xView && x + 0.5f > camPos.x - xView && y + 0.5f < camPos.y + yView && y + 0.5f > camPos.y - yView);

        GameObject asteroid = Instantiate(asteroidPrefab, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
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
