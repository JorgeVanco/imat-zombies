using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWeapon : MonoBehaviour
{
    public GameObject explosionPrefab;  // Prefab de la explosión
    public Transform grenadePosition;   // Posición donde se generará la explosión

    void Update()
    {
        // Detectar si se presiona el click izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            Explode();
        }
    }

    void Explode()
    {
        // Instanciar la explosión en la posición de la granada
        GameObject explosion = Instantiate(explosionPrefab, grenadePosition.position, grenadePosition.rotation);

        // Destruir la explosión después de 4 segundos
        Destroy(explosion, 4f); // La explosión desaparecerá después de 4 segundos
    }
}
