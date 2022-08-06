using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void HealthChanged();
public delegate void Died();

public class Enemy : MonoBehaviour
{
    public HealthChanged HealthChanged;
    public Died Died;
    
    public EnemyData EnemyData;

    public float CurrentHealth { get; set; }

    #region MonoBehaviour Methods
    private void Awake()
    {
        CurrentHealth = EnemyData.MaxHealth;
    }
    private void Update()
    {
        MoveTowardBase();
    }
    #endregion

    private void MoveTowardBase()
    {
        transform.Translate(0, 0, -EnemyData.MoveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damageToTake)
    {
        CurrentHealth = CurrentHealth - damageToTake;
        HealthChanged?.Invoke();
        if (CurrentHealth <= 0)
        {
            Died?.Invoke();
        }
    }

    private void ResetHealth()
    {
        CurrentHealth = EnemyData.MaxHealth;
    }
}
