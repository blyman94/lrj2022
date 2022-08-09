
using System;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private FloatVariable cooldownBase;
    [SerializeField] private FloatVariable cooldownActual;
    [SerializeField] private Slider cooldownSlider;


    private void OnEnable()
    {
        cooldownActual.VariableUpdated += UpdateCooldownFill;
    }

    private void OnDisable()
    {
        cooldownActual.VariableUpdated -= UpdateCooldownFill;
    }

    private void UpdateCooldownFill()
    {
        cooldownSlider.value = (cooldownBase.Value -Mathf.Clamp(cooldownActual.Value, 0, cooldownBase.Value)) / cooldownBase.Value;
    }
}
