using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public float MaxHealth;
    public int Damage;
    public float MoveSpeed;
    public float MoveHeight;
    public bool IsFlying;
    public bool IsArmored;
    public Perspective WeakToPerspective;
}
