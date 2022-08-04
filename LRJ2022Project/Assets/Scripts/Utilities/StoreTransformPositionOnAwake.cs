using UnityEngine;

public class StoreTransformPositionOnAwake : MonoBehaviour
{
    [SerializeField] private Vector3Variable _storageVariable;

    private void Awake()
    {
        _storageVariable.Value = transform.position;
    }
}
