using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Enemy _observedEnemy;

    [Header("Health Bar UI")]
    [SerializeField] private Transform[] _healthBarTransforms;

    private void OnEnable()
    {
        _observedEnemy.Damaged += UpdateHealthBar;
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    private void OnDisable()
    {
        _observedEnemy.Damaged -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = _observedEnemy.CurrentHealth / _observedEnemy.EnemyData.MaxHealth;
        int xScale;

        if (healthPercentage == 1)
        {
            xScale = 10;
        }
        else if (healthPercentage >= 0.75 && healthPercentage < 1)
        {
            xScale = 8;
        }
        else if (healthPercentage >= 0.5)
        {
            xScale = 6;
        }
        else if (healthPercentage >= 0.25)
        {
            xScale = 4;
        }
        else
        {
            // < 0.25
            xScale = 2;
        }

        foreach (Transform healthBarTransform in _healthBarTransforms)
        {
            healthBarTransform.localScale = new Vector3(xScale, 2.0f, 0.0f);
        }

    }
}
