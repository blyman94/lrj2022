using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CooldownControl : MonoBehaviour
{
    [SerializeField] private FloatVariable cooldownBase;
    [SerializeField] private FloatVariable cooldownActual;
    [SerializeField] private GameEvent cooldownFinished;

    [SerializeField] private BoolVariable cooldownElapsed;

    private void Start()
    {
        RefreshCooldown();
    }
    

    public void RefreshCooldown()
    {
        cooldownActual.Value = cooldownBase.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownActual.Value < 0)
        {
            if (!cooldownElapsed.Value)
            {
                cooldownElapsed.Value = true;
                cooldownFinished.Raise();
            }
            return;
        }

        cooldownElapsed.Value = false;
        cooldownActual.Value -= Time.deltaTime*0.6f;
        
    }
}
