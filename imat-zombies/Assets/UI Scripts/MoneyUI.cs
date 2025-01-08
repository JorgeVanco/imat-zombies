using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void UpdateMoneyText(int value) {
        moneyText.text = $"Money: {value}";

    }
}
