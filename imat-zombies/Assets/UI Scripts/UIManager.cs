using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RoundUI roundUI;
    public CenterTextUI centerTextUI;
    public HealthBarUI healthBarUI;

    [SerializeField] private RoundManager roundManager;

    private void OnEnable() {
        // Subscribe to events
        if (roundManager != null) {
            roundManager.OnRoundStarted += UpdateRoundText;
            roundManager.OnRoundStarted += ShowRoundStartCenterText;
            roundManager.OnRoundEnded += ShowRoundEndCenterText;
        }
    }

    private void OnDisable() {
        // Unsubscribe from the events
        if (roundManager != null) {
            roundManager.OnRoundStarted -= UpdateRoundText;
            roundManager.OnRoundStarted -= ShowRoundStartCenterText;
            roundManager.OnRoundEnded -= ShowRoundEndCenterText;
        }
    }
    public void UpdateRoundText(int round) {
        if (roundUI != null) {
            roundUI.UpdateRoundText(round);
        }
    }

    public void ShowRoundEndCenterText(int round) {
        ShowCenterText($"Round {round} ended");
    }
    public void ShowRoundStartCenterText(int round) {
        ShowCenterText($"Round {round} starting");
    }
    public void ShowCenterText(string message) {
        if (centerTextUI != null) {
            centerTextUI.UpdateCenterText(message);
        }
    }

    public void UpdateHealthBar(float value) {
        if (healthBarUI != null) {
            healthBarUI.UpdateHealthBar(value);
        }
    }
}
