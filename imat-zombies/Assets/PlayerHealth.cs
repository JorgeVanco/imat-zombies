using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // Maximum health of the player
    private float currentHealth; // Current health of the player
    [SerializeField] private UIManager uiManager;
    private void Start() {
        // Set current health to max health at the start
        UpdateHealth(maxHealth);
    }

    private void UpdateHealth(float health) {
        health = Mathf.Clamp(health, 0f, maxHealth); // Ensure health doesn't go below 0 or above maxHealth
        currentHealth = health;
        uiManager.UpdateHealthBar(currentHealth / maxHealth);
    }

    // Call this method to take damage
    public void TakeDamage(float damageAmount) {
        float newHealth = currentHealth - damageAmount;
        UpdateHealth(newHealth);
    }

    // Call this method to heal the player
    public void Heal(float healAmount) {
        float newHealth = currentHealth + healAmount;
        UpdateHealth(newHealth);
    }

    void OnTriggerEnter(Collider other) {
        TakeDamage(5.0f);
    }
}

