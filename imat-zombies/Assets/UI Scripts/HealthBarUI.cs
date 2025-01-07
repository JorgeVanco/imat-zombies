using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    public void UpdateHealthBar(float value) {
        healthBarSlider.value = value;
    }
}
