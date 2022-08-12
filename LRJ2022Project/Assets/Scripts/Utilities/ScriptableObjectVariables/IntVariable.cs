using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Int Scriptable Object Variable.
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Object Variable/Int",
    fileName = "NewIntVariable")]
public class IntVariable : ScriptableObjectVariable<int>
{

    public void Increment()
    {
        Value += 1;
    }
    
    public void Decrement()
    {
        Value -= 1;
    }
    
}
