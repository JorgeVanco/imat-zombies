using System;
using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private ZombieManager zombieManager; // Reference to ZombieManager
    [SerializeField] private Vector2 xSpawnLimits;
    [SerializeField] private Vector2 zSpawnLimits;
    [SerializeField] private bool isSpawning = true;
    [SerializeField] private float spawnInterval = 1f;

    public event Action<GameObject> onZombieSpawned;

    private void Start() {
        if (zombieManager == null) {
            Debug.LogError("ZombieManager is not assigned in the Inspector!");
            return;
        }

        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies() {
        while (isSpawning) {
            SpawnRandomZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnRandomZombie() {
        // Generate a random spawn point within the defined limits
        Vector3 randomSpawnPoint = new Vector3(
            UnityEngine.Random.Range(xSpawnLimits.x, xSpawnLimits.y),
            0f,
            UnityEngine.Random.Range(zSpawnLimits.x, zSpawnLimits.y)
        );

        // Randomly choose a zombie type (e.g., fast, slow, normal)
        int zombieType = UnityEngine.Random.Range(0, 3);

        GameObject spawnedZombie = null;
        switch (zombieType) {
            case 0:
                spawnedZombie = zombieManager.SpawnFastZombie(randomSpawnPoint);
                break;
            case 1:
                spawnedZombie = zombieManager.SpawnSlowZombie(randomSpawnPoint);
                break;
            case 2:
                spawnedZombie = zombieManager.SpawnNormalZombie(randomSpawnPoint);
                break;
        }

        if (spawnedZombie != null) {
            // Trigger the event for the spawned zombie
            onZombieSpawned?.Invoke(spawnedZombie);
        }
    }
}
