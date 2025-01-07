using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Transform shootPoint;  // Point where bullets are spawned
    public float bulletSpeed = 1000f; // Bullet speed
    private float damage;
    private Camera playerCamera;      // Reference to the player's camera


    public void Start() {
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
        damage = 25;

    }
    void Update() {
        if (Input.GetButtonDown("Fire1")) // Trigger shooting
        {
            Shoot();
        }
    }

    void Shoot() {
        // Get a bullet from the pool
        Bullet bullet = BulletPool.Instance.GetBullet();

        // Set bullet's position and direction
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        Vector3 shootDirection = GetShootDirection();

        // Initialize the bullet with its direction and speed
        bullet.Initialize(shootDirection, bulletSpeed, damage);

    }

    private Vector3 GetShootDirection() {
        return playerCamera.transform.forward;
    }
}
