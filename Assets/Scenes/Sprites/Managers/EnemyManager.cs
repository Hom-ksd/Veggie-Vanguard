using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> transforms = new List<Transform>();

    [SerializeField]
    private float initialSpawnCooldown = 5f;
    [SerializeField]
    private float cooldownDecreaseRate = 0.05f; // How much the cooldown decreases per second
    [SerializeField]
    private float minSpawnCooldown = 0.2f; // Minimum cooldown time to avoid infinite spawning

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();
    [SerializeField]
    private float spawnTimer;

    private void Awake()
    {
        Transform[] transformArray = gameObject.GetComponentsInChildren<Transform>();

        for (int i = 1; i < transformArray.Length; i++)
        {
            transforms.Add(transformArray[i]);
        }

        spawnTimer = initialSpawnCooldown;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = Mathf.Max(minSpawnCooldown, initialSpawnCooldown - Time.time * cooldownDecreaseRate);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomTransform = Random.Range(0, transforms.Count);
        Transform spawnTransform = transforms[randomTransform];

        int randomEnemy = Random.Range(0, enemies.Count);
        GameObject enemyPrefab = enemies[randomEnemy];

        Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity);
    }
}
