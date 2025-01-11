using System;
using System.Collections;
using UnityEngine;
public abstract class Spawner: MonoBehaviour
{
    protected Vector2 xSpawnLimits = new Vector2(-25, 20);
    protected Vector2 zSpawnLimits = new Vector2(-55, 13);

    public void Spawn(){
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

                SpawningFunction(randomSpawnPoint);

            }
        }
    }

    public abstract void SpawningFunction(Vector3 randomSpawnPoint);
}