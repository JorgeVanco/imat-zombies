using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFloor : MonoBehaviour
{
    private GameManager gameManager;
    private DataManager dataManager;
    void Start()
    {
        gameManager = GameManager.GetInstance();
        dataManager = gameManager.GetDataManager();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            dataManager.TotalAmmo += 30;
            Destroy(gameObject);
        }
    }
}
