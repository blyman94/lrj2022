using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    [SerializeField] private BoolVariable cooldownStart;
    [SerializeField] List<Button> fireButtons;

    private void Start()
    {
        SwitchButtons();
    }
    
    private void OnEnable()
    {
        cooldownStart.VariableUpdated += SwitchButtons;
    }

    private void OnDisable()
    {
        cooldownStart.VariableUpdated -= SwitchButtons;
    }

    private void SwitchButtons()
    {
        foreach (Button button in fireButtons)
        {
            button.interactable = cooldownStart.Value;
        }
    }
}
