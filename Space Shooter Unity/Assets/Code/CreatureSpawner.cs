using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject owlPrefab;
    public GameObject mosquitoPrefab;
    public GameObject mothPrefab;

    public int numberOfOwlsToSpawn;
    public int numberOfMosquitosToSpawn;
    public int numberOfMothsToSpawn;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        SpawnCreatures();
    }

    void SpawnCreatures()
    {
        for (int i = 0; i < numberOfOwlsToSpawn; i++)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);

            Vector3 spawnPosition = new Vector3(randX, randY, 0);

            print(spawnPosition);

            Instantiate(owlPrefab, spawnPosition, transform.rotation, transform);
        }

        for (int i = 0; i < numberOfMosquitosToSpawn; i++)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);

            Vector3 spawnPosition = new Vector3(randX, randY, 0);

            Instantiate(mosquitoPrefab, spawnPosition, transform.rotation, transform);
        }

        for (int i = 0; i < numberOfMothsToSpawn; i++)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);

            Vector3 spawnPosition = new Vector3(randX, randY, 0);

            Instantiate(mothPrefab, spawnPosition, transform.rotation, transform);
        }
    }
}
