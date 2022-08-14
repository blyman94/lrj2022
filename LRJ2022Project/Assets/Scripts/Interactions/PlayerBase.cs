using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int MaxHealth = 3;
    [SerializeField] private IntVariable _health;
    [SerializeField] private GameEvent BaseDamaged;

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
        _health.Value = _health.Value - damageToTake;
    }
}
