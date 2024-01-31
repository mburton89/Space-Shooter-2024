using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public int maxX;
    public int maxY;
    public int minZ;
    public int maxZ;

    public int numberOfStarsToSpawn;

    public GameObject starPrefab;

    void Start()
    {
        SpawnStars();
    }

    void SpawnStars()
    {
        for (int i = 0; i < numberOfStarsToSpawn; i++)
        {
            float randX = Random.Range(-maxX, maxX);
            float randY = Random.Range(-maxY, maxY);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(randX, randY, randZ);

            Instantiate(starPrefab, spawnPosition, transform.rotation, transform);
        }
    }
}
