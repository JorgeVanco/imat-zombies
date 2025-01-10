using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;  // El arma actual que est� siendo usada
    public GameObject knife;          // El cuchillo que se usar� cuando se presione "C"
    public GameObject gun;            // El arma de fuego (pistola)
    public GameObject grenade;        // La granada que se usar� cuando se presione "C"

    private int currentWeaponIdx;
    private List<GameObject> inventory = new List<GameObject>();

    void Start()
    {
        //Starts with just knife
        inventory.Add(knife);
        currentWeaponIdx = 0;
        SetCurrentWeapon();
    }

    void Update()
    {
        // Detectar si presionas la tecla 'C' para cambiar de arma
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCurrentWeapon();
        }
        if (Input.GetMouseButtonDown(0)) {
            currentWeapon.GetComponent<IUsable>().Use();
            if (currentWeapon.GetComponent<IThrowable>() != null) {
                RemoveFromInventory(currentWeaponIdx);
            }
        }
    }

    void RemoveFromInventory(int index) {
        inventory.RemoveAt(index);
        currentWeaponIdx = (currentWeaponIdx) % inventory.Count;
        SetCurrentWeapon();
    }

    void SetCurrentWeapon() {
        currentWeapon = inventory[currentWeaponIdx];
        ShowCurrentWeapon();
    }

    void ShowCurrentWeapon() {
        gun.SetActive(currentWeapon == gun);
        knife.SetActive(currentWeapon == knife);
        grenade.SetActive(currentWeapon == grenade);
    }
    void ChangeCurrentWeapon()
    {
        currentWeaponIdx = (currentWeaponIdx + 1) % inventory.Count;
        SetCurrentWeapon();
    }
}
