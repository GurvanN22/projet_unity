using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearZone : MonoBehaviour
{
    // This class make enemy appear in the game in this zone (collider zone)

    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;

    public GameObject enemyPrefab2;
    public float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy()
    {
        
        // We set a random point in the zone to spawn the enemy
        Vector3 randomPosition = new Vector3(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), transform.position.y, Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));

        // We choose a random enemy prefab to instantiate
        GameObject enemyPrefabToInstantiate = enemyPrefab;
        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                enemyPrefabToInstantiate = enemyPrefab;
                break;
            case 2:
                enemyPrefabToInstantiate = enemyPrefab1;
                break;
            case 3:
                enemyPrefabToInstantiate = enemyPrefab2;
                break;
        }

        // Instantiate the enemy at the random position
        GameObject enemy = Instantiate(enemyPrefabToInstantiate, randomPosition, Quaternion.identity);

        // Set the enemy parent to the zone
        enemy.transform.SetParent(transform);

        // Wait 5 seconds to spawn another enemy
        Invoke("spawnEnemy", spawnTime);
    }
}