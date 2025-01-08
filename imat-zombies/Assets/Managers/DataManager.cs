using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private int lifes = 5;
    private int money = 0;
    private int score = 0;
    
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
        SetScore(score + scoreVal);
    }

    public void ResetScore() {
        SetScore(0);
    }
    private void SetScore(int newScore) {
        score = newScore;
        uiManager.UpdateScore(score);
    }

    public void AddToMoney(int moneyVal) {
        SetMoney(money + moneyVal);
    }

    public void ResetMoney() {
        SetMoney(0);
    }
    private void SetMoney(int newMoney) {
        money = newMoney;
        uiManager.UpdateMoney(money);
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
