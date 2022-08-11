using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyDamaged();
public delegate void EnemyDied();

public class Enemy : MonoBehaviour
{
    public EnemyDamaged Damaged;
    public EnemyDied Died;

    public EnemyData EnemyData;
    public GameEvent EnemyDamagedEvent;
    public GameEvent EnemyDiedEvent;

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
        Damaged?.Invoke();
        EnemyDamagedEvent.Raise();
        if (CurrentHealth <= 0)
        {
            Died?.Invoke();
            EnemyDiedEvent.Raise();
        }
    }

    private void ResetHealth()
    {
        CurrentHealth = EnemyData.MaxHealth;
    }
}
