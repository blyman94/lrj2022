using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData _enemyData;
    public EnemyData EnemyData
    {
        get
        {
            return _enemyData;
        }
        set
        {
            _enemyData = value;
            LoadEnemy();
        }
    }

    private void LoadEnemy()
    {
        // TODO: Load enemy into game world.
    }

    private void MoveTowardBase()
    {

    }
}
