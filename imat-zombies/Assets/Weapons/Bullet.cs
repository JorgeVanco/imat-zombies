using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private float damage;
    private float maxLifetime = 5f; // Maximum time before bullet is returned to pool
    private float lifetime;

    private void Update() {
        // Move bullet directly without physics
        transform.position += direction * (speed * Time.deltaTime);

        // Track lifetime and return to pool if exceeded
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime) {
            BulletPool.Instance.ReturnBullet(this);
        }
    }

    public void Initialize(Vector3 direction, float bulletSpeed, float weaponDamage) {
        this.direction = direction;
        speed = bulletSpeed;
        damage = weaponDamage;
        lifetime = 0f;

        // Ensure any old physics forces are cleared
        if (TryGetComponent<Rigidbody>(out Rigidbody rb)) {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
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

