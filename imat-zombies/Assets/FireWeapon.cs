using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform shootPoint; 
    public float bulletSpeed = 3f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Disparo realizado");  
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shootPoint.forward * bulletSpeed;
    }
}
