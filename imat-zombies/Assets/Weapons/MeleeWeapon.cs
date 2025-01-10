using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour, IUsable
{
    public Transform player;  
    public float moveDistance = 0.5f;
    public float moveSpeed = 3f;
    private bool isMoving = false;
    private float damage = 100f;
    private Collider meleeCollider;

    private Vector3 weaponOffset;

    void Start()
    {
        weaponOffset = transform.position - player.position;
        meleeCollider = GetComponent<Collider>();
        meleeCollider.enabled = false;
    }

    public void Use() {
        if (!isMoving) {
            StartCoroutine(MoveWeapon());
        }
    }


    void OnTriggerEnter(Collider other) {
        // Check if the object has a health component

        Zombie zombie = other.GetComponent<Zombie>();
        if (zombie != null) {

            // Apply damage to the zombie
            zombie.TakeDamage(damage);
           
            
        }
    }

    IEnumerator MoveWeapon()
    {
        isMoving = true;
        meleeCollider.enabled = true;
        Vector3 initialPosition = transform.position;

        Vector3 targetPosition = initialPosition + player.forward * moveDistance;

        float elapsedTime = 0f;
        while (elapsedTime < 0.1f)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / 0.1f);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = targetPosition;

        elapsedTime = 0f;
        while (elapsedTime < 0.1f)
        {
            transform.position = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / 0.1f);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = initialPosition;

        transform.position = player.position + weaponOffset;

        isMoving = false;
        meleeCollider.enabled = false;
    }
}
    