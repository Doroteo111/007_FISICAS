using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab; //instanciar enemigos, guard la referemcoa del emnemy

    private float spawnRange = 9f; //posición aleatoria

    public int enemiesInScene;
    public int enemiesPerWave = 1;
    public GameObject powerupPrefab;

    private void Start()
    {
        /*Instantiate(enemyPrefab, new Vector3(0, 0, 8), Quaternion.identity);*/

       /* Instantiate(enemyPrefab, RandomSpawnPosition(), Quaternion.identity); //llamar a la función*/
        SpawnEnemyWave(enemiesPerWave);
        Instantiate(powerupPrefab, RandomSpawnPosition(),Quaternion.identity); //aparecée un power up
    }

    private void Update()
    {
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        if (enemiesInScene <= 0)
        {
            enemiesPerWave++;
            SpawnEnemyWave(enemiesPerWave++);
            Instantiate(powerupPrefab, RandomSpawnPosition(), Quaternion.identity);
        }
    }


    private Vector3 RandomSpawnPosition() //un valor para establecer un rango, y dentro generar una posicion aleatoria. Devuelve un vector
    {
        float randX = Random.Range(-spawnRange, spawnRange);
        float randZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randX, 0, randZ);
    }
    private void SpawnEnemyWave(int enemiesToSpawn) //tantas veces como quiera que aparezcan
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(),
            Quaternion.identity);
        }
    }
}
