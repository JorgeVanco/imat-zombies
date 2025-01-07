using System;
using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private ZombieManager zombieManager; // Reference to ZombieManager
    [SerializeField] private Vector2 xSpawnLimits;
    [SerializeField] private Vector2 zSpawnLimits;
    [SerializeField] private readonly bool isSpawning = true;
    [SerializeField] private readonly float spawnInterval = 1f;

    private Action onZombieKilled;

    public void StartSpawning(int zombieCount, Action onZombieKilledCallback) {
        onZombieKilled = onZombieKilledCallback;

        for (int i = 0; i < zombieCount; i++) {
            SpawnRandomZombie();
        }
    }

    private void Start() {
        if (zombieManager == null) {
            Debug.LogError("ZombieManager is not assigned in the Inspector!");
            return;
        }
    }

    private IEnumerator SpawnZombies() {
        while (isSpawning) {
            SpawnRandomZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnRandomZombie() {
        // Generate a random spawn point within the defined limits (on the X-Z plane)
        Vector3 randomSpawnPoint = new Vector3(
            UnityEngine.Random.Range(xSpawnLimits.x, xSpawnLimits.y),
            50f, // Start the ray high above the terrain to ensure it hits
            UnityEngine.Random.Range(zSpawnLimits.x, zSpawnLimits.y)
        );

        // Raycast to find the ground
        Ray ray = new Ray(randomSpawnPoint, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
            // Adjust the spawn point to be at the terrain's surface
            randomSpawnPoint.y = hit.point.y;

            // Check if the hit surface is valid (e.g., terrain or ground layer)
            if ((1 << hit.collider.gameObject.layer & LayerMask.GetMask("Ground")) != 0) {
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
                    Zombie zombie = spawnedZombie.GetComponent<Zombie>();
                    zombie.OnDeath += onZombieKilled;
                }

            }
        }
    }

}
