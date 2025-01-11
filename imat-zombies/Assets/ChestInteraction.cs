using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestInteraction : MonoBehaviour
{
    [SerializeField] private string buyingMenuSceneName = "BuyingMenu"; 
    private bool playerIsNearby = false;

    void Update()
    {
        if (playerIsNearby && Input.GetKeyDown(KeyCode.E))
        {
            OpenBuyingMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNearby = false;
        }
    }

    private void OpenBuyingMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(buyingMenuSceneName, LoadSceneMode.Additive); 
    }
}
