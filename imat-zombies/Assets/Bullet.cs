using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    // Bullet speed, set by the spawner
    private float speed;
    private float damage = 10;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction, float bulletSpeed, float weaponDamage) {
        speed = bulletSpeed;
        damage = weaponDamage;
        // Reset the bullet's velocity and apply new velocity
        rb.AddForce(direction * bulletSpeed, ForceMode.Impulse);
        // Ensure gravity is off
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision) {
        // Add logic for hitting targets
        if (collision.gameObject.CompareTag("Zombie")) {
            collision.gameObject.GetComponent<Zombie>()?.TakeDamage(damage);
        }

        // Return bullet to the object pool
        BulletPool.Instance.ReturnBullet(this);
    }
}

