using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object Variable/Vector3List")]
public class Vector3ListVariable : ScriptableObject
{
    public List<Vector3> Lanes;
}
