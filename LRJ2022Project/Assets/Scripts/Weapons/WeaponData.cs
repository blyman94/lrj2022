using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName = "Pistol";
    public int bulletCapacity = 17;
    public int remainingBullets;
    public float weaponCooldown = 0.4f;
    public float weaponReloadTime = 2f;
    public int weaponRange = 64;
    public int bulletDamage = 1;

    public void Init()
    {
        remainingBullets = bulletCapacity;
    }

    public void Fire()
    {
        remainingBullets -= 1;
    }

    public bool NeedReload()
    {
        return remainingBullets <= 1;
    }

    public bool OutOfBullets()
    {
        return remainingBullets == 0;
    }

    public void Reload()
    {
        remainingBullets = bulletCapacity;
    }
}
