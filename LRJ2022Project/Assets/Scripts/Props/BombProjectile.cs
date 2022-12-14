using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    [SerializeField] private int bombDamage;
    [SerializeField] private LayerMask canDamageLayer;
    [SerializeField] private int explosionRadius = 16;
    [SerializeField] private GameObject explosionPrefab;

    [Range(0, 25)]
    [SerializeField] private int _dropAcceleration = 1;

    private float _currentSpeed = 0;


    [SerializeField] private GameEvent BombExploded;

    private void Start()
    {
        _currentSpeed = 0;
    }

    private void Update()
    {
        transform.position -= (new Vector3(0.0f, _currentSpeed, 0.0f) * Time.deltaTime);
        _currentSpeed += _dropAcceleration * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Vector3 explosionCenter = new Vector3(transform.position.x, 14, transform.position.z);

        Collider[] collidersInRange = Physics.OverlapBox(explosionCenter,
            (Vector3.one * explosionRadius), Quaternion.identity,
            canDamageLayer);
        foreach (Collider collider in collidersInRange)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bombDamage);
            }
        }

        Instantiate(explosionPrefab, explosionCenter, Quaternion.identity);
        BombExploded.Raise();

        Destroy(gameObject);
    }
}
