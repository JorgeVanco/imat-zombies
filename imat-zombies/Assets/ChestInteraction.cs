using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;
public class ChestInteraction : MonoBehaviour
{
    private string buyingMenuSceneName = "BuyingMenu"; 
    // public Canvas buyingMenuCanvas;
    private bool playerIsNearby = false;
    private float interactionRadius = 5f;

    void Update()
    {

        CheckIfPlayerNearby();
        
        if (playerIsNearby && Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().name != buyingMenuSceneName)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            int activeScenes = SceneManager.sceneCount;
            if (activeScenes == 1) {

                OpenBuyingMenu();
            }
        }
    }

    private void CheckIfPlayerNearby() {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) {
            // Calculate the distance between the chest and the player
            float distance = Vector3.Distance(transform.position, player.transform.position);
            playerIsNearby = distance <= interactionRadius;
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearby = false;
        }
    }


    public void OpenBuyingMenu()
    {
        Time.timeScale = 0f;
        GameManager.GetInstance().GetMenuManager().ChangeToScene(buyingMenuSceneName, additive: true);
        
    }
    
    
}
