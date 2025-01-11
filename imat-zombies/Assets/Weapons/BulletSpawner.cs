using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawner : MonoBehaviour
{
    private Vector2 xSpawnLimits = new Vector2(-25, 20);
    private Vector2 zSpawnLimits = new Vector2(-55, 13);
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
            SpawnBullet();
        }
    }
    public void SpawnBullet() {
        Vector3 randomSpawnPoint = new Vector3(
            UnityEngine.Random.Range(xSpawnLimits.x, xSpawnLimits.y),
            50f, // Start the ray high above the terrain to ensure it hits
            UnityEngine.Random.Range(zSpawnLimits.x, zSpawnLimits.y)
        );

        // Raycast to find the ground
        Ray ray = new Ray(randomSpawnPoint, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
            // Adjust the spawn point to be at the terrain's surface
            randomSpawnPoint.y = hit.point.y + 1; // So that the don't keep appearing under the map

            // Check if the hit surface is valid (e.g., terrain or ground layer)
            if ((1 << hit.collider.gameObject.layer & LayerMask.GetMask("Ground")) != 0) {

                GameObject bullet = Object.Instantiate(bulletPrefab);
                bullet.transform.position = randomSpawnPoint;

            }
        }
    }
}
