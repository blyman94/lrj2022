using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunRenderer : MonoBehaviour
{
    [SerializeField] private IntVariable railgunLane;

    [SerializeField] private Animator railgunAnimator;
    

    private Vector3 savePoint ;

    public void SetLane()
    {
        savePoint = transform.position;
        Debug.Log("Set Lane");
        transform.position = new Vector3(16*(railgunLane.Value) + 8, transform.position.y,transform.position.z);
        railgunAnimator.Play("RailgunShot");
        
       // transform.position = savePoint;

    }
}
