using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData;

    private int currentHealth;

    #region MonoBehaviour Methods
    private void Update()
    {
        MoveTowardBase();
    }
    #endregion

    private void MoveTowardBase()
    {
        transform.Translate(0, 0, -EnemyData.MoveSpeed * Time.deltaTime);
    }
}
