using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearZone : MonoBehaviour
{
    // This class make enemy appear in the game in this zone (collider zone)

    public GameObject enemyPrefab;
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
        float x = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        float z = Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2);
        // Spawn enemy
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(x, transform.position.y, z), Quaternion.identity);
        // Set the enemy parent to the zone
        enemy.transform.SetParent(transform);
        // Wait 5 seconds to spawn another enemy
        Invoke("spawnEnemy", spawnTime);
    }
}
