using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] int gridSize;

    void Start()
    {
        for (int x = -gridSize / 2 ; x < gridSize / 2; x++)
        {
            for (int y = -gridSize / 2; y < gridSize / 2; y++)
            {
                GameObject asteroid = Instantiate(asteroidPrefab, new Vector2(x + 0.5f, y + 0.5f), Quaternion.identity);
                asteroid.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle;
            }
        }
    }
}
