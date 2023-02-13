using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab; //instanciar enemigos, guard la referemcoa del emnemy
    public GameObject[] powerupPrefabs;

    private int enemiesInScene;
    private float spawnRange = 9f; //limite plataforma--> para posición aleatoria  
    private int enemiesPerWave = 1;
  
    private void Start()
    {
        /*Instantiate(enemyPrefab, new Vector3(0, 0, 8), Quaternion.identity);*/

       /* Instantiate(enemyPrefab, RandomSpawnPosition(), Quaternion.identity); //llamar a la función*/
        SpawnEnemyWave(enemiesPerWave); //instancio enemigo
        
    }

    private void Update() //buscamos la cantidad de enemigos en la escena
    {
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        if (enemiesInScene <= 0)
        {
            //si me quedo sin enemigos en escena
            //aumwnto en un a los enemigos por oleada
            enemiesPerWave++;
            //llamo a una nuev oleada
            SpawnEnemyWave(enemiesPerWave++);
            
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
        int randomIndex = Random.Range(0, powerupPrefabs.Length); //doble powerup
        Instantiate(powerupPrefabs [randomIndex], RandomSpawnPosition(), Quaternion.identity); //aparecée un power up
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(),
            Quaternion.identity);
        }
    }
}
