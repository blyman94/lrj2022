using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    // Refers to the amount of bullets that can be fired before reloading
    public int bulletCapacity;
    // Refers to the delay (in seconds) before a consecutive bullet can be fired
    public float rateOfFire;
    // Refers to the offset of bullet from the target position, spread is even across a square area
    public float bulletSpread;
    // Scatter Count determines the number of bullets fired in one discharge of the gun, all randomized via bullet spread
    public int scatterCount;
    // Automatic Fire Mode enables holding down the mouse to continously fire
    public bool isAuto;
    // Intelligent Firing Capabilities (delay != -1) ensure that turrets continue to fire regardless of perspective, at their max fire rate, but with a penalty (in seconds).
    public bool isIntel;
    public float rofDelay;
    // Reloading delays the firing of the next bullet, but replenishes bullet count to max capacity
    public float reloadTime;
    // Total Number of Bullets on Instantiation
    public int initTotal;
}
