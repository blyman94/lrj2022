using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunBullet : MonoBehaviour
{
    [SerializeField] private int damage; 
    
    [SerializeField] private BoolVariable usePhysicalBullet;
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision Detected");
        if (collision.gameObject.GetComponent<Enemy>() != null && usePhysicalBullet.Value)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
