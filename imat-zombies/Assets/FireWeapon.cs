using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform shootPoint;  
    public float bulletSpeed = 20f;   

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shootPoint.forward * bulletSpeed;
    }
}

