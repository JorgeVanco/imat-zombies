using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public int Money { get; private set; }
    public int Score { get; private set; }
    public int TotalAmmo = 90;
    
    private int roundMultiplier = 1;
    private GameManager gameManager;
    private UIManager uiManager;
    void Start()
    {
        gameManager = GameManager.GetInstance();
        uiManager = gameManager.GetUIManager();
        // Set initial values
        ResetScore();
        ResetMoney();

    }


    public void AddToScore(int scoreVal) {
        SetScore(Score + scoreVal);
    }

    public void ResetScore() {
        SetScore(0);
    }
    private void SetScore(int newScore) {
        Score = newScore;
        uiManager.UpdateScore(Score);
    }

    public void AddToMoney(int moneyVal) {
        SetMoney(Money + moneyVal);
    }

    public void RemoveMoney(int moneyVal) {
        SetMoney(Money - moneyVal);
    }

    public void ResetMoney() {
        SetMoney(0);
    }
    public void SetMoney(int newMoney) {
        Money = newMoney;
        uiManager.UpdateMoney(Money);
    }

    public void OnZombieKilled() {
        AddToScore(roundMultiplier * 10);
        AddToMoney(roundMultiplier * 5);
    }

    public void UpdateRoundMultiplier(int round) {
        // Update the round multiplier every 5 rounds
        if (round % 5 == 0) {
            roundMultiplier++;
        }
    }

}
