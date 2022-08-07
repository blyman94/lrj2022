using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    [Range(0,25)]
    [SerializeField] private int _dropAcceleration = 1;

    private float _currentSpeed = 0;

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
        Debug.Log("We hit something!");
        Destroy(gameObject);
    }
}
