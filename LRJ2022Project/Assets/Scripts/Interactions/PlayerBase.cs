using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int MaxHealth = 3;
    [SerializeField] private IntVariable _health;
    [SerializeField] private GameEvent BaseDamaged;
    [SerializeField] private GameEvent LastLife;
    [SerializeField] private GameEvent LoseGame;

    private void Start()
    {
        _health.Value = MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(enemy.EnemyData.Damage);
        }
    }

    private void TakeDamage(int damageToTake)
    {
        BaseDamaged.Raise();
        _health.Value -= damageToTake;
        if (_health.Value == 1)
        {
            LastLife.Raise();
        }

        if (_health.Value <= 0)
        {
            LoseGame.Raise();
        }
    }
}
