using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI: MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private Image reloadProgressBar;
    [SerializeField] private GameObject reloadingText;

    private FireWeapon weapon;

    private GameManager gameManager;
    private DataManager dataManager;

    void Start() {

        gameManager = GameManager.GetInstance();
        dataManager = gameManager.GetDataManager();

        // Find the weapon component
        weapon = FindObjectOfType<FireWeapon>();

        // Hide reload UI initially
        reloadProgressBar.gameObject.SetActive(false);
        reloadingText.SetActive(false);
    }

    void Update() {
        UpdateAmmoDisplay();
        UpdateReloadDisplay();
    }

    private void UpdateAmmoDisplay() {
        if (weapon != null && ammoText != null) {
            // Display current ammo / total ammo
            ammoText.text = $"{weapon.GetCurrentAmmo()} / {dataManager.TotalAmmo}";
        }
    }

    private void UpdateReloadDisplay() {
        bool isReloading = weapon.IsReloading();

        // Show/hide reloading text
        
        reloadingText.SetActive(isReloading);
        

        reloadProgressBar.gameObject.SetActive(isReloading);
        if (isReloading) {
            reloadProgressBar.fillAmount = weapon.GetReloadProgress();
            ammoText.text = "";
        }
        
    }
}