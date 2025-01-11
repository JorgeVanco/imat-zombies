using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawner : Spawner
{
    [SerializeField] private GameObject bulletPrefab;

    private GameManager gameManager;
    RoundManager roundManager;

    public void Start() {
        GameManager gameManager = GameManager.GetInstance();
        RoundManager roundManager = gameManager.GetRoundManager();
        roundManager.OnRoundEnded += SpawnBullets;
    }


    public void SpawnBulletsEndRound(int round) {
        SpawnBullets(2*round);
    }
    public void SpawnBullets(int quantity) {
        for (int i = 0; i < quantity; i++) {
            Spawn();
        }
    }

    public override void SpawningFunction(Vector3 randomSpawnPoint) {
        GameObject bullet = Object.Instantiate(bulletPrefab);
        bullet.transform.position = randomSpawnPoint;
    }
}
