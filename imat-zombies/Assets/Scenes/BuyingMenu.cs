using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BuyingMenuManager : MonoBehaviour
{
    private MoneyUI moneyUI;
    private DataManager dataManager;
    private WeaponManager weaponManager;

    private int weaponPrice = 60;
    private int grenadePrice = 20;
    private int bulletPrice = 10;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameManager gameManager = GameManager.GetInstance();
        dataManager = gameManager.GetDataManager();
        weaponManager = gameManager.GetWeaponManager();
        gameManager.GetUIManager().UpdateMoney(dataManager.Money);
        Debug.Log(moneyUI);
        if (moneyUI == null) {
            GameObject moneyUIObject = GameObject.Find("MoneyUIBuyingMenu");
            moneyUI = moneyUIObject.GetComponent<MoneyUI>();
            Debug.Log(moneyUI);
            gameManager.AddMoneyUI(moneyUI);
        }

    }
    public void BuyItem(string name, int price) {
        if (name != "bullet")
        {
            weaponManager.AddWeaponToInventory(name);
        }
        else {
            dataManager.TotalAmmo += 30;
        }
        dataManager.RemoveMoney(price);
    }
    public void BuyWeapon()
    {
        if (dataManager.Money >= weaponPrice) {
            BuyItem("gun", weaponPrice);
        }
    }
    public void BuyGrenade()
    {
        if (dataManager.Money >= grenadePrice) {
            BuyItem("grenade", grenadePrice);
        }
    }

    public void BuyBullet()
    {
        if (dataManager.Money >= bulletPrice) {
            BuyItem("bullet", bulletPrice);
        }
    }
    public void ReturnToGame()
    
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.UnloadSceneAsync("BuyingMenu");

        // Unpause the game
        Time.timeScale = 1f;
    }
}



