using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Transform shootPoint;  // Point where bullets are spawned
    private float bulletSpeed = 30.0f; // Bullet speed
    public float maxShootDistance = 1000f;
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
        Vector3 aimDirection = GetPreciseAimDirection();

        // Only shoot if we have a valid direction
        if (aimDirection != Vector3.zero) {
            Bullet bullet = BulletPool.Instance.GetBullet();
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = Quaternion.LookRotation(aimDirection);
            bullet.Initialize(aimDirection, bulletSpeed, damage);
        }
    }

    private Vector3 GetPreciseAimDirection() {
        // Calculate screen center
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        Ray ray = playerCamera.ScreenPointToRay(screenCenter);

        // Get the exact point we're aiming at
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out RaycastHit hit, maxShootDistance)) {
            targetPoint = hit.point;
        }
        else {
            targetPoint = ray.GetPoint(maxShootDistance);
        }

        // Calculate precise direction from gun to target
        Vector3 direction = (targetPoint - shootPoint.position).normalized;
        return direction;
    }
}
