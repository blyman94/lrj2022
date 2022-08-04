using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Perspective {FRONT, SIDE, TOP}

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public int MaxHealth;
    public float MoveSpeed;
    public float MoveHeight;

    public Vector3 colliderCenter;
    public Vector3 colliderSize;

    public Perspective CanAttackPerspective;

    public Sprite FrontViewSprite;
    public Sprite SideViewSprite;
    public Sprite TopViewSprite;
}
