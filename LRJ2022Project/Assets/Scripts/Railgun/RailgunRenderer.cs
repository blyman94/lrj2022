using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunRenderer : MonoBehaviour
{
    [SerializeField] private IntVariable railgunLane;

    [SerializeField] private int fireTime;

    private Vector3 savePoint ;
    public void SetLane()
    {
        savePoint = transform.position;
        Debug.Log("Set Lane");
        StartCoroutine(FireCylinder());
    }

    private IEnumerator FireCylinder()
    {
        transform.position = new Vector3( 16* (railgunLane.Value+1), transform.position.y, transform.position.z);
        Vector3 startingPos  = transform.position;

        Vector3 finalPos = startingPos + Vector3.forward * 128;
        float elapsedTime = 0;
         
        while (elapsedTime < fireTime)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / fireTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = savePoint;


    }
}
