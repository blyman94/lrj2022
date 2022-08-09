using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float lifetime = 1.0f;

    private float lifeTimer = 0.0f;

    private void Start()
    {
        lifeTimer = lifetime;
    }

    public void Update()
    {
        if (lifeTimer >= 0)
        {
            lifeTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
