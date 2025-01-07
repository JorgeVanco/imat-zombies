using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance; // Singleton instance

    [SerializeField] private GameObject bulletPrefab; // Bullet prefab to use
    [SerializeField] private int poolSize = 20; // Initial pool size

    private readonly Queue<Bullet> bulletPool = new Queue<Bullet>();

    private void Awake() {
        // Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Preload bullets into the pool
        for (int i = 0; i < poolSize; i++) {
            AddBulletToPool();
        }
    }

    private void AddBulletToPool() {
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.SetActive(false); // Deactivate bullet initially
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bulletPool.Enqueue(bullet);
    }

    public Bullet GetBullet() {
        // If no bullets are available, add more to the pool
        if (bulletPool.Count == 0) AddBulletToPool();

        Bullet bullet = bulletPool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(Bullet bullet) {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}

