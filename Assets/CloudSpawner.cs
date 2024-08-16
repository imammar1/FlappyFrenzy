using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab; // Reference to the Cloud prefab
    public float spawnRate = 5f; // Time between spawns
    public float spawnHeightMin = -3f; // Minimum Y position for spawning
    public float spawnHeightMax = 3f; // Maximum Y position for spawning
    public float spawnXPosition = 10f; // X position where clouds spawn
    public float cloudSpeed = 2f; // Speed at which clouds move

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnCloud();
            timer = 0;
        }
    }

    void SpawnCloud()
    {
        float spawnYPosition = Random.Range(spawnHeightMin, spawnHeightMax);

        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0);
        GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);

        newCloud.GetComponent<Rigidbody2D>().velocity = new Vector2(-cloudSpeed, 0);

        // Destroy cloud after it moves off-screen
        Destroy(newCloud, 10f);
    }
}

