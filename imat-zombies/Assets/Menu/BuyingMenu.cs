using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BuyingMenuManager : MonoBehaviour
{
    private MoneyUI moneyUI;
    private DataManager dataManager;
    private WeaponManager weaponManager;
    private GameManager gameManager;

    private Dictionary<string, int> prices = new Dictionary<string, int>() {
        {"bullet", 10},
        {"gun", 60 },
        {"grenade", 20 }
    };

    void Start() {

        gameManager = GameManager.GetInstance();
        dataManager = gameManager.GetDataManager();
        weaponManager = gameManager.GetWeaponManager();
        gameManager.GetUIManager().UpdateMoney(dataManager.Money);
        
        // To update the money that appears
        if (moneyUI == null) {
            GameObject moneyUIObject = GameObject.Find("MoneyUIBuyingMenu");
            moneyUI = moneyUIObject.GetComponent<MoneyUI>();
            
            gameManager.AddMoneyUI(moneyUI);
        }

    }
    public void BuyItem(string name) {
        int price = prices[name];
        if (dataManager.Money >= price) {
            if (name != "bullet")
            {
                weaponManager.AddWeaponToInventory(name);
            }
            else {
                dataManager.TotalAmmo += 30;
            }
            dataManager.RemoveMoney(price);
        }
    }
    public void BuyWeapon()
    {
        BuyItem("gun");
    }
    public void BuyGrenade()
    {
        BuyItem("grenade");
    }

    public void BuyBullet()
    {
        BuyItem("bullet");
    }
    public void ReturnToGame()
    
    {
        CursorLocker.LockCursor();

        gameManager.GetMenuManager().UnloadScene("BuyingMenu");

        // Unpause the game
        Time.timeScale = 1f;
    }
}



