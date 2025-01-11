using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyingMenuManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Juego";
    [SerializeField] private MoneyUI moneyUI; 

    public void BuyWeapon()
    {
        moneyUI.DecreaseMoney(60); 
    }

    public void BuyGrenade()
    {
        moneyUI.DecreaseMoney(20); 
    }

    public void BuyBullet()
    {
        moneyUI.DecreaseMoney(10); 
    }
    public void ReturnToGame()
    {
        SceneManager.UnloadSceneAsync("BuyingMenu");
        Time.timeScale = 1f;
    }
}



