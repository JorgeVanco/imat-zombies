using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWeapon : MonoBehaviour, IUsable, IThrowable
{
    public GameObject explosionPrefab;  // Prefab de la explosi�n
    public GameObject grenadePrefab;
    public Transform grenadePosition;   // Posici�n donde se generar� la explosi�n
    private float explosionRadius = 10f; // Explosion radius
    private float explosionDamage = 150f; // Base damage of the grenade
    public void Use() {
        Throw();
    }

    public void Initialize(GameObject explosionPrefab, float radius, float damage) {
        this.explosionPrefab = explosionPrefab;
        explosionRadius = radius;
        explosionDamage = damage;
    }

    public void Throw() {
        GameObject grenade = Instantiate(grenadePrefab, grenadePosition.position, grenadePosition.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        // Add an impulse force to throw the grenade
        Vector3 throwDirection = grenadePosition.forward; // Use the forward direction of the grenadePosition as the throw direction
        float throwForce = 10f; // Adjust this value to control the throw strength
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // The corroutine has to be called from here because if it is called from the granade from
        // the inventory, it stops because that granade is SetActive(false) when it is removed from the inventory.
        GrenadeWeapon grenadeWeapon = grenade.GetComponent<GrenadeWeapon>();
        Debug.Log(grenadeWeapon);
        grenadeWeapon.Initialize(explosionPrefab, explosionRadius, explosionDamage);
        grenadeWeapon.StartExplosionCoroutine(grenade);
    }

    public void StartExplosionCoroutine(GameObject grenade) {
        StartCoroutine(ExplodeCoroutine(grenade));
    }

    IEnumerator ExplodeCoroutine(GameObject grenade)
    {
        yield return new WaitForSeconds(2f);
        Vector3 explosionPosition = grenade.transform.position;
        // Instanciar la explosi�n en la posici�n de la granada
        GameObject explosion = Instantiate(explosionPrefab, explosionPosition, grenade.transform.rotation);
        Destroy(grenade);
        DealDamage(explosionPosition);

        // Destruir la explosi�n despu�s de 4 segundos
        Destroy(explosion, 4f); // La explosi�n desaparecer� despu�s de 4 segundos
    }

    public void DealDamage(Vector3 explosionPosition) {
        // Get all colliders in the area of explosion
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider collider in colliders) {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null) {
                // Calculate damage based on distance
                float distance = Vector3.Distance(explosionPosition, collider.transform.position);
                float damage = Mathf.Max(0, explosionDamage * (1 - distance / explosionRadius));

                // Apply damage
                damageable.TakeDamage(damage);
            }

        }
    }
}
