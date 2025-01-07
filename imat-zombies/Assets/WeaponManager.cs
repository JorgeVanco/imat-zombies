using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;  // El arma actual que est� siendo usada
    public GameObject knife;          // El cuchillo que se usar� cuando se presione "C"
    public GameObject gun;            // El arma de fuego (pistola)

    void Start()
    {
        // Inicialmente, mostrar solo el arma que tienes equipados (pistola o cuchillo)
        knife.SetActive(false); // El cuchillo no est� visible al inicio
        gun.SetActive(true);   // La pistola est� visible al inicio
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
        if (currentWeapon == gun)
        {
            // Si est�s usando la pistola, cambia al cuchillo
            gun.SetActive(false);  // Desactiva la pistola
            knife.SetActive(true); // Activa el cuchillo
            currentWeapon = knife;
        }
        else
        {
            // Si est�s usando el cuchillo, cambia a la pistola
            knife.SetActive(false); // Desactiva el cuchillo
            gun.SetActive(true);    // Activa la pistola
            currentWeapon = gun;
        }
    }
}
