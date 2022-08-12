using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    [SerializeField] private BoolVariable cooldownStart;
    [SerializeField] Button aimingButton;

    private void Start()
    {
        EnableScreen();
    }
    
    private void OnEnable()
    {
        cooldownStart.VariableUpdated += EnableScreen;
    }

    private void OnDisable()
    {
        cooldownStart.VariableUpdated -= EnableScreen;
    }

    private void EnableScreen()
    {
        aimingButton.interactable = cooldownStart.Value;
    }
}
