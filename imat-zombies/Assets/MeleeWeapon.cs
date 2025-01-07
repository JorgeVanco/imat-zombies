using UnityEngine;
using System.Collections;

public class MeleeWeapon : MonoBehaviour
{
    public Transform player;  
    public float moveDistance = 0.5f;
    public float moveSpeed = 3f;
    private bool isMoving = false;

    private Vector3 weaponOffset;

    void Start()
    {
        weaponOffset = transform.position - player.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            StartCoroutine(MoveWeapon());
        }
    }

    IEnumerator MoveWeapon()
    {
        isMoving = true;

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
    }
}
    