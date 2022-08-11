using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AwakeHandler : MonoBehaviour
{

    [SerializeField] private UnityEvent onAwake;
    private void Awake()
    {
        onAwake?.Invoke();
    }
}
