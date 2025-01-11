using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private int currentMoney;


    public void UpdateMoneyText(int value)
    {
        currentMoney = value;
        moneyText.text = $"Money: {currentMoney}";
    }
}

