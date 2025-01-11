using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    private static GameManager instance;

    [SerializeField] private RoundManager roundManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private DataManager dataManager;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private MenuManager menuManager;

    public static GameManager GetInstance() { 
        if (instance == null) {
            // Try to find existing instance in scene
            instance = FindObjectOfType<GameManager>();

            if (instance == null) {
                Debug.LogError("No GameManager found in scene! Ensure one is placed in the scene.");
            }
        }
        return instance;
    }

    

    private void Awake() {
        roundManager.OnZombieKilledAction += dataManager.OnZombieKilled;
        roundManager.OnRoundEnded += dataManager.UpdateRoundMultiplier;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMainMenu();
        }
    }

    public UIManager GetUIManager() {
        return uiManager;
    }

    public RoundManager GetRoundManager() {
        return roundManager;
    }

    public DataManager GetDataManager() {
        return dataManager;
    }

    public WeaponManager GetWeaponManager() {
        return weaponManager;
    }

    public MenuManager GetMenuManager() {
        return menuManager;
    }

    public void AddMoneyUI(MoneyUI moneyUI) {
        if (!uiManager.moneyUI.Contains(moneyUI)) {
            uiManager.moneyUI.Add(moneyUI);

            // Set money so that the ui updates
            dataManager.SetMoney(dataManager.Money);
        }
        
    }

    private void GoToMainMenu()
    {
        menuManager.ChangeToScene("MainMenu");
    }
}