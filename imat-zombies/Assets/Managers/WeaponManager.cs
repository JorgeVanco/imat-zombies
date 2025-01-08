using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;  // El arma actual que est� siendo usada
    public GameObject knife;          // El cuchillo que se usar� cuando se presione "C"
    public GameObject gun;            // El arma de fuego (pistola)
    public GameObject grenade;        // La granada que se usar� cuando se presione "C"

    void Start()
    {
        // Inicialmente, mostrar solo el arma que tienes equipados (pistola o cuchillo)
        knife.SetActive(false);  // El cuchillo no est� visible al inicio
        gun.SetActive(true);    // La pistola est� visible al inicio
        grenade.SetActive(false); // La granada no est� visible al inicio
        currentWeapon = gun;   // Comienza con la pistola activa
    }

    void Update()
    {
        // Detectar si presionas la tecla 'C' para cambiar de arma
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleWeapon();
        }
    }

    void ToggleWeapon()
    {
        // Cambiar entre cuchillo, pistola y granada de manera c�clica
        if (currentWeapon == gun)
        {
            // Si est�s usando la pistola, cambia al cuchillo
            gun.SetActive(false);  // Desactiva la pistola
            knife.SetActive(true); // Activa el cuchillo
            currentWeapon = knife;
        }
        else if (currentWeapon == knife)
        {
            // Si est�s usando el cuchillo, cambia a la granada
            knife.SetActive(false);  // Desactiva el cuchillo
            grenade.SetActive(true); // Activa la granada
            currentWeapon = grenade;
        }
        else if (currentWeapon == grenade)
        {
            // Si est�s usando la granada, cambia a la pistola
            grenade.SetActive(false);  // Desactiva la granada
            gun.SetActive(true);       // Activa la pistola
            currentWeapon = gun;
        }
    }
}
