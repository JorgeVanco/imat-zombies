using System;
using System.Collections;
using UnityEngine;

public class ZombieSpawner : Spawner
{
    [SerializeField] private ZombieManager zombieManager; // Reference to ZombieManager


    private Action onZombieKilled;

    public void StartSpawning(int zombieCount, Action onZombieKilledCallback) {
        onZombieKilled = onZombieKilledCallback;

        for (int i = 0; i < zombieCount; i++) {
            Spawn();
        }
    }

    private void Start() {
        if (zombieManager == null) {
            Debug.LogError("ZombieManager is not assigned in the Inspector!");
            return;
        }
    }

    public override void SpawningFunction(Vector3 randomSpawnPoint) {
        // Randomly choose a zombie type
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
