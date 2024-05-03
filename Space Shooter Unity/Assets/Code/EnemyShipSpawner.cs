using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public int currentNumberOfShips;
    public int baseNumberOfShips;
    public int shipsToAddEachWave;
    public int currentWave;

    public List<EnemyShip> enemyShipPrefabs;
    public Transform spawnPoint;
    public Transform spawnPivot;

    void Start()
    {
        currentNumberOfShips = FindObjectsOfType<EnemyShip>().Length;
    }

    public void SpawnEnemyShips()
    {
        int enemyShipsToSpawn = baseNumberOfShips + currentWave;

        for (int i = 0; i < enemyShipsToSpawn; i++) 
        {
            int index = Random.Range(0, enemyShipPrefabs.Count);
            float zRotation = Random.Range(0, 360);

            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
            Instantiate(enemyShipPrefabs[index], spawnPoint.position, transform.rotation, null);
        }
    }

    /*public void CountEnemyShips()
    {
        currentNumberOfShips = FindObjectsOfType<EnemyShip>().Length;

        print(currentNumberOfShips);

        if (currentNumberOfShips == 1)
        {
            currentWave++;
            HUD.Instance.DisplayWave(currentWave);
            SpawnEnemyShips();

            if (currentWave > PlayerPrefs.GetInt("highestWave"))
            {
                PlayerPrefs.SetInt("highestWave", currentWave);
            }
        }
    }*/
}
