using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance; 

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 30; // The gun has a 30 bullet magazine

    private readonly Queue<Bullet> bulletPool = new Queue<Bullet>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }


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
        if (bulletPool.Count == 0) {
            AddBulletToPool();
        }

        Bullet bullet = bulletPool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(Bullet bullet) {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}

