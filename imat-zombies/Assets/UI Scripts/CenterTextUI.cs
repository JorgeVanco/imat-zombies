using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CenterTextUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI centerText;
    private readonly float centerTextFadeDuration = 3.5f;

    public void UpdateCenterText(string message) {
        centerText.text = message;
        Debug.Log(message);
        StartCoroutine(FadeOutText(centerText, centerTextFadeDuration));
    }


    private System.Collections.IEnumerator FadeOutText(TextMeshProUGUI textElement, float duration) {
        Color originalColor = textElement.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            textElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Ensure the text is fully invisible
        textElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
