using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public int remainingBullets;
    public string weaponName;
    public int bulletCapacity;
    public float weaponCooldown;
    public float weaponReloadTime;
    public int weaponRange;
    
    public void Fire()
    {
        remainingBullets -= 1;
    }

    public bool NeedReload()
    {
        return remainingBullets <= 0;
    }
}
