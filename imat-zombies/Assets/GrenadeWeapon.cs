using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWeapon : MonoBehaviour
{
    public GameObject explosionPrefab;  // Prefab de la explosi�n
    public Transform grenadePosition;   // Posici�n donde se generar� la explosi�n

    void Update()
    {
        // Detectar si se presiona el click izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            Explode();
        }
    }

    void Explode()
    {
        // Instanciar la explosi�n en la posici�n de la granada
        GameObject explosion = Instantiate(explosionPrefab, grenadePosition.position, grenadePosition.rotation);

        // Destruir la explosi�n despu�s de 4 segundos
        Destroy(explosion, 4f); // La explosi�n desaparecer� despu�s de 4 segundos
    }
}
