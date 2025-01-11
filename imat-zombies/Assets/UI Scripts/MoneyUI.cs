using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//public class MoneyUI : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI moneyText;

//    public void UpdateMoneyText(int value)
//    {
//        moneyText.text = $"Money: {value}";

//    }
//}

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private int currentMoney;

    void Start()
    {
        InitializeMoney(100); 
    }

    public void InitializeMoney(int startingMoney)
    {
        currentMoney = startingMoney;
        UpdateMoneyText(currentMoney);
    }
        
    public void DecreaseMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyText(currentMoney);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero");
        }
    }

    public void UpdateMoneyText(int value)
    {
        currentMoney = value;
        moneyText.text = $"Money: {currentMoney}";
    }
}

