using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundText;

    public void UpdateRoundText(int round) {
        roundText.text = $"Round {round}";
    }
}
