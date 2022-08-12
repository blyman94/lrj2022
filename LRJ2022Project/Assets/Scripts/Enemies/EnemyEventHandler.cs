using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Enemy _observedEnemy;
    
    [Header("GameEvents")]
    [SerializeField] GameEvent onDamage;
    [SerializeField] GameEvent onDeath;

  

    private void OnDamage()
    {
        onDamage.Raise();
    }

    private void OnDeath()
    {
        onDeath.Raise();
    }

}
