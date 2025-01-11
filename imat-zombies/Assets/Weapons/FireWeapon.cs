using UnityEngine;

public class FireWeapon : Weapon, IUsable
{
    public Transform shootPoint;  // Point where bullets are spawned
    private float bulletSpeed = 30.0f; // Bullet speed
    public float maxShootDistance = 1000f;
    private Camera playerCamera;      // Player's camera

    private GameManager gameManager;
    private DataManager dataManager;

    [Header("Ammo Settings")]
    public int maxAmmo = 30;         // Maximum ammo in magazine
    private int currentAmmo;         // Current ammo in magazine
    public float reloadTime = 2.0f;  // Time it takes to reload
    private bool isReloading = false;
    private float reloadTimer = 0f;

    public int GetCurrentAmmo() => currentAmmo;
    public bool IsReloading() => isReloading;
    public float GetReloadProgress() => isReloading ? reloadTimer / reloadTime : 0f;
    public void Start() {

        gameManager = GameManager.GetInstance();
        dataManager = gameManager.GetDataManager();

        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
        damage = 25;
        currentAmmo = maxAmmo; // Start with a full magazine

    }
    void Update() {
        // Handle reloading
        if (isReloading) {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime) {
                FinishReload();
            }
        }

        // Manual reload when pressing R
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && dataManager.TotalAmmo > 0) {
            StartReload();
        }


    }

    public void Use() {
        if (isReloading) {
            return; // Can't shoot if it is reloading
        }
        // Regular shooting
        if (currentAmmo > 0) {
            Shoot();
        }
        // Auto reload when empty and trying to shoot
        else if (currentAmmo <= 0 && dataManager.TotalAmmo > 0) {
            StartReload();
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

        currentAmmo--;
    }

    private void StartReload() {
        if (!isReloading && dataManager.TotalAmmo > 0) {
            isReloading = true;
            reloadTimer = 0f;
        }
    }

    private void FinishReload() {
        int ammoNeeded = maxAmmo - currentAmmo;
        int ammoToAdd = Mathf.Min(ammoNeeded, dataManager.TotalAmmo);

        currentAmmo += ammoToAdd;
        dataManager.TotalAmmo -= ammoToAdd;

        isReloading = false;
        reloadTimer = 0f;
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
