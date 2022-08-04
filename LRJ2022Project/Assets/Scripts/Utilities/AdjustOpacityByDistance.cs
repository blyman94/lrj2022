using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustOpacityByDistance : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector3Variable _distanceFrom;

    [Tooltip("0 : X, 1 : Y, 2 : Z")]
    [Range(0, 2)]
    [SerializeField] private int distanceAxis;

    private int minDistance = 32;
    private int maxDistance = 96;

    private void Update()
    {
        float distance;
        switch (distanceAxis)
        {
            case 0:
                distance = Mathf.Abs(transform.position.x - _distanceFrom.Value.x);
                break;
            case 1:
                distance = Mathf.Abs(transform.position.y - _distanceFrom.Value.y);
                break;
            case 2:
                distance = Mathf.Abs(transform.position.z - _distanceFrom.Value.z);
                break;
            default:
                distance = 0;
                break;
        }

        Color newColor = new Color(spriteRenderer.color.r,
            spriteRenderer.color.b, spriteRenderer.color.g);
        newColor.a = Mathf.Lerp(1, 0, Mathf.Abs((distance-minDistance)) / maxDistance);
        spriteRenderer.color = newColor;
    }
}
