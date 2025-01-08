using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Singleton instance
    private static GameManager instance;

    [SerializeField] private RoundManager roundManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private DataManager dataManager;

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


    public UIManager GetUIManager() {
        return uiManager;
    }

    public RoundManager GetRoundManager() {
        return roundManager;
    }

    public DataManager GetDataManager() {
        return dataManager;
    }
}